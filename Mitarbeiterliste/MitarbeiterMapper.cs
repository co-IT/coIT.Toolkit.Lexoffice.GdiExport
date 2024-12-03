using Azure;
using coIT.Libraries.Clockodo.TimeEntries.Contracts;
using coIT.Libraries.Toolkit.Datengrundlagen.Mitarbeiter;
using Team = coIT.Libraries.Toolkit.Datengrundlagen.Mitarbeiter.Team;

namespace coIT.Toolkit.Lexoffice.GdiExport.Mitarbeiterliste;

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

    return new Mitarbeiter(
      int.Parse(clockodoBenutzer.Number),
      name,
      clockodoBenutzer.Active,
      new Team { Id = clockodoBenutzer.Team.Id, Name = clockodoBenutzer.Team.Name },
      null,
      ETag.All
    );
  }
}
