using Sidio.Web.Security.Headers.Options.ContentSecurityPolicy;

namespace Sidio.Web.Security.Headers.Options;

public sealed class ContentSecurityPolicyHeaderOptionsBuilder
{
    private readonly ContentSecurityPolicyHeaderOptions _options = new();

    /// <summary>
    /// Adds the 'default-src' directive to the Content Security Policy, which serves as a fallback
    /// for other directives.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public ContentSecurityPolicyHeaderOptionsBuilder AddDefaultSrc(Func<SrcBuilder, SrcBuilderBase<SrcBuilder>> builder)
    {
        var srcBuilder = new SrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.DefaultSrc = result.ToString();
        return this;
    }

    public ContentSecurityPolicyHeaderOptionsBuilder AddScriptSrc(Func<ScriptSrcBuilder, ScriptSrcBuilder> builder)
    {
        var srcBuilder = new ScriptSrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.ScriptSrc = result.ToString();
        return this;
    }

    public ContentSecurityPolicyHeaderOptionsBuilder AddStyleSrc(Func<StyleSrcBuilder, StyleSrcBuilder> builder)
    {
        var srcBuilder = new StyleSrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.StyleSrc = result.ToString();
        return this;
    }

    public ContentSecurityPolicyHeaderOptionsBuilder AddImgSrc(Func<SrcBuilder, SrcBuilder> builder)
    {
        var srcBuilder = new SrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.ImgSrc = result.ToString();
        return this;
    }

    public ContentSecurityPolicyHeaderOptionsBuilder AddConnectSrc(Func<SrcBuilder, SrcBuilder> builder)
    {
        var srcBuilder = new SrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.ConnectSrc = result.ToString();
        return this;
    }

    public ContentSecurityPolicyHeaderOptionsBuilder AddFontSrc(Func<SrcBuilder, SrcBuilder> builder)
    {
        var srcBuilder = new SrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.FontSrc = result.ToString();
        return this;
    }

    public ContentSecurityPolicyHeaderOptionsBuilder AddObjectSrc(Func<SrcBuilder, SrcBuilder> builder)
    {
        var srcBuilder = new SrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.ObjectSrc = result.ToString();
        return this;
    }

    public ContentSecurityPolicyHeaderOptionsBuilder AddMediaSrc(Func<SrcBuilder, SrcBuilder> builder)
    {
        var srcBuilder = new SrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.MediaSrc = result.ToString();
        return this;
    }

    public ContentSecurityPolicyHeaderOptionsBuilder AddFrameSrc(Func<SrcBuilder, SrcBuilder> builder)
    {
        var srcBuilder = new SrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.FrameSrc = result.ToString();
        return this;
    }

    public ContentSecurityPolicyHeaderOptionsBuilder AddChildSrc(Func<SrcBuilder, SrcBuilder> builder)
    {
        var srcBuilder = new SrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.ChildSrc = result.ToString();
        return this;
    }

    public ContentSecurityPolicyHeaderOptionsBuilder AddFormAction(Func<SrcBuilder, SrcBuilder> builder)
    {
        var srcBuilder = new SrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.FormAction = result.ToString();
        return this;
    }

    /// <summary>
    /// Restricts the URLs which can be used in a document's base-element.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public ContentSecurityPolicyHeaderOptionsBuilder AddBaseUri(Func<SrcBuilder, SrcBuilder> builder)
    {
        var srcBuilder = new SrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.BaseUri = result.ToString();
        return this;
    }

    public ContentSecurityPolicyHeaderOptionsBuilder AddWorkerSrc(Func<SrcBuilder, SrcBuilder> builder)
    {
        var srcBuilder = new SrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.WorkerSrc = result.ToString();
        return this;
    }

    public ContentSecurityPolicyHeaderOptionsBuilder AddManifestSrc(Func<SrcBuilder, SrcBuilder> builder)
    {
        var srcBuilder = new SrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.ManifestSrc = result.ToString();
        return this;
    }

    [Obsolete("This feature is no longer recommended.")]
    public ContentSecurityPolicyHeaderOptionsBuilder AddPrefetchSrc(Func<SrcBuilder, SrcBuilder> builder)
    {
        var srcBuilder = new SrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.PrefetchSrc = builder.ToString();
        return this;
    }

    public ContentSecurityPolicyHeaderOptionsBuilder AddFencedFrameSrc(Func<SrcBuilder, SrcBuilder> builder)
    {
        var srcBuilder = new SrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.FencedFrameSrc = result.ToString();
        return this;
    }

    public ContentSecurityPolicyHeaderOptionsBuilder AddSandbox()
    {
        return this;
    }

    [Obsolete("This feature is no longer recommended, use report-to instead.")]
    public ContentSecurityPolicyHeaderOptionsBuilder AddReportUri(string uri)
    {
        _options.ReportUri = uri;
        return this;
    }

    public ContentSecurityPolicyHeaderOptionsBuilder SetFrameAncestors(string value = "'none'")
    {
        _options.FrameAncestors = value;
        return this;
    }

    public ContentSecurityPolicyHeaderOptionsBuilder AddPluginTypes(string value)
    {
        _options.PluginTypes = value;
        return this;
    }

    public ContentSecurityPolicyHeaderOptionsBuilder AddReportTo(string group)
    {
        _options.ReportTo = group;
        return this;
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public ContentSecurityPolicyHeaderOptionsBuilder RequireTrustedTypesForScript()
    {
        _options.RequireTrustedTypesFor = "'script'";
        return this;
    }

    public ContentSecurityPolicyHeaderOptionsBuilder TrustedTypes()
    {
        return this;
    }

    public ContentSecurityPolicyHeaderOptions Build() => _options;
}