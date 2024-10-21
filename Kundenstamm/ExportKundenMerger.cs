using Azure;
using coIT.Libraries.Toolkit.Datengrundlagen.KundenRelation;

namespace coIT.Toolkit.Lexoffice.GdiExport.Kundenstamm;

internal class ExportKundenMerger
{
    private readonly IReadOnlyList<KundeRelation> _lokalGespeicherteKunden;
    private readonly IList<KundeRelation> _externGespeicherteKunden;

    public ExportKundenMerger(
        IList<KundeRelation> externGespeicherteKunden,
        IReadOnlyList<KundeRelation> lokalGespeicherteKunden
    )
    {
        _externGespeicherteKunden = externGespeicherteKunden;
        _lokalGespeicherteKunden = lokalGespeicherteKunden;
    }

    public static List<KundeRelation> MergenUndAnreichern(
        IList<KundeRelation> externGespeicherteKunden,
        IReadOnlyList<KundeRelation> lokalGespeicherteKunden
    )
    {
        var merges = new ExportKundenMerger(externGespeicherteKunden, lokalGespeicherteKunden);
        return merges.HoleMergedUndAngereicherteList();
    }

    private List<KundeRelation> HoleMergedUndAngereicherteList()
    {
        var kundenListe = new List<KundeRelation>();
        kundenListe.AddRange(HoleExterneGespeicherteKundenMitLokalenDaten());
        kundenListe.AddRange(AuflistungNurLokaleKunden());
        return kundenListe;
    }

    private List<KundeRelation> HoleExterneGespeicherteKundenMitLokalenDaten()
    {
        return _externGespeicherteKunden
            .Select(externeGespeicherteKunden =>
            {
                var lokalerKunde = _lokalGespeicherteKunden
                    .FirstOrDefault(lokaleKunden =>
                        lokaleKunden.Kundennummer == externeGespeicherteKunden.Kundennummer
                    );

                return externeGespeicherteKunden with
                {
                    DebitorenNummer = lokalerKunde?.DebitorenNummer ?? 0,
                    ETag = lokalerKunde?.ETag ?? ETag.All,
                    Timestamp = lokalerKunde?.Timestamp
                };
            })
            .ToList();
    }

    private List<KundeRelation> AuflistungNurLokaleKunden()
    {
        return  _lokalGespeicherteKunden
            .Where(lokalGespeicherteKunden =>
                KundeIstExternGespeichert(lokalGespeicherteKunden) is false
            )
            .ToList();
    }

    private bool KundeIstExternGespeichert(KundeRelation lokaleKunden)
    {
        return _externGespeicherteKunden.Any(lexofficeCustomer =>
            lexofficeCustomer.Kundennummer == lokaleKunden.Kundennummer
        );
    }
}
