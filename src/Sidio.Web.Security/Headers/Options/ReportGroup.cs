using System.Text.Json.Serialization;

namespace Sidio.Web.Security.Headers.Options;

/// <summary>
/// Represents a group of reporting endpoints for a Content Security Policy.
/// </summary>
public sealed class ReportGroup
{
    /// <summary>
    /// 126 days.
    /// </summary>
    private const long DefaultMaxAge = 31536000;

    /// <summary>
    /// Initializes a new instance of the <see cref="ReportGroup"/> class.
    /// </summary>
    /// <param name="group">The name of the group.</param>
    /// <param name="maxAge">The lifetime of the report endpoint in seconds.</param>
    /// <param name="endpoints">The reporting endpoints (at least one is required).</param>
    /// <exception cref="ArgumentException">Thrown when an argument is invalid.</exception>
    public ReportGroup(string group, long maxAge, params string[] endpoints) : this(
        group,
        maxAge,
        endpoints.Select(url => new ReportGroupUrl(url)).ToList())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ReportGroup"/> class.
    /// </summary>
    /// <param name="group">The name of the group.</param>
    /// <param name="endpoints">The reporting endpoints (at least one is required).</param>
    /// <exception cref="ArgumentException">Thrown when an argument is invalid.</exception>
    public ReportGroup(string group, params string[] endpoints) : this(group, DefaultMaxAge, endpoints)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ReportGroup"/> class.
    /// </summary>
    /// <param name="group">The name of the group.</param>
    /// <param name="maxAge">The lifetime of the report endpoint in seconds.</param>
    /// <param name="endpoints">The reporting endpoints (at least one is required).</param>
    /// <exception cref="ArgumentException">Thrown when an argument is invalid.</exception>
    [JsonConstructor]
    public ReportGroup(string group, long maxAge, IReadOnlyCollection<ReportGroupUrl> endpoints)
    {
        if (string.IsNullOrWhiteSpace(group))
        {
            throw new ArgumentException("The group name must be specified.", nameof(group));
        }

        if (maxAge < 0)
        {
            throw new ArgumentException("The max age must be greater than or equal to zero.", nameof(maxAge));
        }

        if (endpoints.Count == 0)
        {
            throw new ArgumentException("At least one endpoint must be specified.", nameof(endpoints));
        }

        Group = group;
        MaxAge = maxAge;
        Endpoints = endpoints.ToList();
    }

    /// <summary>
    /// Gets the name of the group.
    /// </summary>
    [JsonPropertyName("group")]
    public string Group { get; }

    /// <summary>
    /// Gets the lifetime of the report endpoint in seconds.
    /// </summary>
    [JsonPropertyName("max_age")]
    public long MaxAge { get; }

    /// <summary>
    /// Gets the report endpoints.
    /// </summary>
    [JsonPropertyName("endpoints")]
    public IReadOnlyCollection<ReportGroupUrl> Endpoints { get; }

    /// <summary>
    /// The report group URL.
    /// </summary>
    public sealed record ReportGroupUrl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportGroup"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <exception cref="ArgumentException">Thrown when an argument is invalid.</exception>
        public ReportGroupUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException("The URL must be specified.", nameof(url));
            }

            Url = url;
        }

        /// <summary>
        /// Gets the URL.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; }
    }
}