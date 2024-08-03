namespace Sidio.Http.Security.Headers.Options;

/// <summary>
/// The options for the Strict-Transport-Security header.
/// </summary>
public interface IStrictTransportSecurityHeaderOptions
{
    /// <summary>
    /// Gets or sets the max age. That is the time in seconds that the browser should remember that this site is only to be accessed using HTTPS.
    /// </summary>
    long MaxAge { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to include subdomains. If set to true, the browser will also enforce HTTPS on all subdomains.
    /// </summary>
    bool IncludeSubDomains { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to preload the site. If set to true, the site will be included in the HSTS preload list.
    /// </summary>
    bool Preload { get; set; }
}