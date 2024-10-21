
using coIT.Libraries.Toolkit.Datengrundlagen.KundenRelation;

namespace coIT.Toolkit.Lexoffice.GdiExport.Kundenstamm.Filter
{
    internal class DebitorNummerFilter : IFilterKunde
    {
        public string Keyword { get; set; }

        public DebitorNummerFilter(string keyword)
        {
            Keyword = keyword;
        }

        public IEnumerable<KundeRelation> KriteriumTrifftZu(IEnumerable<KundeRelation> kunden)
        {
            return kunden.Where(kunde => kunde.DebitorenNummer.ToString().Contains(Keyword));
        }
    }
}
