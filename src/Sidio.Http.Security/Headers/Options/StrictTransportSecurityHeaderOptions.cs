using System.Text;

namespace Sidio.Http.Security.Headers.Options;

/// <summary>
/// The options for the Strict-Transport-Security header.
/// </summary>
public sealed class StrictTransportSecurityHeaderOptions : IStrictTransportSecurityHeaderOptions, IHttpHeaderOptions
{
    /// <inheritdoc />
    public long MaxAge { get; set; } = StrictTransportSecurityHeader.TwoYears;

    /// <inheritdoc />
    public bool IncludeSubDomains { get; set; } = true;

    /// <inheritdoc />
    public bool Preload { get; set; } = false;

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