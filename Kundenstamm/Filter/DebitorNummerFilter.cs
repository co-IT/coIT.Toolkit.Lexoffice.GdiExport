using coIT.Libraries.Toolkit.Datengrundlagen.Kunden;

namespace coIT.Lexoffice.GdiExport.Kundenstamm.Filter
{
    internal class DebitorNummerFilter : IFilterKunde
    {
        public string Keyword { get; set; }

        public DebitorNummerFilter(string keyword)
        {
            Keyword = keyword;
        }

        public IEnumerable<Kunde> KriteriumTrifftZu(IEnumerable<Kunde> kunden)
        {
            return kunden.Where(kunde => kunde.Debitorennummer.ToString().Contains(Keyword));
        }
    }
}
