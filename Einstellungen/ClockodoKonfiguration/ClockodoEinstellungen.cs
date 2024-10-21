namespace coIT.Toolkit.Lexoffice.GdiExport.Einstellungen.ClockodoKonfiguration;

public record ClockodoEinstellungen
{
    public required string ApiToken { get; init; }
    public required string EmailAddress { get; init; }
    public required string BaseAddress { get; init; }
}
