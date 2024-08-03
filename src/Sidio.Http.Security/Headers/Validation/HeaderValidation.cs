namespace Sidio.Http.Security.Headers.Validation;

/// <summary>
/// A single result of the header validation.
/// </summary>
public sealed record HeaderValidation
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HeaderValidation"/> class.
    /// </summary>
    /// <param name="severityLevel">The severity level.</param>
    /// <param name="message">The message.</param>
    public HeaderValidation(HeaderValidationSeverityLevel severityLevel, string message)
    {
        SeverityLevel = severityLevel;
        Message = message;
    }

    /// <summary>
    /// Gets the severity level.
    /// </summary>
    public HeaderValidationSeverityLevel SeverityLevel { get; }

    /// <summary>
    /// Gets the message.
    /// </summary>
    public string Message { get; }
}