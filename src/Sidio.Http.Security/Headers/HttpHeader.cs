using Sidio.Http.Security.Headers.Validation;

namespace Sidio.Http.Security.Headers;

/// <summary>
/// The base class for HTTP headers.
/// </summary>
public abstract class HttpHeader
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HttpHeader"/> class.
    /// </summary>
    /// <param name="value">The header value.</param>
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
    public abstract HeaderValidationResult Validate();
}