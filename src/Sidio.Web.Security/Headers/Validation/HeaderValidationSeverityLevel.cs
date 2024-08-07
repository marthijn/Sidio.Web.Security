namespace Sidio.Web.Security.Headers.Validation;

/// <summary>
/// The severity level of the header validation.
/// </summary>
public enum HeaderValidationSeverityLevel
{
    /// <summary>
    /// Indicates the header is valid with warnings. E.g. a deprecated or unsafe value is used.
    /// </summary>
    Warning,

    /// <summary>
    /// Indicates the header is invalid. E.g. the value is missing or incorrect.
    /// </summary>
    Error
}