namespace Sidio.Web.Security.Headers.Options.ContentSecurityPolicy;

/// <summary>
/// The builder for the Content Security Policy directive 'src'.
/// </summary>
public abstract class SrcBuilderBase<T> : ISrcBuilder
    where T : class, ISrcBuilder
{
    /// <summary>
    /// The sources for the directive.
    /// </summary>
    protected readonly HashSet<string> Sources = new();

    /// <summary>
    /// Gets the current instance of the builder.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when this instance cannot be converted to T.</exception>
    protected T This => this as T ?? throw new InvalidOperationException();

    /// <summary>
    /// Gets a read-only collection of the sources.
    /// </summary>
    internal IReadOnlyCollection<string> SourcesInternal => Sources;

    /// <summary>
    /// Add the 'self' source to the directive.
    /// </summary>
    /// <returns>The <see cref="ISrcBuilder"/> of type <see cref="T"/>.</returns>
    public T AllowSelf()
    {
        Sources.Add("'self'");
        return This;
    }

    /// <summary>
    /// Add the wildcard source to the directive.
    /// </summary>
    /// <returns>The <see cref="ISrcBuilder"/> of type <see cref="T"/></returns>
    public T AllowAll()
    {
        Sources.Add("*");
        return This;
    }

    /// <summary>
    /// Add a URL source to the directive.
    /// </summary>
    /// <param name="urls">The urls.</param>
    /// <returns>The <see cref="ISrcBuilder"/> of type <see cref="T"/></returns>
    /// <exception cref="ArgumentException">Thrown when no URLs are provided, or when a URL is null or empty.</exception>
    public T AllowUrl(params string[] urls)
    {
        if (urls.Length == 0)
        {
            throw new ArgumentException("At least one URL is required.", nameof(urls));
        }

        foreach (var url in urls)
        {
            AllowSingleUrl(url);
        }

        return This;
    }

    /// <summary>
    /// Add the 'none' source to the directive.
    /// </summary>
    /// <returns>The <see cref="ISrcBuilder"/> of type <see cref="T"/></returns>
    public T AllowNone()
    {
        Sources.Add("'none'");
        return This;
    }

    /// <summary>
    /// Add the 'data:' scheme to the directive.
    /// </summary>
    /// <returns>The <see cref="ISrcBuilder"/> of type <see cref="T"/></returns>
    public T AllowData()
    {
        Sources.Add("data:");
        return This;
    }

    /// <summary>
    /// Adds the 'unsafe-inline' to the directive.
    /// </summary>
    /// <returns>The <see cref="ISrcBuilder"/> of type <see cref="T"/></returns>
    public T AllowUnsafeInline()
    {
        Sources.Add("'unsafe-inline'");
        return This;
    }

    /// <summary>
    /// Adds the 'https:' scheme to the directives.
    /// </summary>
    /// <returns>The <see cref="ISrcBuilder"/> of type <see cref="T"/></returns>
    public T AllowHttp()
    {
        Sources.Add("http:");
        return This;
    }

    /// <summary>
    /// Adds the 'https:' scheme to the directives.
    /// </summary>
    /// <returns>The <see cref="ISrcBuilder"/> of type <see cref="T"/></returns>
    public T AllowHttps()
    {
        Sources.Add("https:");
        return This;
    }

    /// <summary>
    /// Adds the 'mediastream:' scheme to the directives.
    /// </summary>
    /// <returns>The <see cref="ISrcBuilder"/> of type <see cref="T"/></returns>
    public T AllowMediaStream()
    {
        Sources.Add("mediastream:");
        return This;
    }

    /// <summary>
    /// Adds the 'blob:' scheme to the directives.
    /// </summary>
    /// <returns>The <see cref="ISrcBuilder"/> of type <see cref="T"/></returns>
    public T AllowBlob()
    {
        Sources.Add("blob:");
        return This;
    }

    /// <summary>
    /// Adds the 'filesystem:' scheme to the directives.
    /// </summary>
    /// <returns>The <see cref="ISrcBuilder"/> of type <see cref="T"/></returns>
    public T AllowFileSystem()
    {
        Sources.Add("filesystem:");
        return This;
    }

    /// <summary>
    /// Adds the 'report-sample' to the directives.
    /// </summary>
    /// <returns>The <see cref="ISrcBuilder"/> of type <see cref="T"/></returns>
    public T ShouldReportSample()
    {
        Sources.Add("'report-sample'");
        return This;
    }

    /// <summary>
    /// Adds the 'allow-duplicates' to the directives.
    /// </summary>
    /// <returns>The <see cref="ISrcBuilder"/> of type <see cref="T"/></returns>
    public T AllowDuplicates()
    {
        Sources.Add("'allow-duplicates'");
        return This;
    }

    /// <inheritdoc />
    public override string ToString() => string.Join(" ", Sources);

    private T AllowSingleUrl(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            throw new ArgumentException("The URL should not be null or empty.", nameof(url));
        }

        Sources.Add(url);
        return This;
    }
}