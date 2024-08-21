using System.Diagnostics;

namespace Sidio.Web.Security.Headers.Options;

/// <summary>
/// The X-Frame-Options header options.
/// </summary>
[DebuggerDisplay("{Value}")]
public sealed class XFrameOptionsHeaderOptions : IHttpHeaderOptions
{
    /// <summary>
    /// Gets or sets the X-Frame-Options directive. The default value is <see cref="XFrameOptions.Deny"/>.
    /// </summary>
    public XFrameOptions Directive { get; set; } = XFrameOptions.Deny;

    /// <inheritdoc />
    public string Value => ToString();

    /// <inheritdoc />
    public override string ToString()
    {
        return Directive switch
        {
            XFrameOptions.Deny => XFrameOptionsHeader.Deny,
            XFrameOptions.SameOrigin => XFrameOptionsHeader.SameOrigin,
            _ => throw new InvalidOperationException($"Unknown X-Frame-Options directive: {Directive}")
        };
    }
}