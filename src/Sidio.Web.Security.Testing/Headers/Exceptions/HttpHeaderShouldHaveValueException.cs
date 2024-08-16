using Sidio.Web.Security.Headers;

namespace Sidio.Web.Security.Testing.Headers.Exceptions;

/// <summary>
/// The exception that is thrown when a header should have a specific value.
/// </summary>
public sealed class HttpHeaderShouldHaveValueException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HttpHeaderShouldHaveValueException"/> class.
    /// </summary>
    /// <param name="header">The header.</param>
    /// <param name="expectedValue">The expected header value.</param>
    public HttpHeaderShouldHaveValueException(HttpHeader header, string expectedValue)
        : base($"The header '{header.Name}' was expected to have the value '{expectedValue}' but was '{header.Value}'.")
    {
    }
}