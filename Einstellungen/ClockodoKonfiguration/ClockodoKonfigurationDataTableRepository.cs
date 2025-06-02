using Azure;
using Azure.Data.Tables;
using coIT.Libraries.ConfigurationManager.Cryptography;
using CSharpFunctionalExtensions;

namespace coIT.Toolkit.Lexoffice.GdiExport.Einstellungen.ClockodoKonfiguration;

public class ClockodoKonfigurationDataTableRepository : IClockodoKonfigurationRepository
{
  private readonly ClockodoKonfigurationMapper _mapper;
  private readonly TableClient _tableClient;

  public ClockodoKonfigurationDataTableRepository(string connectionString, IDoCryptography cryptographyService)
  {
    _mapper = new ClockodoKonfigurationMapper(cryptographyService);
    _tableClient = new TableClient(connectionString, ClockodoKonfigurationEntity.TabellenName);
  }

  public async Task<Result<ClockodoEinstellungen>> Get(CancellationToken cancellationToken = default)
  {
    try
    {
      return await Result
        .Success()
        .Map(() =>
          _tableClient.GetEntityIfExistsAsync<ClockodoKonfigurationEntity>(
            ClockodoKonfigurationEntity.TabellenName,
            ClockodoKonfigurationEntity.GlobalIdentifier,
            cancellationToken: cancellationToken
          )
        )
        .Ensure(
          response => response.HasValue,
          $"Der Eintrag mit dem Namen '{ClockodoKonfigurationEntity.GlobalIdentifier}' konnte nicht gefunden werden."
        )
        .Map(response => response.Value)
        .Bind(_mapper.VonEntity!);
    }
    catch (Exception ex) when (ex is RequestFailedException or InvalidOperationException)
    {
      return Result.Failure<ClockodoEinstellungen>(ex.Message);
    }
  }
}
