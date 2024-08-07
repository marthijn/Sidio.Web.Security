namespace Sidio.Web.Security.Headers.Options.ContentSecurityPolicy;

/// <summary>
/// The builder for the Content Security Policy directive 'src'.
/// </summary>
public abstract class SrcBuilderBase<T> : ISrcBuilder
    where T : class, ISrcBuilder
{
    internal readonly HashSet<string> Sources = new();

    /// <summary>
    /// Add the 'self' source to the directive.
    /// </summary>
    /// <returns></returns>
    public SrcBuilderBase<T> AllowSelf()
    {
        Sources.Add("'self'");
        return this;
    }

    /// <summary>
    /// Add the wildcard source to the directive.
    /// </summary>
    /// <returns></returns>
    public SrcBuilderBase<T> AllowAll()
    {
        Sources.Add("*");
        return this;
    }

    /// <summary>
    /// Add a URL source to the directive.
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public SrcBuilderBase<T> AllowUrl(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            throw new ArgumentException("The URL should not be null or empty.", nameof(url));
        }

        Sources.Add(url);
        return this;
    }

    /// <summary>
    /// Add the 'none' source to the directive.
    /// </summary>
    /// <returns></returns>
    public SrcBuilderBase<T> AllowNone()
    {
        Sources.Add("'none'");
        return this;
    }

    /// <summary>
    /// Add the 'data:' to the directive.
    /// </summary>
    /// <returns></returns>
    public SrcBuilderBase<T> AllowData()
    {
        Sources.Add("data:");
        return this;
    }

    /// <summary>
    /// Adds the 'unsafe-inline' to the directive.
    /// </summary>
    /// <returns></returns>
    public SrcBuilderBase<T> AllowUnsafeInline()
    {
        Sources.Add("'unsafe-inline'");
        return this;
    }

    /// <summary>
    /// Adds the 'https:' to the directives.
    /// </summary>
    /// <returns></returns>
    public SrcBuilderBase<T> AllowHttp()
    {
        Sources.Add("http:");
        return this;
    }

    /// <summary>
    /// Adds the 'https:' to the directives.
    /// </summary>
    /// <returns></returns>
    public SrcBuilderBase<T> AllowHttps()
    {
        Sources.Add("https:");
        return this;
    }

    /// <summary>
    /// Adds the 'mediastream:' to the directives.
    /// </summary>
    /// <returns></returns>
    public SrcBuilderBase<T> AllowMediaStream()
    {
        Sources.Add("mediastream:");
        return this;
    }

    /// <summary>
    /// Adds the 'blob:' to the directives.
    /// </summary>
    /// <returns></returns>
    public SrcBuilderBase<T> AllowBlob()
    {
        Sources.Add("blob:");
        return this;
    }

    /// <summary>
    /// Adds the 'filesystem:' to the directives.
    /// </summary>
    /// <returns></returns>
    public SrcBuilderBase<T> AllowFileSystem()
    {
        Sources.Add("filesystem:");
        return this;
    }

    /// <summary>
    /// Adds the 'report-sample' to the directives.
    /// </summary>
    /// <returns></returns>
    public SrcBuilderBase<T> ShouldReportSample()
    {
        Sources.Add("'report-sample'");
        return this;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return string.Join(" ", Sources);
    }
}