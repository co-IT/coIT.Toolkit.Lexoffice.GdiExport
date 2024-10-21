using coIT.Libraries.ConfigurationManager.Cryptography;
using CSharpFunctionalExtensions;

namespace coIT.Toolkit.Lexoffice.GdiExport.Einstellungen.LexofficeKonfiguration;

internal class LexofficeKonfigurationMapper
{
  private readonly IDoCryptography _cryptographyService;

  public LexofficeKonfigurationMapper(IDoCryptography cryptographyService)
  {
    _cryptographyService = cryptographyService;
  }

  public Result<LexofficeEinstellungen> VonEntity(LexofficeKonfigurationEntity entity)
  {
    return _cryptographyService
      .Decrypt(entity.LexofficeKey)
      .Map((Func<string, LexofficeEinstellungen>)(key => new LexofficeEinstellungen { LexofficeKey = key }));
  }
}
