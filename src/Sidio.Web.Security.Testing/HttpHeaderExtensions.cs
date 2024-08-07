using Sidio.Web.Security.Headers;
using Sidio.Web.Security.Testing.Exceptions;

namespace Sidio.Web.Security.Testing;

public static class HttpHeaderExtensions
{
    public static HttpHeader WithValue(this HttpHeader header, string expectedValue)
    {
        if (!expectedValue.Equals(header.Value, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new HttpHeaderShouldHaveValueException(header, expectedValue);
        }

        return header;
    }

    public static HttpHeader WithNonEmptyValue(this HttpHeader header)
    {
        if (string.IsNullOrEmpty(header.Value))
        {
            throw new HttpHeaderShouldNotBeEmptyException(header);
        }

        return header;
    }
}