using coIT.Libraries.Toolkit.Datengrundlagen.KundenRelation;

namespace coIT.Toolkit.Lexoffice.GdiExport.Kundenstamm.Filter
{
    internal interface IFilterKunde
    {
        public IEnumerable<KundeRelation> KriteriumTrifftZu(IEnumerable<KundeRelation> kunden);
    }
}
