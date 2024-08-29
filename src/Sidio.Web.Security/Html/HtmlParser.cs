using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Sidio.Web.Security.Html;

/// <summary>
/// The HTML parser.
/// </summary>
public static partial class HtmlParser
{
#if NET7_0_OR_GREATER
    [StringSyntax(StringSyntaxAttribute.Regex)]
#endif
    private const string ScriptTagsPattern = @"<script(?=.*?\bsrc\s*=\s*[""'](?<src>.*?)[""']|)(?=.*?\bnonce\s*=\s*[""'](?<nonce>.*?)[""']|)(?=.*?\bintegrity\s*=\s*[""'](?<integrity>.*?)[""']|)(?=.*?\bcrossorigin\s*=\s*[""'](?<crossorigin>.*?)[""']|)[^>]*>(?<content>.*?)<\/script>";

    /// <summary>
    /// Extracts the script tags from the HTML.
    /// </summary>
    /// <param name="html">The HTML content.</param>
    /// <returns>A <see cref="ScriptTagCollection"/>.</returns>
    public static ScriptTagCollection ExtractScriptTags(string html)
    {
#if NET7_0_OR_GREATER
        var regex = ScriptTagRegex();
#else
        var regex = new Regex(ScriptTagsPattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
#endif
        var matches = regex.Matches(html);

        var result = new ScriptTagCollection();
        var index = 0;
        foreach (Match match in matches)
        {
            result.Add(
                new ScriptTag(
                    index++,
                    NullIfEmpty(match.Groups["src"].Value.Trim()),
                    NullIfEmpty(match.Groups["nonce"].Value.Trim()),
                    NullIfEmpty(match.Groups["integrity"].Value.Trim()),
                    NullIfEmpty(match.Groups["crossorigin"].Value.Trim()),
                NullIfEmpty(match.Groups["content"].Value.Trim())));
        }

        return result;
    }

    private static string? NullIfEmpty(string value) => string.IsNullOrEmpty(value) ? null : value;

#if NET7_0_OR_GREATER
    [GeneratedRegex(ScriptTagsPattern, RegexOptions.IgnoreCase | RegexOptions.Multiline)]
    private static partial Regex ScriptTagRegex();
#endif
}