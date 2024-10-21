using coIT.Libraries.Clockodo.TimeEntries.Contracts;
using Newtonsoft.Json.Linq;

namespace coIT.Toolkit.Lexoffice.GdiExport
{
    public class Konfiguration
    {
        public string DatabaseConnectionString { get; }
        public string LexofficeKey { get; }
        public string ClockodoMail { get; }
        public string ClockodoToken { get; }

        public Konfiguration(string databaseConnectionString, string lexofficeKey, string clockodoMail, string clockodoToken)
        {
            DatabaseConnectionString = databaseConnectionString;
            LexofficeKey = lexofficeKey;
            ClockodoMail = clockodoMail;
            ClockodoToken = clockodoToken;
        }

        public TimeEntriesServiceSettings ClockodoKonfigurationErhalten()
        {
            return new TimeEntriesServiceSettings(
                ClockodoMail,
                ClockodoToken,
                applicationName: "GdiExport",
                contactEmail: "info@co-it.eu"
            );
        }
    }
}
