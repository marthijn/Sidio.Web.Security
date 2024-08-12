using System.Diagnostics;
using System.Text;

namespace Sidio.Web.Security.Headers.Options;

/// <summary>
/// The X-XSS-Protection header options.
/// </summary>
[DebuggerDisplay("{Value}")]
public sealed class XXssProtectionHeaderOptions : IHttpHeaderOptions
{
    /// <summary>
    /// Gets or sets a value indicating whether the X-XSS-Protection header is enabled.
    /// </summary>
    public bool Enabled { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to block the response if an attack is detected.
    /// </summary>
    public bool Block { get; set; }

    /// <summary>
    /// Gets or sets the URI to report violations to.
    /// </summary>
    public string? ReportUri { get; set; }

    /// <inheritdoc />
    public string Value => ToString();

    /// <inheritdoc />
    public override string ToString()
    {
        var sb = new StringBuilder();

        if (Enabled)
        {
            sb.Append("1");

            if (Block)
            {
                sb.Append("; mode=block");
            }
            else if (!string.IsNullOrWhiteSpace(ReportUri))
            {
                sb.Append($"; report={ReportUri}");
            }
        }
        else
        {
            sb.Append("0");
        }

        return sb.ToString();
    }
}