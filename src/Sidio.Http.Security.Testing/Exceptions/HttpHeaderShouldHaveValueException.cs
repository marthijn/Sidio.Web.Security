using Sidio.Http.Security.Headers;

namespace Sidio.Http.Security.Testing.Exceptions;

public sealed class HttpHeaderShouldHaveValueException : Exception
{
    public HttpHeaderShouldHaveValueException(HttpHeader header, string expectedValue)
        : base($"The header '{header.Name}' was expected to have the value '{expectedValue}' but was '{header.Value}'.")
    {
    }
}