using coIT.Libraries.Toolkit.Datengrundlagen.Kunden;

namespace coIT.Lexoffice.GdiExport.Kundenstamm.Filter
{
    internal class LeistungsempfängerFilter : IFilterKunde
    {
        public string Keyword { get; set; }

        public LeistungsempfängerFilter(string keyword)
        {
            Keyword = keyword;
        }

        public IEnumerable<Kunde> KriteriumTrifftZu(IEnumerable<Kunde> kunden)
        {
            return kunden.Where(kunde => kunde.Kundennummer.ToString().Contains(Keyword));
        }
    }
}
