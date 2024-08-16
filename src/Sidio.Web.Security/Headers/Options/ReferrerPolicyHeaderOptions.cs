using System.Diagnostics;
using Sidio.Web.Security.Common;

namespace Sidio.Web.Security.Headers.Options;

/// <summary>
/// The Referrer-Policy header options.
/// </summary>
[DebuggerDisplay("{Value}")]
public sealed class ReferrerPolicyHeaderOptions : IHttpHeaderOptions
{
    /// <summary>
    /// Gets or sets the Referrer-Policy directive. The default value is <see cref="ReferrerPolicy.StrictOriginWhenCrossOrigin"/>.
    /// </summary>
    public ReferrerPolicy Policy { get; set; } = ReferrerPolicy.StrictOriginWhenCrossOrigin;

    /// <inheritdoc />
    public string Value => ToString();

    /// <inheritdoc />
    public override string ToString() => Policy.ToStringValue();
}