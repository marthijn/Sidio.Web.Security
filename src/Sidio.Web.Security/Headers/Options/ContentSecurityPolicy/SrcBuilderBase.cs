namespace Sidio.Web.Security.Headers.Options.ContentSecurityPolicy;

/// <summary>
/// The builder for the Content Security Policy directive 'src'.
/// </summary>
public abstract class SrcBuilderBase<T> : ISrcBuilder
    where T : class, ISrcBuilder
{
    protected readonly HashSet<string> Sources = new();

    protected T This => this as T ?? throw new InvalidOperationException();

    internal IReadOnlyCollection<string> SourcesInternal => Sources;

    /// <summary>
    /// Add the 'self' source to the directive.
    /// </summary>
    /// <returns></returns>
    public T AllowSelf()
    {
        Sources.Add("'self'");
        return This;
    }

    /// <summary>
    /// Add the wildcard source to the directive.
    /// </summary>
    /// <returns></returns>
    public T AllowAll()
    {
        Sources.Add("*");
        return This;
    }

    /// <summary>
    /// Add a URL source to the directive.
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public T AllowUrl(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            throw new ArgumentException("The URL should not be null or empty.", nameof(url));
        }

        Sources.Add(url);
        return This;
    }

    /// <summary>
    /// Add the 'none' source to the directive.
    /// </summary>
    /// <returns></returns>
    public T AllowNone()
    {
        Sources.Add("'none'");
        return This;
    }

    /// <summary>
    /// Add the 'data:' to the directive.
    /// </summary>
    /// <returns></returns>
    public T AllowData()
    {
        Sources.Add("data:");
        return This;
    }

    /// <summary>
    /// Adds the 'unsafe-inline' to the directive.
    /// </summary>
    /// <returns></returns>
    public T AllowUnsafeInline()
    {
        Sources.Add("'unsafe-inline'");
        return This;
    }

    /// <summary>
    /// Adds the 'https:' to the directives.
    /// </summary>
    /// <returns></returns>
    public T AllowHttp()
    {
        Sources.Add("http:");
        return This;
    }

    /// <summary>
    /// Adds the 'https:' to the directives.
    /// </summary>
    /// <returns></returns>
    public T AllowHttps()
    {
        Sources.Add("https:");
        return This;
    }

    /// <summary>
    /// Adds the 'mediastream:' to the directives.
    /// </summary>
    /// <returns></returns>
    public T AllowMediaStream()
    {
        Sources.Add("mediastream:");
        return This;
    }

    /// <summary>
    /// Adds the 'blob:' to the directives.
    /// </summary>
    /// <returns></returns>
    public T AllowBlob()
    {
        Sources.Add("blob:");
        return This;
    }

    /// <summary>
    /// Adds the 'filesystem:' to the directives.
    /// </summary>
    /// <returns></returns>
    public T AllowFileSystem()
    {
        Sources.Add("filesystem:");
        return This;
    }

    /// <summary>
    /// Adds the 'report-sample' to the directives.
    /// </summary>
    /// <returns></returns>
    public T ShouldReportSample()
    {
        Sources.Add("'report-sample'");
        return This;
    }

    /// <summary>
    /// Adds the 'allow-duplicates' to the directives.
    /// </summary>
    /// <returns></returns>
    public T AllowDuplicates()
    {
        Sources.Add("'allow-duplicates'");
        return This;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return string.Join(" ", Sources);
    }
}