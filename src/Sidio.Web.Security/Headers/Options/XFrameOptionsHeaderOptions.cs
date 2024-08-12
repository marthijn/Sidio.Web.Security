using System.Diagnostics;

namespace Sidio.Web.Security.Headers.Options;

/// <summary>
/// The X-Frame-Options header options.
/// </summary>
[DebuggerDisplay("{Value}")]
public sealed class XFrameOptionsHeaderOptions : IHttpHeaderOptions
{
    /// <summary>
    /// Gets or sets the X-Frame-Options directive. The default value is <see cref="XFrameOptionsDirective.Deny"/>.
    /// </summary>
    public XFrameOptionsDirective Directive { get; set; } = XFrameOptionsDirective.Deny;

    /// <inheritdoc />
    public string Value => ToString();

    /// <inheritdoc />
    public override string ToString()
    {
        return Directive switch
        {
            XFrameOptionsDirective.Deny => XFrameOptionsHeader.Deny,
            XFrameOptionsDirective.SameOrigin => XFrameOptionsHeader.SameOrigin,
            _ => throw new InvalidOperationException($"Unknown X-Frame-Options directive: {Directive}")
        };
    }

    /// <summary>
    /// The X-Frame-Options header value.
    /// </summary>
    /// <remarks>The ALLOW-FROM option is not supported since it is deprecated. Use the Content-Security-Policy with
    /// the frame-ancestors directive.</remarks>
    public enum XFrameOptionsDirective
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
}