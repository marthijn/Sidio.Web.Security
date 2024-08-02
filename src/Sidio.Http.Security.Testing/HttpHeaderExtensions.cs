using Sidio.Http.Security.Headers;

namespace Sidio.Http.Security.Testing;

public static class HttpHeaderExtensions
{
    public static void WithValue(this HttpHeader header, string expectedValue)
    {
        if (!expectedValue.Equals(header.Value, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new HttpHeaderShouldHaveValueException(header, expectedValue);
        }
    }

    public static void WithNonEmptyValue(this HttpHeader header)
    {
        if (string.IsNullOrEmpty(header.Value))
        {
            throw new HttpHeaderShouldNotBeEmptyException(header);
        }
    }
}