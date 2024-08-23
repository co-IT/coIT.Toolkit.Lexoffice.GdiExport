using coIT.Libraries.Clockodo.TimeEntries.Contracts;
using Newtonsoft.Json.Linq;

namespace coIT.Lexoffice.GdiExport
{
    public class Konfiguration
    {
        public string LexofficeKey { get; }
        public string ClockodoMail { get; }
        public string ClockodoToken { get; }

        public Konfiguration(string lexofficeKey, string clockodoMail, string clockodoToken)
        {
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
