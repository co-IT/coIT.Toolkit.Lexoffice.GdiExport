using System.Collections.Immutable;
using coIT.Lexoffice.GdiExport.Helpers;
using coIT.Libraries.Clockodo.TimeEntries;
using coIT.Libraries.Clockodo.TimeEntries.Contracts;
using coIT.Libraries.LexOffice;
using coIT.Libraries.LexOffice.DataContracts.Invoice;
using coIT.Libraries.Toolkit.Datengrundlagen.Konten;
using coIT.Libraries.Toolkit.Datengrundlagen.Mitarbeiter;
using coIT.Libraries.WinForms;

namespace coIT.Lexoffice.GdiExport.Mitarbeiterliste
{
    internal partial class View : UserControl
    {
        private readonly JsonRepository<KontoDetails> _kontorepository;
        private readonly JsonRepository<Mitarbeiter> _lokaleMitarbeiterRepository;

        private TimeEntriesService _clockodoservice;
        private List<Mitarbeiter> _mitarbeiter;
        private Konfiguration _konfiguration;

        public List<Mitarbeiter> MitarbeiterListe => _mitarbeiter;

        public static async Task<View> Erstellen(
            JsonRepository<KontoDetails> kontorepository,
            JsonRepository<Mitarbeiter> lokaleMitarbeiterRepository,
            Konfiguration konfiguration
        )
        {
            var view = new View(kontorepository, lokaleMitarbeiterRepository, konfiguration);
            view._mitarbeiter = await view.MitarbeiterListeAbfragen();
            return view;
        }

        private View(
            JsonRepository<KontoDetails> kontorepository,
            JsonRepository<Mitarbeiter> lokaleMitarbeiterRepository,
            Konfiguration konfiguration
        )
        {
            InitializeComponent();
            _kontorepository = kontorepository;
            _lokaleMitarbeiterRepository = lokaleMitarbeiterRepository;
            _konfiguration = konfiguration;

            var credentials = _konfiguration.ClockodoKonfigurationErhalten();
            _clockodoservice = new TimeEntriesService(credentials);
        }

        private async void View_Load(object sender, EventArgs e)
        {
            MitarbeiterListeLaden();

            TeamListeInitialisieren();

            await KontoListeInitialisieren();
        }

        private void MitarbeiterListeLaden()
        {
            dgvMitarbeiter.ConfigureWithDefaultBehaviour();
            dgvMitarbeiter.DataSource = new SortableBindingList<Mitarbeiter>(_mitarbeiter);
        }

        public async Task<List<Mitarbeiter>> MitarbeiterListeAbfragen()
        {
            var clockodoMitarbeiter = (await _clockodoservice.GetAllUsers())
                .ToList()
                .ZuMitarbeitern();
            var lokaleMitarbeiter = await _lokaleMitarbeiterRepository.List();

            clockodoMitarbeiter.AddRange(lokaleMitarbeiter);

            return clockodoMitarbeiter;
        }

        private void TeamListeInitialisieren()
        {
            var teams = _mitarbeiter.Select(mitarbeiter => mitarbeiter.Team).Distinct().ToList();

            foreach (var team in teams)
                cbxTeam.Items.Add(team);

            cbxTeam.SelectedIndex = 0;
        }

        private async Task KontoListeInitialisieren()
        {
            var kontoDetails = await _kontorepository.List();
            var kontoDetailsSortiert = kontoDetails.OrderBy(konto => konto.KontoNummer);

            foreach (var konto in kontoDetailsSortiert)
                cbxKonto.Items.Add(konto);

            cbxKonto.SelectedIndex = 0;
        }

        private async void btnBerechnen_Click(object sender, EventArgs e)
        {
            btnBerechnen.Enabled = false;

            var start = DateOnly.FromDateTime(dtpStart.Value);
            var ende = DateOnly.FromDateTime(dtpEnde.Value);
            var ausgewähltesKonto = (KontoDetails)cbxKonto.SelectedItem;

            var team = (Team)cbxTeam.SelectedItem;
            var mitarbeiterNummernInAusgewähltenTeam = NummernAusgewählterMitarbeiterErhalten(team);

            AusgabefelderZurücksetzen();

            var nettoErlös = await NettoErlösFürTeamUndZeitraumBerechnen(
                start,
                ende,
                ausgewähltesKonto,
                mitarbeiterNummernInAusgewähltenTeam,
                _konfiguration.LexofficeKey
            );

            var aufgewendeteStunden = await AufgewendeteStundenFürTeamUndZeitraumBerechnen(
                start,
                ende,
                ausgewähltesKonto,
                mitarbeiterNummernInAusgewähltenTeam
            );

            var stundenSatz =
                aufgewendeteStunden != 0 ? nettoErlös / aufgewendeteStunden : nettoErlös;

            nbxStundenanzahl.Value = aufgewendeteStunden;
            nbxUmsatz.Value = nettoErlös;
            nbxStundenlohn.Value = stundenSatz;

            btnBerechnen.Enabled = true;
        }

        private async Task<decimal> AufgewendeteStundenFürTeamUndZeitraumBerechnen(
            DateOnly start,
            DateOnly ende,
            KontoDetails ausgewähltesKonto,
            List<int> mitarbeiterNummernInAusgewähltenTeam
        )
        {
            var period = ClockodoPeriod.Create(start, ende);
            var zeiteinträge = await _clockodoservice.GetTimeEntriesAsync(period.Value);

            var mitarbeiterNummernAlsString = mitarbeiterNummernInAusgewähltenTeam.Select(nummer =>
                nummer.ToString()
            );

            return zeiteinträge
                    .Where(zeiteintrag =>
                        zeiteintrag.ServicesName == ausgewähltesKonto.KontoNummer.ToString()
                    )
                    .Where(zeiteintrag =>
                        TextEnthältElementAusListe(
                            zeiteintrag.EmployeeName,
                            mitarbeiterNummernAlsString
                        )
                    )
                    .Where(zeiteintrag =>
                        zeiteintrag.BillStatus
                            is BillStatus.Abrechenbar
                                or BillStatus.BereitsAbgerechnet
                    )
                    .Sum(zeiteintrag => zeiteintrag.Duration) / (60 * 60);
        }

        private static async Task<decimal> NettoErlösFürTeamUndZeitraumBerechnen(
            DateOnly start,
            DateOnly ende,
            KontoDetails ausgewähltesKonto,
            List<int> mitarbeiterNummernInAusgewähltenTeam,
            string key
        )
        {
            var rechnungsZeilen = await RechnungsZeilenInZeitraumAbfragen(start, ende, key);

            var rechnungsZeilenAufAusgewähltemKonto = RechnungsZeilenNachKontoFiltern(
                rechnungsZeilen,
                ausgewähltesKonto
            );

            var rechnungsZeilenMitAusgewähltemKontoUndTeam =
                RechnungsZeilenNachMitarbeiterNummernFiltern(
                    rechnungsZeilenAufAusgewähltemKonto,
                    mitarbeiterNummernInAusgewähltenTeam
                );

            return NettoErlösAllesRechnungsZeilen(rechnungsZeilenMitAusgewähltemKontoUndTeam);
        }

        private static decimal NettoErlösAllesRechnungsZeilen(
            List<InvoiceLineItem> rechnungsZeilenMitAusgewähltemKontoUndTeam
        )
        {
            return rechnungsZeilenMitAusgewähltemKontoUndTeam.Sum(rechnungsZeile =>
                rechnungsZeile.Quantity
                * rechnungsZeile.UnitPrice.NetAmount
                * (100 - rechnungsZeile.DiscountPercentage)
                / 100
            );
        }

        private static List<InvoiceLineItem> RechnungsZeilenNachMitarbeiterNummernFiltern(
            List<InvoiceLineItem> rechnungsZeilenAufAusgewähltemKonto,
            List<int> mitarbeiterNummernInAusgewähltenTeam
        )
        {
            var mitarbeiterNummernAlsString = mitarbeiterNummernInAusgewähltenTeam.Select(nummer =>
                nummer.ToString()
            );

            var rechnungsZeilenMitAusgewähltemKontoUndTeam = rechnungsZeilenAufAusgewähltemKonto
                .Where(rechnungsZeile =>
                    TextEnthältElementAusListe(rechnungsZeile.Name, mitarbeiterNummernAlsString)
                )
                .ToList();
            return rechnungsZeilenMitAusgewähltemKontoUndTeam;
        }

        private List<int> NummernAusgewählterMitarbeiterErhalten(Team team)
        {
            var mitarbeiterNummernInAusgewähltenTeam = _mitarbeiter
                .Where(mitarbeiter => mitarbeiter.Team.Id == team.Id)
                .Select(mitarbeiter => mitarbeiter.Nummer)
                .ToList();
            return mitarbeiterNummernInAusgewähltenTeam;
        }

        private static List<InvoiceLineItem> RechnungsZeilenNachKontoFiltern(
            List<InvoiceLineItem> rechnungsZeilen,
            KontoDetails ausgewähltesKonto
        )
        {
            var rechnungsZeilenAufAusgewähltemKonto = rechnungsZeilen
                .Where(rechnungsZeile =>
                    rechnungsZeile.Name.Contains(ausgewähltesKonto.KontoNummer.ToString())
                )
                .ToList();
            return rechnungsZeilenAufAusgewähltemKonto;
        }

        private static async Task<List<InvoiceLineItem>> RechnungsZeilenInZeitraumAbfragen(
            DateOnly start,
            DateOnly ende,
            string key
        )
        {
            var lexofficeService = new LexofficeService(key);
            var belege = await lexofficeService.GetVouchersInPeriod(start, ende);
            var rechnungen = await lexofficeService.GetInvoicesAsync(belege);

            var rechnungsZeilen = rechnungen
                .SelectMany(rechnungen => rechnungen.LineItems)
                .ToList();
            return rechnungsZeilen;
        }

        private void AusgabefelderZurücksetzen()
        {
            nbxStundenanzahl.Value = 0;
            nbxStundenlohn.Value = 0;
            nbxUmsatz.Value = 0;
        }

        public static bool TextEnthältElementAusListe(string haystack, IEnumerable<string> needles)
        {
            return needles.Any(needle => haystack.Contains(needle));
        }
    }
}
