using Sidio.Http.Security.Headers;

namespace Sidio.Http.Security.Testing.Exceptions;

public sealed class HeaderShouldBeValidException : Exception
{
    public HeaderShouldBeValidException(HttpHeader header) : base(
        $"Expected header '{header.Name}' to be valid, but was not.")
    {
    }
}