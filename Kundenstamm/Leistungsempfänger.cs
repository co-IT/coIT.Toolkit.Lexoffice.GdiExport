using coIT.Libraries.Gdi.Accounting.Contracts;
using coIT.Libraries.LexOffice;
using coIT.Libraries.Toolkit.Datengrundlagen.KundenRelation;
using CSharpFunctionalExtensions;

namespace coIT.Toolkit.Lexoffice.GdiExport.Kundenstamm
{
    public class Leistungsempfänger
    {
        private readonly List<KundeRelation> _kundenListe;
        private readonly IKundeRepository _kundenRepository;

        public static async Task<Leistungsempfänger> VonDateiUndLexoffice(
            LexofficeService lexOfficeService,
            IKundeRepository kundenRepository
        )
        {
            var lokalGespeicherteKunden = (await kundenRepository.GetAll()).Value;

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
            IReadOnlyList<KundeRelation> lokalGespeicherteKunden,
            IKundeRepository kundenRepository,
            IList<KundeRelation> externGespeicherteLeistungsempfänger
        )
        {
            _kundenListe = ExportKundenMerger.MergenUndAnreichern(
                externGespeicherteLeistungsempfänger,
                lokalGespeicherteKunden
            );
            _kundenRepository = kundenRepository;
        }

        public List<KundeRelation> HoleKundenListe() => _kundenListe;

        public List<Customer> HoleGdiKundenListe()
        {
            return HoleKundenListe().ZuGdiKunden();
        }

        public async Task<Result> UpdateKunde(KundeRelation kunde)
        {
            return await _kundenRepository.UpsertAsync(kunde);
        }
    }
}
