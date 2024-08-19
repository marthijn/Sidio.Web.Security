using System.Diagnostics;
using System.Text;

namespace Sidio.Web.Security.Headers.Options;

/// <summary>
/// The options for the Strict-Transport-Security header.
/// </summary>
[DebuggerDisplay("{Value}")]
public sealed class StrictTransportSecurityHeaderOptions : IHttpHeaderOptions
{
    /// <summary>
    /// Gets or sets the max age. That is the time in seconds that the browser should remember that this site is only to be accessed using HTTPS.
    /// </summary>
    public long MaxAge { get; set; } = StrictTransportSecurityHeader.TwoYears;

    /// <summary>
    /// Gets or sets a value indicating whether to include subdomains. If set to true, the browser will also enforce HTTPS on all subdomains.
    /// </summary>
    public bool IncludeSubDomains { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to preload the site. If set to true, the site will be included in the HSTS preload list.
    /// </summary>
    public bool Preload { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to disable localhost requests.
    /// If set to true, localhost will be excluded from the HSTS header.
    /// </summary>
    public bool DisableForLocalhostRequests { get; set; } = true;

    /// <inheritdoc />
    public string Value => ToString();

    /// <inheritdoc />
    public override string ToString()
    {
        var sb = new StringBuilder($"max-age={MaxAge}");

        if (IncludeSubDomains)
        {
            sb.Append("; includeSubDomains");
        }

        if (Preload)
        {
            sb.Append("; preload");
        }

        return sb.ToString();
    }
}