namespace Sidio.Http.Security.Headers;

public sealed record HeaderValidation
{
    public HeaderValidation(HeaderValidationSeverityLevel severityLevel, string message)
    {
        SeverityLevel = severityLevel;
        Message = message;
    }

    public HeaderValidationSeverityLevel SeverityLevel { get; }

    public string Message { get; }
}