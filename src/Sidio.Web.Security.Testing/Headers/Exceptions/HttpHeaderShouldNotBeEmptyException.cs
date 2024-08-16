using Sidio.Web.Security.Headers;

namespace Sidio.Web.Security.Testing.Headers.Exceptions;

/// <summary>
/// The exception that is thrown when a header should not be empty.
/// </summary>
public sealed class HttpHeaderShouldNotBeEmptyException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HttpHeaderShouldNotBeEmptyException"/> class.
    /// </summary>
    /// <param name="header">The header.</param>
    public HttpHeaderShouldNotBeEmptyException(HttpHeader header) : base(
        $"The header '{header.Name}' should not be empty.")
    {
    }
}