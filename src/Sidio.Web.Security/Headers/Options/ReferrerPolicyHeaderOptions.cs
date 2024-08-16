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
    /// Gets or sets the Referrer-Policy directives. The default value is <see cref="ReferrerPolicy.StrictOriginWhenCrossOrigin"/>.
    /// Multiple values can be used to specify a fallback policy.
    /// </summary>
    public List<ReferrerPolicy> Policies { get; set; } = [ReferrerPolicy.StrictOriginWhenCrossOrigin];

    /// <inheritdoc />
    public string Value => ToString();

    /// <inheritdoc />
    public override string ToString() => string.Join(", ", Policies.Select(p => p.ToStringValue()));
}