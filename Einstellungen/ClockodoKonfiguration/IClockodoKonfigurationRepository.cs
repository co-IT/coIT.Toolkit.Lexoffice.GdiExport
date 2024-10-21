using CSharpFunctionalExtensions;

namespace coIT.Toolkit.Lexoffice.GdiExport.Einstellungen.ClockodoKonfiguration;

public interface IClockodoKonfigurationRepository
{
  public Task<Result<ClockodoEinstellungen>> Get(CancellationToken cancellationToken = default);
}
