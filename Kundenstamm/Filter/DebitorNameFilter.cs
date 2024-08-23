using coIT.Libraries.Toolkit.Datengrundlagen.Kunden;

namespace coIT.Toolkit.Lexoffice.GdiExport.Kundenstamm.Filter
{
    internal class DebitorNameFilter : IFilterKunde
    {
        public string Keyword { get; set; }

        public DebitorNameFilter(string keyword)
        {
            Keyword = keyword;
        }

        public IEnumerable<Kunde> KriteriumTrifftZu(IEnumerable<Kunde> kunden)
        {
            return kunden.Where(kunde =>
                kunde.DebitorName.Contains(Keyword, StringComparison.OrdinalIgnoreCase)
            );
        }
    }
}
