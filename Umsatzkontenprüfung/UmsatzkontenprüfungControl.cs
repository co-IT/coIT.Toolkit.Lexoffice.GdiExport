using System.Data;
using coIT.Libraries.Clockodo.TimeEntries;
using coIT.Libraries.Clockodo.TimeEntries.Contracts;
using coIT.Libraries.ConfigurationManager;
using coIT.Libraries.Gdi.Accounting;
using coIT.Libraries.Gdi.Accounting.Contracts;
using coIT.Libraries.LexOffice;
using coIT.Libraries.LexOffice.DataContracts.Contacts;
using coIT.Libraries.Toolkit.Datengrundlagen.Mitarbeiter;
using coIT.Libraries.WinForms.DateTimeButtons;
using coIT.Toolkit.Lexoffice.GdiExport;
using coIT.Toolkit.Lexoffice.GdiExport.Umsatzkontenprüfung;
using coIT.Toolkit.Lexoffice.GdiExport.Umsatzkontenprüfung.LexofficeCaching;
using CSharpFunctionalExtensions;
using LexOfficeInvoice = coIT.Libraries.LexOffice.DataContracts.Invoice.Invoice;

namespace coIT.Lexoffice.GdiExport.Umsatzkontenprüfung
{
    internal partial class UmsatzkontenprüfungControl : UserControl
    {
        private readonly EnvironmentManager _environmentManager;
        private readonly FileSystemManager _fileSystemManager;

        internal UmsatzkontenprüfungControl(
            EnvironmentManager environmentManager,
            FileSystemManager fileSystemManager
        )
        {
            InitializeComponent();
            _environmentManager = environmentManager;
            _fileSystemManager = fileSystemManager;
        }

        private async void btnAbfragen_Click(object sender, EventArgs e)
        {
            await UmsatzAbfragenKlick();
        }

        private void InitiiereStandardAbfragezeitraum()
        {
            var jetzt = DateTime.Now;

            var endeDesLetztenMonats = jetzt.GetFirstDayInMonth().AddDays(-1);
            var anfangDesMonatesVor6Monaten = endeDesLetztenMonats
                .AddMonths(-5)
                .GetFirstDayInMonth();

            dtpZeitraumStart.Value = anfangDesMonatesVor6Monaten;
            dtpZeitraumEnde.Value = endeDesLetztenMonats;
        }

        private (DateOnly Von, DateOnly Bis) ZeitraumAuslesen()
        {
            var anfang = dtpZeitraumStart.Value;
            var ende = dtpZeitraumEnde.Value;

            return (anfang.ToDateOnly(), ende.ToDateOnly());
        }

        private async void UmsatzkontenprüfungControl_Load(object sender, EventArgs e)
        {
            tvErgebnis.Font = new Font(FontFamily.GenericMonospace, tvErgebnis.Font.Size);
            btnCsvAuswählen.Enabled = false;

            InitiiereStandardAbfragezeitraum();
        }

        private async Task UmsatzAbfragenKlick()
        {
            ButtonsBlockieren(true);

            var zeitraum = ZeitraumAuslesen();
            var cacheAktualisieren = cbxCacheNeuladen.Checked;

            var ergebnis = await KundenUndRechnungenLaden(zeitraum, cacheAktualisieren)
                .BindZip(tuple => MitarbeiterLaden())
                .Tap(tuple =>
                    kundeMitarbeiterView.Aktualisieren(
                        tuple.First.Rechnungen,
                        tuple.First.Kunden,
                        tuple.Second
                    )
                )
                .Map(tuple => UmsatzlisteErstellen(tuple.First.Kunden, tuple.First.Rechnungen))
                .Tap(UmsätzeAnzeigen)
                .Tap(umsatzkontoKundeView.Aktualisieren)
                .Tap(kundeUmsatzkontoView.Aktualisieren);

            if (ergebnis.IsFailure)
                MessageBox.Show(
                    ergebnis.Error,
                    "Berechnung fehlgeschlagen",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

            ButtonsBlockieren(false);
        }

        private async Task<Result<MitarbeiterListe>> MitarbeiterLaden()
        {
            return await _environmentManager
                .Get<Konfiguration>()
                .Map(einstellungen => new TimeEntriesService(
                    einstellungen.ClockodoKonfigurationErhalten()
                ))
                .Map((clockodoService) => clockodoService.GetAllUsers())
                .Map((clockodoMitarbeiter) => clockodoMitarbeiter.ToList())
                .BindZip((_) => _fileSystemManager.Get<MitarbeiterListe>())
                .Map(
                    (
                        (
                            List<UserWithTeam> ClockodoMitarbeiter,
                            MitarbeiterListe MitarbeiterListe
                        ) ergebnisse
                    ) =>
                        ergebnisse.MitarbeiterListe.ClockodoMitarbeiterHinzufügen(
                            ergebnisse.ClockodoMitarbeiter
                        )
                );
        }

        private void ButtonsBlockieren(bool blockieren)
        {
            btnAbfragen.Enabled = !blockieren;
            btnCsvAuswählen.Enabled = !blockieren;
        }

        private async Task<
            Result<(List<ContactInformation> Kunden, List<LexOfficeInvoice> Rechnungen)>
        > KundenUndRechnungenLaden((DateOnly Von, DateOnly Bis) zeitraum, bool cacheAktualisieren)
        {
            return await _environmentManager
                .Get<Konfiguration>()
                .Map(konfiguration => new LexofficeService(konfiguration.LexofficeKey))
#if DEBUG
                .Map(ErweiterterDateisystemCache.LadeCacheAusLokalerDatei)
#else
                .Map(service => new TagesbasierterCache(service))
#endif
                .Map(async cache =>
                {
                    var kunden = await cache.KundenAbfragen(cacheAktualisieren);
                    var rechnungen = await cache.RechnungenAbfragen(zeitraum, cacheAktualisieren);
#if DEBUG
                    await cache.LokalenCacheErzeugen();
#endif
                    return (kunden, rechnungen);
                });
        }

        private void UmsätzeAnzeigen(IEnumerable<VersendeteRechnung> umsätze)
        {
            var nachKontoGruppierteZeilen = umsätze
                .GroupBy(zeile => zeile.Umsatzkonto)
                .OrderBy(gruppe => gruppe.Key)
                .Select(gruppe => new
                {
                    Umsatzkonto = gruppe.Key,
                    Rechnungen = gruppe.OrderBy(r => r.Datum),
                });

            tvErgebnis.Invoke(() =>
            {
                tvErgebnis.BeginUpdate();

                tvErgebnis.Nodes.Clear();

                var derzeitigesKonto = 0;
                foreach (var kontoMitRechnugen in nachKontoGruppierteZeilen)
                {
                    var kontoSummeNetto = kontoMitRechnugen.Rechnungen.Sum(rechnung =>
                        rechnung.Netto
                    );
                    var kontoSummeBrutto = kontoMitRechnugen.Rechnungen.Sum(rechnung =>
                        rechnung.Brutto
                    );

                    var kontoText =
                        $"{kontoMitRechnugen.Umsatzkonto}: {kontoSummeNetto:C2} | {kontoSummeBrutto:C2}";

                    tvErgebnis.Nodes.Add(kontoText);

                    foreach (var rechnung in kontoMitRechnugen.Rechnungen)
                    {
                        tvErgebnis.Nodes[derzeitigesKonto].Nodes.Add(rechnung.ToString());
                    }

                    derzeitigesKonto++;
                }

                tvErgebnis.EndUpdate();
            });
        }

        private static int LängsterKundenname(List<ContactInformation> kunden) =>
            kunden.Max(kunde => kunde?.Company?.Name?.Length ?? 0);

        private static List<VersendeteRechnung> UmsatzlisteErstellen(
            List<ContactInformation> kunden,
            List<LexOfficeInvoice> rechnungen
        )
        {
            var längsterKundenName = LängsterKundenname(kunden);
            return rechnungen
                .Select(rechnung =>
                {
                    var kundenname =
                        kunden
                            .SingleOrDefault(kunde => kunde.Id == rechnung.Address.ContactId)
                            ?.Company?.Name ?? string.Empty;

                    return new VersendeteRechnung
                    {
                        Umsatzkonto = rechnung.KontoErmitteln().Value,
                        Datum = DateTime.Parse(rechnung.VoucherDate).ToDateOnly(),
                        Kundenname = kundenname,
                        KundennameLänge = längsterKundenName,
                        Nummer = rechnung.VoucherNumber,
                        Netto = rechnung.TotalPrice.TotalNetAmount,
                        Brutto = rechnung.TotalPrice.TotalGrossAmount,
                    };
                })
                .ToList();
        }

        private async void btnCsvAuswählen_Click(object sender, EventArgs e)
        {
            if (dlgCsvÖffnen.ShowDialog() != DialogResult.OK)
                return;

            var dateiPfad = dlgCsvÖffnen.FileName;
            tbxCsvPfad.Text = Path.GetFileName(dateiPfad);

            var buchungenEinlesenErgebnis = await UmsatzParser.ParseCsv(dateiPfad);

            if (buchungenEinlesenErgebnis.IsFailure)
            {
                MessageBox.Show(
                    "Fehler beim Einlesen der csv Datei",
                    "Fehlgeschlagen",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            ButtonsBlockieren(true);

            var buchungen = buchungenEinlesenErgebnis.Value.ToList();

            buchungen = DienstfahrzeugUmsätzeFiltern(buchungen);

            var ergebnis = await KundenUndRechnungenLaden(
                    ZeitraumAuslesen(),
                    cbxCacheNeuladen.Checked
                )
                .Map(tuple => UmsatzlisteErstellen(tuple.Kunden, tuple.Rechnungen))
                .Map(gestellteRechnungen =>
                    AbgleichBuchhaltung.FindeAbweichungenZuRechnungen(
                        buchungen,
                        gestellteRechnungen
                    )
                )
                .Tap(AbweichungenAnzeigen);

            if (ergebnis.IsFailure)
                MessageBox.Show(
                    ergebnis.Error,
                    "Berechnung fehlgeschlagen",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

            ButtonsBlockieren(false);
        }

        private List<SaleBooking> DienstfahrzeugUmsätzeFiltern(List<SaleBooking> buchungen)
        {
            return buchungen.Where(buchung => buchung.AccountNumber != 8611).ToList();
        }

        private void AbweichungenAnzeigen(IList<Abweichung> abweichungen)
        {
            var nachFehlerGruppierteAbweichungen = abweichungen
                .GroupBy(zeile => zeile.Ergebnis)
                .OrderBy(gruppe => gruppe.Key)
                .Select(gruppe => new { Ergebnis = gruppe.Key, Abweichungen = gruppe });

            tvErgebnis.Invoke(() =>
            {
                tvErgebnis.BeginUpdate();

                tvErgebnis.Nodes.Clear();

                var derzeitigesErgebnis = 0;
                foreach (var abweichungenFürErgebnis in nachFehlerGruppierteAbweichungen)
                {
                    tvErgebnis.Nodes.Add(abweichungenFürErgebnis.Ergebnis);

                    foreach (var rechnung in abweichungenFürErgebnis.Abweichungen)
                    {
                        tvErgebnis
                            .Nodes[derzeitigesErgebnis]
                            .Nodes.Add($"{rechnung.Rechnungsnr}: {rechnung.Fehler}");
                    }

                    derzeitigesErgebnis++;
                }

                tvErgebnis.EndUpdate();
            });
        }
    }
}
