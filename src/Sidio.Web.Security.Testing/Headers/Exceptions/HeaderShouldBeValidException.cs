using Sidio.Web.Security.Headers;

namespace Sidio.Web.Security.Testing.Headers.Exceptions;

/// <summary>
/// The exception that is thrown when a header value is invalid.
/// </summary>
public sealed class HeaderShouldBeValidException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HeaderShouldBeValidException"/> class.
    /// </summary>
    /// <param name="header">The header.</param>
    public HeaderShouldBeValidException(HttpHeader header) : base(
        $"Expected header '{header.Name}' to be valid, but was not.")
    {
    }
}