using coIT.Libraries.Toolkit.Datengrundlagen.KundenRelation;

namespace coIT.Toolkit.Lexoffice.GdiExport.Kundenstamm.Filter;

internal class LeistungsempfängerFilter : IFilterKunde
{
  public LeistungsempfängerFilter(string keyword)
  {
    Keyword = keyword;
  }

  public string Keyword { get; set; }

  public IEnumerable<KundeRelation> KriteriumTrifftZu(IEnumerable<KundeRelation> kunden)
  {
    return kunden.Where(kunde => kunde.Kundennummer.ToString().Contains(Keyword));
  }
}
