using System.Diagnostics;

namespace Sidio.Web.Security.Headers.Options;

/// <summary>
/// The Referrer-Policy header options.
/// </summary>
[DebuggerDisplay("{Value}")]
public sealed class ReferrerPolicyHeaderOptions : IHttpHeaderOptions
{
    /// <inheritdoc />
    public string Value => ToString();
}