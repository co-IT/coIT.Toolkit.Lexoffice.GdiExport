using Azure;
using Azure.Data.Tables;
using coIT.Libraries.ConfigurationManager.Cryptography;
using CSharpFunctionalExtensions;

namespace coIT.Toolkit.Lexoffice.GdiExport.Einstellungen.LexofficeKonfiguration;

public class LexofficeKonfigurationDataTableRepository : ILexofficeKonfigurationRepository
{
  private readonly LexofficeKonfigurationMapper _mapper;
  private readonly TableClient _tableClient;

  public LexofficeKonfigurationDataTableRepository(string connectionString, IDoCryptography cryptographyService)
  {
    _mapper = new LexofficeKonfigurationMapper(cryptographyService);
    _tableClient = new TableClient(connectionString, LexofficeKonfigurationEntity.TabellenName);
  }

  public async Task<Result<LexofficeEinstellungen>> Get(CancellationToken cancellationToken = default)
  {
    try
    {
      return await Result
        .Success()
        .Map(() =>
          _tableClient.GetEntityIfExistsAsync<LexofficeKonfigurationEntity>(
            LexofficeKonfigurationEntity.TabellenName,
            LexofficeKonfigurationEntity.GlobalIdentifier,
            cancellationToken: cancellationToken
          )
        )
        .Ensure(
          response => response.HasValue,
          $"Der Eintrag mit dem Namen '{LexofficeKonfigurationEntity.GlobalIdentifier}' konnte nicht gefunden werden."
        )
        .Map(response => response.Value)
        .Bind(_mapper.VonEntity!);
    }
    catch (Exception ex) when (ex is RequestFailedException or InvalidOperationException)
    {
      return Result.Failure<LexofficeEinstellungen>(ex.Message);
    }
  }
}
