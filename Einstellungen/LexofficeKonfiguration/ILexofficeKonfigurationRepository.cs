using CSharpFunctionalExtensions;

namespace coIT.Toolkit.Lexoffice.GdiExport.Einstellungen.LexofficeKonfiguration;

public interface ILexofficeKonfigurationRepository
{
  public Task<Result<LexofficeEinstellungen>> Get(CancellationToken cancellationToken = default);
}
