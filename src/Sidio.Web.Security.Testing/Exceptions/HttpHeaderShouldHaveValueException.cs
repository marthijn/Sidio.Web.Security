using Sidio.Web.Security.Headers;

namespace Sidio.Web.Security.Testing.Exceptions;

public sealed class HttpHeaderShouldHaveValueException : Exception
{
    public HttpHeaderShouldHaveValueException(HttpHeader header, string expectedValue)
        : base($"The header '{header.Name}' was expected to have the value '{expectedValue}' but was '{header.Value}'.")
    {
    }
}