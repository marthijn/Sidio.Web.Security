using System.Diagnostics;
using Sidio.Web.Security.Common;

namespace Sidio.Web.Security.Headers.Options;

/// <summary>
/// The Cross-Origin-Resource-Policy header options.
/// </summary>
[DebuggerDisplay("{Value}")]
public sealed class CrossOriginResourcePolicyHeaderOptions : IHttpHeaderOptions
{
    /// <summary>
    /// Gets or sets the policy.
    /// </summary>
    public CrossOriginResourcePolicy Policy { get; set; }

    /// <inheritdoc />
    public string Value => ToString();

    /// <inheritdoc />
    public override string ToString() => Policy.ToStringValue();
}