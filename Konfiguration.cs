using coIT.Libraries.Clockodo.TimeEntries.Contracts;

namespace coIT.Toolkit.Lexoffice.GdiExport;

public class Konfiguration
{
  public Konfiguration(string databaseConnectionString, string lexofficeKey, string clockodoMail, string clockodoToken)
  {
    DatabaseConnectionString = databaseConnectionString;
    LexofficeKey = lexofficeKey;
    ClockodoMail = clockodoMail;
    ClockodoToken = clockodoToken;
  }

  public string DatabaseConnectionString { get; }
  public string LexofficeKey { get; }
  public string ClockodoMail { get; }
  public string ClockodoToken { get; }

  public TimeEntriesServiceSettings ClockodoKonfigurationErhalten()
  {
    return new TimeEntriesServiceSettings(ClockodoMail, ClockodoToken, "GdiExport", "info@co-it.eu");
  }
}
