namespace Sidio.Web.Security.Headers.Options;

/// <summary>
/// The report endpoint.
/// </summary>
public sealed record ReportEndpoint
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ReportEndpoint"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="url">The URL.</param>
    public ReportEndpoint(string name, string url)
    {
        Name = name;
        Url = url;
    }

    /// <summary>
    /// Gets the name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the URL.
    /// </summary>
    public string Url { get; }

    /// <inheritdoc />
    public override string ToString() => $"{Name}=\"{Url}\"";
}