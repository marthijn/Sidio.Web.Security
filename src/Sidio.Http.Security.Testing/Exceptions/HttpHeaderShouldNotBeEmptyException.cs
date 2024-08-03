using Sidio.Http.Security.Headers;

namespace Sidio.Http.Security.Testing.Exceptions;

public sealed class HttpHeaderShouldNotBeEmptyException : Exception
{
    public HttpHeaderShouldNotBeEmptyException(HttpHeader header) : base(
        $"The header '{header.Name}' should not be empty.")
    {
    }
}