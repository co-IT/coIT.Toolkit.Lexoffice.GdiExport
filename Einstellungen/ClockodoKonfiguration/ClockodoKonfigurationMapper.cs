using coIT.Libraries.ConfigurationManager.Cryptography;
using CSharpFunctionalExtensions;

namespace coIT.Toolkit.Lexoffice.GdiExport.Einstellungen.ClockodoKonfiguration;

internal class ClockodoKonfigurationMapper
{
  private readonly IDoCryptography _cryptographyService;

  public ClockodoKonfigurationMapper(IDoCryptography cryptographyService)
  {
    _cryptographyService = cryptographyService;
  }

  public Result<ClockodoEinstellungen> VonEntity(ClockodoKonfigurationEntity entity)
  {
    return _cryptographyService
      .Decrypt(entity.ApiToken)
      .Map(apiToken => new ClockodoEinstellungen { ApiToken = apiToken, EmailAddress = entity.EmailAddress, BaseAddress = entity.BaseAddress });
  }
}
