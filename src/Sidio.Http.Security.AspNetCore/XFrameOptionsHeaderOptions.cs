namespace Sidio.Http.Security.AspNetCore;

public sealed class XFrameOptionsHeaderOptions
{
    public XFrameOptionsValue Value { get; set; } = XFrameOptionsValue.Deny;

    /// <summary>
    /// The X-Frame-Options header value.
    /// </summary>
    /// <remarks>The ALLOW-FROM option is not supported since it is deprecated. Use the Content-Security-Policy with
    /// the frame-ancestors directive.</remarks>
    public enum XFrameOptionsValue
    {
        Deny,
        SameOrigin,
    }
}