using System.Runtime.Serialization;

namespace Sidio.Web.Security.Headers.Options;

/// <summary>
/// The Referrer-Policy directive options.
/// </summary>
public enum ReferrerPolicy
{
    /// <summary>
    /// The Referer header will be omitted: sent requests do not include any referrer information.
    /// </summary>
    [EnumMember(Value = "no-referrer")]
    NoReferrer,

    /// <summary>
    /// Send the origin, path, and querystring in Referer when the protocol security level stays the same or improves (HTTP→HTTP, HTTP→HTTPS, HTTPS→HTTPS).
    /// Don't send the Referer header for requests to less secure destinations (HTTPS→HTTP, HTTPS→file).
    /// </summary>
    [EnumMember(Value = "no-referrer-when-downgrade")]
    NoReferrerWhenDowngrade,

    /// <summary>
    /// Send only the origin in the Referer header.
    /// </summary>
    [EnumMember(Value = "origin")]
    Origin,

    /// <summary>
    /// When performing a same-origin request to the same protocol level (HTTP→HTTP, HTTPS→HTTPS), send the origin, path, and query string.
    /// Send only the origin for cross origin requests and requests to less secure destinations (HTTPS→HTTP).
    /// </summary>
    [EnumMember(Value = "origin-when-cross-origin")]
    OriginWhenCrossOrigin,

    /// <summary>
    /// Send the origin, path, and query string for same-origin requests. Don't send the Referer header for cross-origin requests.
    /// </summary>
    [EnumMember(Value = "same-origin")]
    SameOrigin,

    /// <summary>
    /// Send only the origin when the protocol security level stays the same (HTTPS→HTTPS). Don't send the Referer header to less secure destinations (HTTPS→HTTP).
    /// </summary>
    [EnumMember(Value = "strict-origin")]
    StrictOrigin,

    /// <summary>
    /// Send the origin, path, and querystring when performing a same-origin request. For cross-origin requests send the origin (only) when the protocol security level stays same (HTTPS→HTTPS).
    /// Don't send the Referer header to less secure destinations (HTTPS→HTTP).
    /// </summary>
    [EnumMember(Value = "strict-origin-when-cross-origin")]
    StrictOriginWhenCrossOrigin,

    /// <summary>
    /// Send the origin, path, and query string when performing any request, regardless of security.
    /// </summary>
    [EnumMember(Value = "unsafe-url")]
    UnsafeUrl
}