using System.Collections.Immutable;
using coIT.Clockodo.QuickActions;
using coIT.Lexoffice.GdiExport.Umsatzkontenprüfung;
using coIT.Libraries.ConfigurationManager;
using coIT.Libraries.ConfigurationManager.Cryptography;
using coIT.Libraries.ConfigurationManager.Serialization;
using coIT.Libraries.Gdi.Accounting;
using coIT.Libraries.Gdi.Accounting.Contracts;
using coIT.Libraries.LexOffice;
using coIT.Libraries.Toolkit.Datengrundlagen.Konten;
using coIT.Libraries.Toolkit.Datengrundlagen.Mitarbeiter;
using coIT.Toolkit.Lexoffice.GdiExport;
using coIT.Toolkit.Lexoffice.GdiExport.Helpers;
using coIT.Toolkit.Lexoffice.GdiExport.Kundenstamm;
using CSharpFunctionalExtensions;
using GdiInvoice = coIT.Libraries.Gdi.Accounting.Contracts.Invoice;
using KundenstammDaten = coIT.Libraries.Toolkit.Datengrundlagen.Kunden.Kundenstamm;
using LexofficeInvoice = coIT.Libraries.LexOffice.DataContracts.Invoice.Invoice;
using View = coIT.Lexoffice.GdiExport.Umsatzkonten.View;

namespace coIT.Lexoffice.GdiExport;

public partial class MainForm : Form
{
    private Konfiguration _konfiguration;
    private string _kundenstammListePfad;
    private string _kontenListePfad;
    private string _mitarbeiterListePfad;

    private JsonRepository<KontoDetails> _kontoRepository;
    private Leistungsempfänger _leistungsempfänger;
    private LexofficeService _lexofficeService;
    private List<Mitarbeiter> _mitarbeiterListe;
    private EnvironmentManager _environmentManager;
    private FileSystemManager _filesystemManager;

    public MainForm()
    {
        InitializeComponent();

        PrepareListView(lview_ErkannteFehler);
        PrepareListView(lview_InvoiceLines);
        PrepareMonthSelectionButtons();
    }

    private void PrepareListView(ListView view)
    {
        var header = new ColumnHeader();
        header.Text = "";
        header.Name = "col1";
        view.Columns.Add(header);
        view.HeaderStyle = ColumnHeaderStyle.None;
        view.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        view.View = System.Windows.Forms.View.Details;
    }

    private void PrepareMonthSelectionButtons()
    {
        SetButtonTextToMonthsAgo(btnLastMonth, 1);
        SetButtonTextToMonthsAgo(btnBeforeLastMonth, 2);
        SetButtonTextToMonthsAgo(btnTwoMonthsAgo, 3);
    }

    private void SetButtonTextToMonthsAgo(Button button, int months)
    {
        var today = DateTime.Today;
        var monthsAgo = today.AddMonths(months * -1);
        button.Text = monthsAgo.ToString("Y");
    }

    private async void Form1_Load(object sender, EventArgs e)
    {
        await KonfigurationLaden();

        _lexofficeService = new LexofficeService(_konfiguration.LexofficeKey);

        await InitializeCustomerView();
        await BenutzeransichtInitialisieren();

        LeistungsempfaengerMitLeererDebitorenNummerAnzeigen();
        LeistungsempfaengerAufDuplikatePruefen();
        await KontenAufDuplikatePrüfen();
        MitarbeiterAufDuplikatePrüfen();
        await InitializeAccountView();
    }

    private async Task KonfigurationLaden()
    {
        var cryptoService = AesCryptographyService
            .FromKey(
                "eyJJdGVtMSI6IkdNUmFNYkdmWkZSTDNsaGZYb1V3VHVCRlRvMm5LbDk5UXlnTHhWQzFXR0U9IiwiSXRlbTIiOiIwWWRlQXNXeW9GTXdBcFkydGI2Nk93PT0ifQ=="
            )
            .Value;
        var serializationService = new NewtonsoftJsonSerializer();
        _environmentManager = new EnvironmentManager(cryptoService, serializationService);
        _filesystemManager = new FileSystemManager();

        var konfigurationKorrektGesetzt = await _environmentManager
            .Get<Konfiguration>()
            .BindZip(_ => _filesystemManager.GetPathFor<KundenstammDaten>())
            .BindZip((_, _) => _filesystemManager.GetPathFor<UmsatzkontenListe>())
            .BindZip((_, _, _) => _filesystemManager.GetPathFor<MitarbeiterListe>());

        if (konfigurationKorrektGesetzt.IsSuccess)
        {
            var konfiguration = konfigurationKorrektGesetzt.Value;
            KonfigurationFestlegen(
                konfiguration.Item1,
                konfiguration.Item2,
                konfiguration.Item3,
                konfiguration.Item4
            );
        }
        else
        {
            await NeueKonfigurationDurchführen(_environmentManager, _filesystemManager);
        }
    }

    private async Task NeueKonfigurationDurchführen(
        EnvironmentManager environmentManager,
        FileSystemManager fileSystemManager
    )
    {
        this.Enabled = false;
        var credentialsForm = new CreateCredentials();
        credentialsForm.ShowDialog();

        var konfigurationSpeichernErgebnis = await environmentManager
            .Save(credentialsForm.Konfiguration)
            .Bind(
                () => fileSystemManager.SavePathFor<KundenstammDaten>(credentialsForm.Kundenstamm)
            )
            .Bind(
                () => fileSystemManager.SavePathFor<UmsatzkontenListe>(credentialsForm.Umsatzkonten)
            )
            .Bind(
                () => fileSystemManager.SavePathFor<MitarbeiterListe>(credentialsForm.Mitarbeiter)
            );

        if (konfigurationSpeichernErgebnis.IsFailure)
        {
            MessageBox.Show("Fehler beim Speichern der Zugangsdaten");
            Application.Exit();
        }

        KonfigurationFestlegen(
            credentialsForm.Konfiguration,
            credentialsForm.Kundenstamm,
            credentialsForm.Umsatzkonten,
            credentialsForm.Mitarbeiter
        );
        this.Enabled = true;
    }

    private void KonfigurationFestlegen(
        Konfiguration konfiguration,
        string kundenstammPfad,
        string umsatzkontenPfad,
        string mitarbeiterPfad
    )
    {
        _konfiguration = konfiguration;
        _kundenstammListePfad = kundenstammPfad;
        _kontenListePfad = umsatzkontenPfad;
        _mitarbeiterListePfad = mitarbeiterPfad;
    }

    private async Task BenutzeransichtInitialisieren()
    {
        _kontoRepository = new JsonRepository<KontoDetails>(_kontenListePfad);
        var lokaleMitarbeiterRepository = new JsonRepository<Mitarbeiter>(_mitarbeiterListePfad);
        var benutzerAnsicht = await Mitarbeiterliste.View.Erstellen(
            _kontoRepository,
            lokaleMitarbeiterRepository,
            _konfiguration
        );
        tbpMiterabeiterliste.Controls.Add(benutzerAnsicht);
        benutzerAnsicht.Dock = DockStyle.Fill;
        _mitarbeiterListe = benutzerAnsicht.MitarbeiterListe;
    }

    private async Task InitializeCustomerView()
    {
        var countries = await _lexofficeService.GetAllCountries();
        _leistungsempfänger = await Leistungsempfänger.VonDateiUndLexoffice(
            _lexofficeService,
            _kundenstammListePfad
        );
        var customerView = new Kundenstamm.View(_leistungsempfänger, countries);
        tbpDebitorNumber.Controls.Add(customerView);
        customerView.Dock = DockStyle.Fill;
    }

    private async Task InitializeAccountView()
    {
        _kontoRepository = new JsonRepository<KontoDetails>(_kontenListePfad);
        var accountControl = new View(_kontoRepository);
        spcUmsatzkontenSplit.Panel1.Controls.Add(accountControl);
        accountControl.Dock = DockStyle.Fill;

        var umsatzkontenControl = new UmsatzkontenprüfungControl(
            _environmentManager,
            _filesystemManager
        );
        spcUmsatzkontenSplit.Panel2.Controls.Add(umsatzkontenControl);
        umsatzkontenControl.Dock = DockStyle.Fill;
    }

    private void LeistungsempfaengerMitLeererDebitorenNummerAnzeigen()
    {
        var empfängerMitLeererNummer = _leistungsempfänger
            .HoleKundenListe()
            .Where(kunde => kunde.Debitorennummer == 0);

        foreach (var empfänger in empfängerMitLeererNummer)
            lview_ErkannteFehler.Items.Add(
                $"Für Leistungsempfänger '{empfänger.Kundennummer} {empfänger.DebitorName}' wurde noch keine Debitorennummer hinterlegt"
            );
    }

    private void LeistungsempfaengerAufDuplikatePruefen()
    {
        var duplikate = _leistungsempfänger
            .HoleKundenListe()
            .GroupBy(kunde => kunde.Kundennummer)
            .Where(g => g.Count() > 1)
            .Select(y => y.Key)
            .ToList();

        foreach (var duplikat in duplikate)
            lview_ErkannteFehler.Items.Add(
                $"Die Leistungsempfängernummer '{duplikat}' wurde mehrfach vergeben"
            );

        duplikate = _leistungsempfänger
            .HoleKundenListe()
            .GroupBy(kunde => kunde.Debitorennummer)
            .Where(g => g.Count() > 1)
            .Select(y => y.Key)
            .Where(number => number is not 53029 and not 0)
            .ToList();

        foreach (var duplikat in duplikate)
            lview_ErkannteFehler.Items.Add(
                $"Die Debitornummer '{duplikat}' wurde mehrfach vergeben"
            );
    }

    private async Task KontenAufDuplikatePrüfen()
    {
        var kontenListe = await _kontoRepository.List();
        var duplikate = kontenListe
            .ToList()
            .GroupBy(konto => konto.KontoNummer)
            .Where(g => g.Count() > 1)
            .Select(y => y.Key)
            .ToList();

        foreach (var duplikat in duplikate)
            lview_ErkannteFehler.Items.Add($"Die Kontonummer '{duplikat}' wurde mehrfach vergeben");
    }

    private void MitarbeiterAufDuplikatePrüfen()
    {
        var duplikate = _mitarbeiterListe
            .ToList()
            .GroupBy(mitarbeiter => mitarbeiter.Nummer)
            .Where(g => g.Count() > 1)
            .Select(y => y.Key)
            .ToList();

        foreach (var duplikat in duplikate)
            lview_ErkannteFehler.Items.Add(
                $"Die Mitarbeiternummer '{duplikat}' wurde mehrfach vergeben"
            );
    }

    private async void btnGenerateGdiExportFile_Click(object sender, EventArgs e)
    {
        btnGenerateGdiExportFile.Enabled = false;
        var pfad = await StoreGdiExport();
        btnGenerateGdiExportFile.Enabled = true;
        MessageBox.Show($"Export wurde erstellt und gespeichert. Pfad: {pfad}");
    }

    private async Task<(string Filename, byte[] FileContent, string Lines)> CreateGdiExport()
    {
        var start = DateOnly.FromDateTime(dtpStart.Value);
        var end = DateOnly.FromDateTime(dtpEnd.Value);

        var invoicesInPeriod = await LoadInvoicesInPeriod(start, end);
        var gdiInvoiceCreationResults = await ConvertInvoicesToGdi(invoicesInPeriod);

        if (gdiInvoiceCreationResults.Errors.Count > 0)
        {
            var errorList = string.Join(Environment.NewLine, gdiInvoiceCreationResults.Errors);
            MessageBox.Show(
                $@"Folgende Rechnungen konnten nicht geladen werden:{Environment.NewLine}{errorList}",
                "Warnung"
            );
        }

        DisplayInvoiceAccountStatistics(
            gdiInvoiceCreationResults.KontenNetto,
            gdiInvoiceCreationResults.Invoices.Count
        );

        var kundenListe = cbxIncludeCustomers.Checked
            ? _leistungsempfänger.HoleGdiKundenListe()
            : new List<Customer>();

        return GdiExporter.CreateExport(gdiInvoiceCreationResults.Invoices, kundenListe);
    }

    private void DisplayInvoiceAccountStatistics(Dictionary<int, decimal> dict, int invoiceAmount)
    {
        var sum = dict.Sum(d => d.Value);

        var text =
            $"Anzahl Rechnungen: {invoiceAmount} | Gesamtsumme netto: {sum:C} davon nach Konten:{Environment.NewLine}";

        foreach (var konto in dict.OrderBy(k => k.Key))
            text += $"{konto.Key}: {konto.Value:C}{Environment.NewLine}";

        lblStatistiken.Text = text;
    }

    private async Task<string> StoreGdiExport()
    {
        var (filename, fileContent, lines) = await CreateGdiExport();

        var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        var filenameOfExport = Path.Combine(desktop, filename);
        await File.WriteAllBytesAsync(filenameOfExport, fileContent);

        return filenameOfExport;
    }

    private async Task ShowGdiExport()
    {
        var (filename, fileContent, lines) = await CreateGdiExport();
        ShowExportLines(lines);
    }

    private void ShowExportLines(string export)
    {
        lview_InvoiceLines.Items.Clear();

        foreach (var line in export.Split(Environment.NewLine))
            lview_InvoiceLines.Items.Add(line);
    }

    private async Task<IImmutableList<LexofficeInvoice>> LoadInvoicesInPeriod(
        DateOnly start,
        DateOnly end
    )
    {
        var vouchersInPeriod = await _lexofficeService.GetVouchersInPeriod(start, end);

        var progress = new Progress<float>();
        var getInvoicesTask = _lexofficeService.GetInvoicesAsync(vouchersInPeriod, progress);

        Enabled = false;

        var ladeForm = new LadeForm(progress, "Rechnungen werden abgefragt");
        ladeForm.Show();

        var ergebnis = await getInvoicesTask;
        Enabled = true;

        return ergebnis;
    }

    private async Task<(
        List<GdiInvoice> Invoices,
        List<string> Errors,
        Dictionary<int, decimal> KontenNetto
    )> ConvertInvoicesToGdi(IImmutableList<LexofficeInvoice> lexOfficeInvoices)
    {
        var errors = new List<string>();
        var gdiInvoices = new List<GdiInvoice>();
        var kontenNetto = new Dictionary<int, decimal>();

        var kunden = _leistungsempfänger.HoleKundenListe();
        var konten = await _kontoRepository.List();
        var invoiceMapper = new InvoiceMapper(kunden, konten, _mitarbeiterListe);

        foreach (var invoice in lexOfficeInvoices)
        {
            var invoiceMappingErgebnis = invoiceMapper.ToGdiInvoice(invoice);

            if (invoiceMappingErgebnis.IsSuccess)
            {
                gdiInvoices.Add(invoiceMappingErgebnis.Value);

                var konto = invoiceMappingErgebnis.Value.RevenueAccountNumber;

                kontenNetto.TryAdd(konto, 0);
                kontenNetto[konto] += invoiceMappingErgebnis.Value.NetAmount;
            }
            else
            {
                var alleFehlerDieserRechnung = invoiceMappingErgebnis.Error.Split(", ");
                errors.Add(invoice.VoucherNumber);
                foreach (var fehler in alleFehlerDieserRechnung)
                    lview_ErkannteFehler.Items.Add($"{invoice.VoucherNumber} - {fehler}");
            }
        }

        return new ValueTuple<List<GdiInvoice>, List<string>, Dictionary<int, decimal>>(
            gdiInvoices,
            errors,
            kontenNetto
        );
    }

    private async void btnAnzeigen_Click(object sender, EventArgs e)
    {
        btnAnzeigen.Enabled = false;
        await ShowGdiExport();
        btnAnzeigen.Enabled = true;
        MessageBox.Show("Fertig");
    }

    private void btnLastMonth_Click(object sender, EventArgs e)
    {
        SetDateTimePickerToMonthsAgo(1);
    }

    private void btnBeforeLastMonth_Click(object sender, EventArgs e)
    {
        SetDateTimePickerToMonthsAgo(2);
    }

    private void btnTwoMonthsAgo_Click(object sender, EventArgs e)
    {
        SetDateTimePickerToMonthsAgo(3);
    }

    private void SetDateTimePickerToMonthsAgo(int months)
    {
        var today = DateTime.Today;
        var lastMonth = today.AddMonths(months * -1 + 1);
        var month = new DateTime(lastMonth.Year, lastMonth.Month, 1);
        var first = month.AddMonths(-1);
        var last = month.AddDays(-1);

        dtpStart.Value = first;
        dtpEnd.Value = last;
    }
}
