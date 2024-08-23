using coIT.Libraries.Clockodo.TimeEntries.Contracts;
using coIT.Libraries.Toolkit.Datengrundlagen.Mitarbeiter;

namespace coIT.Toolkit.Lexoffice.GdiExport.Mitarbeiterliste
{
    internal static class MitarbeiterMapper
    {
        public static List<Mitarbeiter> ZuMitarbeitern(this List<UserWithTeam> clockodoBenutzer)
        {
            var adminUserId = 350599;
            return clockodoBenutzer
                .Where(user => user.Id != adminUserId)
                .Select(clockodoBenutzer => clockodoBenutzer.ZuMitarbeiter())
                .ToList();
        }

        private static Mitarbeiter ZuMitarbeiter(this UserWithTeam clockodoBenutzer)
        {
            var name = clockodoBenutzer.Name.Split(":")[1].Trim();

            return new Mitarbeiter()
            {
                Nummer = int.Parse(clockodoBenutzer.Number),
                Name = name,
                Aktiv = clockodoBenutzer.Active,
                Team = clockodoBenutzer.Team
            };
        }
    }
}
