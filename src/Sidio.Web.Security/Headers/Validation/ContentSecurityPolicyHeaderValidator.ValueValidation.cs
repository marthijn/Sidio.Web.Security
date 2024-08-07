using System.Text.RegularExpressions;

namespace Sidio.Web.Security.Headers.Validation;

public sealed partial class ContentSecurityPolicyHeaderValidator
{
    private static readonly Regex ReportToRegex = new Regex("^[a-zA-Z0-9_-]+$", RegexOptions.IgnoreCase);

    private static readonly Regex SrcRegex = new Regex(@"^[a-z0-9.'\s-\*:/]+$", RegexOptions.IgnoreCase);

    private static bool IsValidSrc(string input)
    {
        return SrcRegex.IsMatch(input);
    }

    private static bool IsValidReportTo(string input)
    {
        return ReportToRegex.IsMatch(input);
    }
}