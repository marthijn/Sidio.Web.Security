using System.Net.Http.Headers;
using Sidio.Web.Security.Headers;
using Sidio.Web.Security.Testing.Headers.Exceptions;

namespace Sidio.Web.Security.Testing.Headers;

/// <summary>
/// The extension methods for <see cref="HttpHeaders"/>.
/// </summary>
public static class HttpHeadersExtensions
{
    /// <summary>
    /// Validates whether all provided headers are valid.
    /// </summary>
    /// <param name="headers">The HTTP headers.</param>
    public static void ShouldHaveValidHeaders(this HttpHeaders headers)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Validates whether all recommended headers are present, and whether they are valid.
    /// </summary>
    /// <param name="headers">The HTTP headers.</param>
    public static void ShouldHaveRecommendedHeaders(this HttpHeaders headers)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Asserts that the headers contain the X-Frame-Options header.
    /// </summary>
    /// <param name="headers">The HTTP headers.</param>
    /// <returns></returns>
    /// <exception cref="HeaderShouldExistException">Thrown when the expected header does not exist.</exception>
    public static XFrameOptionsHeader ShouldHaveXFrameOptionsHeader(this HttpHeaders headers)
    {
        if (headers.TryGetValues(XFrameOptionsHeader.HeaderName, out var values))
        {
            return new XFrameOptionsHeader(values.First());
        }

        throw new HeaderShouldExistException(XFrameOptionsHeader.HeaderName);
    }

    /// <summary>
    /// Asserts that the headers contain the X-Content-Type-Options header.
    /// </summary>
    /// <param name="headers">The HTTP headers.</param>
    /// <returns></returns>
    /// <exception cref="HeaderShouldExistException">Thrown when the expected header does not exist.</exception>
    public static XContentTypeOptionsHeader ShouldHaveXContentTypeOptionsHeader(this HttpHeaders headers)
    {
        if (headers.TryGetValues(XContentTypeOptionsHeader.HeaderName, out var values))
        {
            return new XContentTypeOptionsHeader(values.First());
        }

        throw new HeaderShouldExistException(XContentTypeOptionsHeader.HeaderName);
    }

    /// <summary>
    /// Asserts that the headers contain the Strict-Transport-Security header.
    /// </summary>
    /// <param name="headers">The HTTP headers.</param>
    /// <returns></returns>
    /// <exception cref="HeaderShouldExistException">Thrown when the expected header does not exist.</exception>
    public static StrictTransportSecurityHeader ShouldHaveStrictTransportSecurityHeader(this HttpHeaders headers)
    {
        if (headers.TryGetValues(StrictTransportSecurityHeader.HeaderName, out var values))
        {
            return new StrictTransportSecurityHeader(values.First());
        }

        throw new HeaderShouldExistException(StrictTransportSecurityHeader.HeaderName);
    }

    /// <summary>
    /// Asserts that the headers contain the X-XSS-Protection header.
    /// </summary>
    /// <param name="headers">The HTTP headers.</param>
    /// <returns></returns>
    /// <exception cref="HeaderShouldExistException">Thrown when the expected header does not exist.</exception>
    [Obsolete($"It is not recommended to use the {XXssProtectionHeader.HeaderName} header. Use {nameof(ShouldNotHaveXXssProtectionHeader)} to validate instead.")]
    public static XXssProtectionHeader ShouldHaveXXssProtectionHeader(this HttpHeaders headers)
    {
        if (headers.TryGetValues(XXssProtectionHeader.HeaderName, out var values))
        {
            return new XXssProtectionHeader(values.First());
        }

        throw new HeaderShouldExistException(XXssProtectionHeader.HeaderName);
    }

    /// <summary>
    /// Asserts that the headers do not contain the X-XSS-Protection header.
    /// </summary>
    /// <param name="headers">The HTTP headers.</param>
    /// <exception cref="HeaderShouldNotExistException">Thrown when the expected header exists.</exception>
    public static void ShouldNotHaveXXssProtectionHeader(this HttpHeaders headers)
    {
        if (headers.TryGetValues(XXssProtectionHeader.HeaderName, out _))
        {
            throw new HeaderShouldNotExistException(XXssProtectionHeader.HeaderName);
        }
    }

    /// <summary>
    /// Asserts that the headers contain the Content-Security-Policy header.
    /// </summary>
    /// <param name="headers">The HTTP headers.</param>
    /// <returns></returns>
    /// <exception cref="HeaderShouldExistException">Thrown when the expected header does not exist.</exception>
    public static ContentSecurityPolicyHeader ShouldHaveContentSecurityPolicyHeader(this HttpHeaders headers)
    {
        if (headers.TryGetValues(ContentSecurityPolicyHeader.HeaderName, out var values))
        {
            return new ContentSecurityPolicyHeader(values.First());
        }

        throw new HeaderShouldExistException(ContentSecurityPolicyHeader.HeaderName);
    }

    /// <summary>
    /// Asserts that the headers contain the Report-To header.
    /// </summary>
    /// <param name="headers">The HTTP headers.</param>
    /// <returns>A <see cref="ReportToHeader"/>.</returns>
    /// <exception cref="HeaderShouldExistException">Thrown when the expected header does not exist.</exception>
    public static ReportToHeader ShouldHaveReportToHeader(this HttpHeaders headers)
    {
        if (headers.TryGetValues(ReportToHeader.HeaderName, out var values))
        {
            return new ReportToHeader(values.First());
        }

        throw new HeaderShouldExistException(ReportToHeader.HeaderName);
    }

    /// <summary>
    /// Asserts that the headers contain the Referrer-Policy header.
    /// </summary>
    /// <param name="headers">The HTTP headers.</param>
    /// <returns>A <see cref="ReferrerPolicyHeader"/>.</returns>
    /// <exception cref="HeaderShouldExistException">Thrown when the expected header does not exist.</exception>
    public static ReferrerPolicyHeader ShouldHaveReferrerPolicyHeader(this HttpHeaders headers)
    {
        if (headers.TryGetValues(ReferrerPolicyHeader.HeaderName, out var values))
        {
            return new ReferrerPolicyHeader(values.First());
        }

        throw new HeaderShouldExistException(ReferrerPolicyHeader.HeaderName);
    }
}