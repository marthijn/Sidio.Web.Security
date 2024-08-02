namespace Sidio.Http.Security.Headers;

public abstract class HttpHeader
{
    protected HttpHeader(string? value)
    {
        Value = value;
    }

    /// <summary>
    /// Gets the name of the header.
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// Gets the value of the header.
    /// </summary>
    public string? Value { get; }

    /// <summary>
    /// Validates the header.
    /// </summary>
    /// <returns>A <see cref="HeaderValidationResult"/>.</returns>
    public HeaderValidationResult Validate()
    {
        var validations = ValidateHeader();
        return new HeaderValidationResult(validations);
    }

    protected abstract IEnumerable<HeaderValidation> ValidateHeader();
}