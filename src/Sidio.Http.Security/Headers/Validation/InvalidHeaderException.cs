namespace Sidio.Http.Security.Headers.Validation;

/// <summary>
/// This exception is thrown when a header is invalid.
/// </summary>
public sealed class InvalidHeaderException : Exception
{
    internal InvalidHeaderException(HttpHeader header, HeaderValidationResult validationResult)
        : base($"The header '{header.Name}' is invalid.")
    {
        ValidationResult = validationResult;
    }

    /// <summary>
    /// Gets the validation result.
    /// </summary>
    public HeaderValidationResult ValidationResult { get; }
}