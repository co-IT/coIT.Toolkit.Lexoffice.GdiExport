using System.Collections.Immutable;
using coIT.Libraries.ConfigurationManager;
using coIT.Libraries.ConfigurationManager.Cryptography;
using coIT.Libraries.ConfigurationManager.Serialization;
using coIT.Libraries.Gdi.Accounting;
using coIT.Libraries.Gdi.Accounting.Contracts;
using coIT.Libraries.LexOffice;
using coIT.Libraries.Toolkit.Datengrundlagen.KundenRelation;
using coIT.Libraries.Toolkit.Datengrundlagen.Mitarbeiter;
using coIT.Libraries.Toolkit.Datengrundlagen.Umsatzkonten;
using coIT.Toolkit.Lexoffice.GdiExport.Einstellungen.ClockodoKonfiguration;
using coIT.Toolkit.Lexoffice.GdiExport.Einstellungen.DatabaseKonfiguration;
using coIT.Toolkit.Lexoffice.GdiExport.Einstellungen.LexofficeKonfiguration;
using coIT.Toolkit.Lexoffice.GdiExport.Kundenstamm;
using coIT.Toolkit.Lexoffice.GdiExport.Umsatzkontenprüfung;
using CSharpFunctionalExtensions;
using GdiInvoice = coIT.Libraries.Gdi.Accounting.Contracts.Invoice;
using LexofficeInvoice = coIT.Libraries.LexOffice.DataContracts.Invoice.Invoice;
using View = coIT.Toolkit.Lexoffice.GdiExport.Umsatzkonten.View;

namespace coIT.Toolkit.Lexoffice.GdiExport;

public partial class MainForm : Form
{
  private const string ConfigEnvironmentVariableName = "COIT_TOOLKIT_DATABASE_CONNECTIONSTRING";
  private EnvironmentManager _environmentManager;

  private Konfiguration _konfiguration;
  private IKontoRepository _kontoRepository;
  private IKundeRepository _kundenRepository;

  private Leistungsempfänger _leistungsempfänger;
  private LexofficeService _lexofficeService;
  private List<Mitarbeiter> _mitarbeiterListe;
  private IMitarbeiterRepository _mitarbeiterRepository;

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
    _mitarbeiterRepository = new MitarbeiterDataTableRepository(_konfiguration.DatabaseConnectionString);

    _kundenRepository = new KundenRelationDataTableRepository(_konfiguration.DatabaseConnectionString);

    _kontoRepository = new UmsatzkontoDataTableRepository(_konfiguration.DatabaseConnectionString);

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
        "eyJJdGVtMSI6InlLdHdrUDJraEJRbTRTckpEaXFjQWpkM3pBc3NVdG8rSUNrTmFwYUgwbWs9IiwiSXRlbTIiOiJUblRxT1RUbXI3ajBCZlUwTEtnOS9BPT0ifQ=="
      )
      .Value;
    var serializationService = new NewtonsoftJsonSerializer();
    _environmentManager = new EnvironmentManager(cryptoService, serializationService);

    var databaseResult = await DatabaseEinstellungenLaden();

    if (databaseResult.IsFailure)
    {
      MessageBox.Show(
        $@"Couldn't load database settings. Make sure you have set the environment variable {ConfigEnvironmentVariableName} and it contains the correct connectionstring for the table storage."
      );
      return;
    }

    var connectionString = databaseResult.Value.ConnectionString;

    var lexOfficeResult = await LexofficeEinstellungenLaden(connectionString, cryptoService);
    var clockodoResult = await ClockodoEinstellungenLaden(connectionString, cryptoService);

    var einstellungenLadenResult = Result.Combine(clockodoResult, databaseResult, lexOfficeResult);

    if (einstellungenLadenResult.IsFailure)
    {
      MessageBox.Show(@"Couldn't load clockodo or lexoffice settings from table storage");
      return;
    }

    _konfiguration = new Konfiguration(
      connectionString,
      lexOfficeResult.Value.LexofficeKey,
      clockodoResult.Value.EmailAddress,
      clockodoResult.Value.ApiToken
    );
  }

  private async Task<Result<DatabaseEinstellungen>> DatabaseEinstellungenLaden()
  {
    return await _environmentManager
      .Get<DatabaseEinstellungen>(ConfigEnvironmentVariableName)
      .TapError(fehler =>
        MessageBox.Show(
          $"Datenbankzugang konnte nicht geladen werden: {fehler}",
          "Fehler",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error
        )
      );
  }

  private async Task<Result<LexofficeEinstellungen>> LexofficeEinstellungenLaden(
    string connectionString,
    AesCryptographyService cryptoService
  )
  {
    return await Result
      .Success(new LexofficeKonfigurationDataTableRepository(connectionString, cryptoService))
      .Bind(lexofficeRepository => lexofficeRepository.Get())
      .TapError(fehler =>
        MessageBox.Show(
          $"Lexoffice Konfiguration konnte nicht geladen werden: {fehler}",
          "Fehler",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error
        )
      );
  }

  private async Task<Result<ClockodoEinstellungen>> ClockodoEinstellungenLaden(
    string connectionString,
    AesCryptographyService cryptoService
  )
  {
    return await Result
      .Success(new ClockodoKonfigurationDataTableRepository(connectionString, cryptoService))
      .Bind(clockodoRepository => clockodoRepository.Get())
      .TapError(fehler =>
        MessageBox.Show(
          $"Clockodo Konfiguration konnte nicht geladen werden: {fehler}",
          "Fehler",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error
        )
      );
  }

  private async Task BenutzeransichtInitialisieren()
  {
    var benutzerAnsicht = await Mitarbeiterliste.View.Erstellen(
      _kontoRepository,
      _mitarbeiterRepository,
      _konfiguration
    );
    tbpMiterabeiterliste.Controls.Add(benutzerAnsicht);
    benutzerAnsicht.Dock = DockStyle.Fill;
    _mitarbeiterListe = benutzerAnsicht.MitarbeiterListe;
  }

  private async Task InitializeCustomerView()
  {
    var countries = await _lexofficeService.GetAllCountries();
    _leistungsempfänger = await Leistungsempfänger.VonDateiUndLexoffice(_lexofficeService, _kundenRepository);
    var customerView = new Kundenstamm.View(_leistungsempfänger, countries);
    tbpDebitorNumber.Controls.Add(customerView);
    customerView.Dock = DockStyle.Fill;
  }

  private async Task InitializeAccountView()
  {
    var accountControl = new View(_kontoRepository);
    spcUmsatzkontenSplit.Panel1.Controls.Add(accountControl);
    accountControl.Dock = DockStyle.Fill;

    var umsatzkontenControl = new UmsatzkontenprüfungControl(_mitarbeiterRepository, _konfiguration);
    spcUmsatzkontenSplit.Panel2.Controls.Add(umsatzkontenControl);
    umsatzkontenControl.Dock = DockStyle.Fill;
  }

  private void LeistungsempfaengerMitLeererDebitorenNummerAnzeigen()
  {
    var empfängerMitLeererNummer = _leistungsempfänger.HoleKundenListe().Where(kunde => kunde.DebitorenNummer == 0);

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
      lview_ErkannteFehler.Items.Add($"Die Leistungsempfängernummer '{duplikat}' wurde mehrfach vergeben");

    duplikate = _leistungsempfänger
      .HoleKundenListe()
      .GroupBy(kunde => kunde.DebitorenNummer)
      .Where(g => g.Count() > 1)
      .Select(y => y.Key)
      .Where(number => number is not 53029 and not 0)
      .ToList();

    foreach (var duplikat in duplikate)
      lview_ErkannteFehler.Items.Add($"Die Debitornummer '{duplikat}' wurde mehrfach vergeben");
  }

  private async Task KontenAufDuplikatePrüfen()
  {
    var kontenListe = (await _kontoRepository.GetAll()).Value;
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
      lview_ErkannteFehler.Items.Add($"Die Mitarbeiternummer '{duplikat}' wurde mehrfach vergeben");
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
      MessageBox.Show($@"Folgende Rechnungen konnten nicht geladen werden:{Environment.NewLine}{errorList}", "Warnung");
    }

    DisplayInvoiceAccountStatistics(gdiInvoiceCreationResults.KontenNetto, gdiInvoiceCreationResults.Invoices.Count);

    var kundenMitRechnung = _leistungsempfänger
      .HoleGdiKundenListe()
      .Where(kunde => gdiInvoiceCreationResults.Invoices.Any(invoice => invoice.DebitorNumber == kunde.Number));

    var kundenListe = cbxIncludeCustomers.Checked ? kundenMitRechnung : new List<Customer>();

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

  private async Task<IImmutableList<LexofficeInvoice>> LoadInvoicesInPeriod(DateOnly start, DateOnly end)
  {
    Enabled = false;

    var progress = new Progress<float>();

    var ladeForm = new LadeForm(progress, "Rechnungen werden abgefragt");
    ladeForm.Show();

    var vouchersInPeriod = await _lexofficeService.GetVouchersInPeriod(start, end);

    var ergebnis = (await _lexofficeService.GetInvoicesAsync(vouchersInPeriod, progress))
      .Where(invoice => invoice.VoucherStatus != "voided") //Ignoriere stornierte Rechnungen
      .ToImmutableList();

    ladeForm.Close();

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
    var konten = (await _kontoRepository.GetAll()).Value;
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

    return new ValueTuple<List<GdiInvoice>, List<string>, Dictionary<int, decimal>>(gdiInvoices, errors, kontenNetto);
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
