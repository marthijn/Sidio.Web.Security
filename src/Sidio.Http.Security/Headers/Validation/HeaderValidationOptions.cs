namespace Sidio.Http.Security.Headers.Validation;

/// <summary>
/// The options for header validation.
/// </summary>
public sealed class HeaderValidationOptions
{
    /// <summary>
    /// Gets or sets a value indicating whether to suppress warnings. Default is false.
    /// </summary>
    public bool SuppressWarnings { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to validate recommended headers are present. Default is true.
    /// </summary>
    public bool ValidateRecommendedHeadersArePresent { get; set; } = true;
}