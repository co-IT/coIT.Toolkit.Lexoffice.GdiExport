using coIT.Libraries.Gdi.Accounting.Contracts;
using coIT.Libraries.LexOffice;
using coIT.Libraries.Toolkit.Datengrundlagen.Kunden;
using coIT.Toolkit.Lexoffice.GdiExport.Helpers;

namespace coIT.Toolkit.Lexoffice.GdiExport.Kundenstamm
{
    public class Leistungsempfänger
    {
        private readonly List<Kunde> _kundenListe;
        private readonly JsonRepository<Kunde> _kundenRepository;

        public static async Task<Leistungsempfänger> VonDateiUndLexoffice(
            LexofficeService lexOfficeService,
            string kundenListePfad
        )
        {
            var kundenRepository = new JsonRepository<Kunde>(kundenListePfad);
            var lokalGespeicherteKunden = await kundenRepository.List();

            var lexOfficeKontakte = await lexOfficeService.GetContactsAsync();

            var externGespeicherteLeistungsempfänger = lexOfficeKontakte
                .Where(t => t.Role.Number is not null)
                .Where(c => c.Company is not null)
                .Select(lexOfficeContact => lexOfficeContact.ZuExportKunden())
                .ToList();

            return new Leistungsempfänger(
                lokalGespeicherteKunden,
                kundenRepository,
                externGespeicherteLeistungsempfänger
            );
        }

        private Leistungsempfänger(
            IList<Kunde> lokalGespeicherteKunden,
            JsonRepository<Kunde> kundenRepository,
            IList<Kunde> externGespeicherteLeistungsempfänger
        )
        {
            _kundenListe = ExportKundenMerger.MergenUndAnreichern(
                externGespeicherteLeistungsempfänger,
                lokalGespeicherteKunden
            );
            _kundenRepository = kundenRepository;
        }

        public List<Kunde> HoleKundenListe() => _kundenListe;

        public List<Customer> HoleGdiKundenListe()
        {
            return HoleKundenListe().ZuGdiKunden();
        }

        public void SpeichereÄnderungen()
        {
            _kundenRepository.Save(_kundenListe);
        }
    }
}
