using Sidio.Web.Security.Headers;
using Sidio.Web.Security.Testing.Exceptions;

namespace Sidio.Web.Security.Testing;

public static class HttpHeaderExtensions
{
    public static T WithValue<T>(this T header, string expectedValue)
        where T : HttpHeader
    {
        if (!expectedValue.Equals(header.Value, StringComparison.OrdinalIgnoreCase))
        {
            throw new HttpHeaderShouldHaveValueException(header, expectedValue);
        }

        return header;
    }

    public static T WithNonEmptyValue<T>(this T header)
        where T : HttpHeader
    {
        if (string.IsNullOrEmpty(header.Value))
        {
            throw new HttpHeaderShouldNotBeEmptyException(header);
        }

        return header;
    }

    public static T ContainsValue<T>(this T header, string expectedValue)
        where T : HttpHeader
    {
        if (header.Value == null || header.Value.IndexOf(expectedValue, StringComparison.OrdinalIgnoreCase) < 0)
        {
            throw new HttpHeaderShouldHaveValueException(header, expectedValue);
        }

        return header;
    }
}