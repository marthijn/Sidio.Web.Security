namespace Sidio.Web.Security.Headers.Options;

/// <summary>
/// The X-Frame-Options header value.
/// </summary>
/// <remarks>The ALLOW-FROM option is not supported since it is deprecated. Use the Content-Security-Policy with
/// the frame-ancestors directive.</remarks>
public enum XFrameOptions
{
    /// <summary>
    /// The page cannot be displayed in a frame, regardless of the site attempting to do so.
    /// </summary>
    Deny,

    /// <summary>
    /// The page can only be displayed in a frame on the same origin as the page itself.
    /// </summary>
    SameOrigin,
}