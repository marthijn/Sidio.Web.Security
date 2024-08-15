using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sidio.Web.Security.AspNetCore.Reporting;

/// <summary>
/// Report that is sent by the browser when a violation occurs.
/// See: https://www.w3.org/TR/reporting/
/// </summary>
public sealed record Report
{
    /// <summary>
    /// Gets the report type.
    /// </summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>
    /// Gets the number of milliseconds between report’s timestamp and the current time.
    /// </summary>
    [JsonPropertyName("age")]
    public long Age { get; init; }

    /// <summary>
    /// Gets the URL.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; init; }

    /// <summary>
    /// Gets the user agent.
    /// </summary>
    [JsonPropertyName("user_agent")]
    public string? UserAgent { get; init; }

    /// <summary>
    /// Gets the data of the report.
    /// </summary>
    [JsonPropertyName("body")]
    public Dictionary<string, JsonElement>? Body { get; init; }
}