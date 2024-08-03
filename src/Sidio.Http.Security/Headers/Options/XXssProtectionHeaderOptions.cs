using System.Text;

namespace Sidio.Http.Security.Headers.Options;

public sealed class XXssProtectionHeaderOptions : IHttpHeaderOptions
{
    public bool Enabled { get; set; } = true;

    public bool Block { get; set; }

    public string? ReportUri { get; set; }

    public string Value => ToString();

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