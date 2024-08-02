namespace Sidio.Http.Security.Headers;

public sealed class InvalidHeaderException : Exception
{
    internal InvalidHeaderException(HttpHeader header, HeaderValidationResult validationResult)
        : base($"The header '{header.Name}' is invalid.")
    {
        ValidationResult = validationResult;
    }

    public HeaderValidationResult ValidationResult { get; }
}