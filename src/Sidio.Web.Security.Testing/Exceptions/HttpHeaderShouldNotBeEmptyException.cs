using Sidio.Web.Security.Headers;

namespace Sidio.Web.Security.Testing.Exceptions;

public sealed class HttpHeaderShouldNotBeEmptyException : Exception
{
    public HttpHeaderShouldNotBeEmptyException(HttpHeader header) : base(
        $"The header '{header.Name}' should not be empty.")
    {
    }
}