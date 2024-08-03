using System.Net.Http.Headers;
using Sidio.Http.Security.Headers;
using Sidio.Http.Security.Testing.Exceptions;

namespace Sidio.Http.Security.Testing;

public static class HttpHeadersExtensions
{
    /// <summary>
    /// Validates whether all provided headers are valid.
    /// </summary>
    /// <param name="headers"></param>
    public static void ShouldHaveValidHeaders(this HttpHeaders headers)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Validates whether all recommended headers are present, and whether they are valid.
    /// </summary>
    /// <param name="headers"></param>
    public static void ShouldHaveRecommendedHeaders(this HttpHeaders headers)
    {
        throw new NotImplementedException();
    }

    public static XFrameOptionsHeader ShouldHaveXFrameOptionsHeader(this HttpHeaders headers)
    {
        if (headers.TryGetValues(XFrameOptionsHeader.HeaderName, out var values))
        {
            return new XFrameOptionsHeader(values.First());
        }

        throw new HeaderShouldExistException(XFrameOptionsHeader.HeaderName);
    }

    public static XContentTypeOptionsHeader ShouldHaveXContentTypeOptionsHeader(this HttpHeaders headers)
    {
        if (headers.TryGetValues(XContentTypeOptionsHeader.HeaderName, out var values))
        {
            return new XContentTypeOptionsHeader(values.First());
        }

        throw new HeaderShouldExistException(XContentTypeOptionsHeader.HeaderName);
    }

    public static StrictTransportSecurityHeader ShouldHaveStrictTransportSecurityHeader(this HttpHeaders headers)
    {
        if (headers.TryGetValues(StrictTransportSecurityHeader.HeaderName, out var values))
        {
            return new StrictTransportSecurityHeader(values.First());
        }

        throw new HeaderShouldExistException(StrictTransportSecurityHeader.HeaderName);
    }

    [Obsolete($"It is not recommended to use the {XXssProtectionHeader.HeaderName} header. Use {nameof(ShouldNotHaveXXssProtectionHeader)} to validate instead.")]
    public static XXssProtectionHeader ShouldHaveXXssProtectionHeader(this HttpHeaders headers)
    {
        if (headers.TryGetValues(XXssProtectionHeader.HeaderName, out var values))
        {
            return new XXssProtectionHeader(values.First());
        }

        throw new HeaderShouldExistException(XXssProtectionHeader.HeaderName);
    }

    public static void ShouldNotHaveXXssProtectionHeader(this HttpHeaders headers)
    {
        if (headers.TryGetValues(XXssProtectionHeader.HeaderName, out _))
        {
            throw new HeaderShouldNotExistException(XXssProtectionHeader.HeaderName);
        }
    }

    public static T ShouldHaveHttpHeader<T>(this HttpHeaders headers)
        where T : HttpHeader, new()
    {
        var tmpHeader = Activator.CreateInstance<T>();

        if (headers.TryGetValues(tmpHeader.Name, out var values))
        {
            return (T)Activator.CreateInstance(typeof(T), values.First());
        }

        throw new HeaderShouldExistException(tmpHeader.Name);
    }
}