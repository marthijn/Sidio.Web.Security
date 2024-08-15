using System.Text.Json;

namespace Sidio.Web.Security.Headers.Options;

/// <summary>
/// The report-to header options.
/// </summary>
public sealed class ReportToHeaderOptions : IHttpHeaderOptions
{
    /// <summary>
    /// Gets the list of report groups.
    /// </summary>
    public List<ReportGroup> Groups { get; set; } = [];

    /// <inheritdoc />
    public string Value => ToString();

    /// <inheritdoc />
    public override string ToString()
    {
        // serialize each group to JSON
        return string.Join(",", Groups.Select(x => JsonSerializer.Serialize(x)));
    }
}