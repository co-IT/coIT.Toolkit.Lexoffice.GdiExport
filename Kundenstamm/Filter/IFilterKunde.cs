using coIT.Libraries.Toolkit.Datengrundlagen.Kunden;

namespace coIT.Lexoffice.GdiExport.Kundenstamm.Filter
{
    internal interface IFilterKunde
    {
        public IEnumerable<Kunde> KriteriumTrifftZu(IEnumerable<Kunde> kunden);
    }
}
