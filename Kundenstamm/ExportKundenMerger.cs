using coIT.Libraries.Toolkit.Datengrundlagen.Kunden;

namespace coIT.Toolkit.Lexoffice.GdiExport.Kundenstamm;

internal class ExportKundenMerger
{
    private readonly IList<Kunde> _lokalGespeicherteKunden;
    private readonly IList<Kunde> _externGespeicherteKunden;

    public ExportKundenMerger(
        IList<Kunde> externGespeicherteKunden,
        IList<Kunde> lokalGespeicherteKunden
    )
    {
        _externGespeicherteKunden = externGespeicherteKunden;
        _lokalGespeicherteKunden = lokalGespeicherteKunden;
    }

    public static List<Kunde> MergenUndAnreichern(
        IList<Kunde> externGespeicherteKunden,
        IList<Kunde> lokalGespeicherteKunden
    )
    {
        var merges = new ExportKundenMerger(externGespeicherteKunden, lokalGespeicherteKunden);
        return merges.HoleMergedUndAngereicherteList();
    }

    private List<Kunde> HoleMergedUndAngereicherteList()
    {
        var kundenListe = new List<Kunde>();
        kundenListe.AddRange(HoleExterneGespeicherteKundenMitLokalenDaten());
        kundenListe.AddRange(AuflistungNurLokaleKunden());
        return kundenListe;
    }

    private List<Kunde> HoleExterneGespeicherteKundenMitLokalenDaten()
    {
        return _externGespeicherteKunden
            .Select(externeGespeicherteKunden =>
                externeGespeicherteKunden.MitDebitorennummer(
                    VersucheDebitorennummerZuHolen(externeGespeicherteKunden)
                )
            )
            .ToList();
    }

    private List<Kunde> AuflistungNurLokaleKunden()
    {
        return _lokalGespeicherteKunden
            .Where(lokalGespeicherteKunden =>
                KundeIstExternGespeichert(lokalGespeicherteKunden) is false
            )
            .ToList();
    }

    private bool KundeIstExternGespeichert(Kunde lokaleKunden)
    {
        return _externGespeicherteKunden.Any(lexofficeCustomer =>
            lexofficeCustomer.Kundennummer == lokaleKunden.Kundennummer
        );
    }

    private int VersucheDebitorennummerZuHolen(Kunde externGespeicherteKunden)
    {
        return _lokalGespeicherteKunden
                .FirstOrDefault(lokaleKunden =>
                    lokaleKunden.Kundennummer == externGespeicherteKunden.Kundennummer
                )
                ?.Debitorennummer ?? 0;
    }
}
