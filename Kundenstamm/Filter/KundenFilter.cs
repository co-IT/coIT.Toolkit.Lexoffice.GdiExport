using coIT.Libraries.Toolkit.Datengrundlagen.Kunden;

namespace coIT.Toolkit.Lexoffice.GdiExport.Kundenstamm.Filter
{
    internal class KundenFilter
    {
        public Dictionary<Type, IFilterKunde> AktiveFilter { get; set; } = new();

        public IEnumerable<Kunde> Anwenden(IEnumerable<Kunde> kunden)
        {
            foreach (var filter in AktiveFilter)
                kunden = filter.Value.KriteriumTrifftZu(kunden);

            return kunden;
        }

        public void SetzeFilter(IFilterKunde kundenFilter)
        {
            var filterTyp = kundenFilter.GetType();

            if (!AktiveFilter.ContainsKey(filterTyp))
                AktiveFilter.Add(filterTyp, kundenFilter);
            else
                AktiveFilter[filterTyp] = kundenFilter;
        }
    }
}
