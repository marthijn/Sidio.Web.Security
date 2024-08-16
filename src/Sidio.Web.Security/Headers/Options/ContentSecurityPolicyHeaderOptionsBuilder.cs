using Sidio.Web.Security.Common;
using Sidio.Web.Security.Headers.Options.ContentSecurityPolicy;

namespace Sidio.Web.Security.Headers.Options;

/// <summary>
/// The builder for the Content Security Policy header options.
/// </summary>
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

    public ContentSecurityPolicyHeaderOptionsBuilder AddScriptSrcAttr(Func<ScriptSrcBuilder, ScriptSrcBuilder> builder)
    {
        var srcBuilder = new ScriptSrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.ScriptSrcAttr = result.ToString();
        return this;
    }

    public ContentSecurityPolicyHeaderOptionsBuilder AddScriptSrcElem(Func<ScriptSrcBuilder, ScriptSrcBuilder> builder)
    {
        var srcBuilder = new ScriptSrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.ScriptSrcElem = result.ToString();
        return this;
    }

    public ContentSecurityPolicyHeaderOptionsBuilder AddStyleSrc(Func<StyleSrcBuilder, StyleSrcBuilder> builder)
    {
        var srcBuilder = new StyleSrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.StyleSrc = result.ToString();
        return this;
    }

    public ContentSecurityPolicyHeaderOptionsBuilder AddStyleSrcAttr(Func<StyleSrcBuilder, StyleSrcBuilder> builder)
    {
        var srcBuilder = new StyleSrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.StyleSrcAttr = result.ToString();
        return this;
    }

    public ContentSecurityPolicyHeaderOptionsBuilder AddStyleSrcElem(Func<StyleSrcBuilder, StyleSrcBuilder> builder)
    {
        var srcBuilder = new StyleSrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.StyleSrcElem = result.ToString();
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
        _options.PrefetchSrc = result.ToString();
        return this;
    }

    public ContentSecurityPolicyHeaderOptionsBuilder AddFencedFrameSrc(Func<SrcBuilder, SrcBuilder> builder)
    {
        var srcBuilder = new SrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.FencedFrameSrc = result.ToString();
        return this;
    }

    public ContentSecurityPolicyHeaderOptionsBuilder AddSandbox(Sandbox value = Sandbox.Default)
    {
        _options.Sandbox = value.ToStringValue();
        return this;
    }

    [Obsolete("This feature is no longer recommended, use report-to instead.")]
    public ContentSecurityPolicyHeaderOptionsBuilder AddReportUri(params string[] uris)
    {
        if (uris.Length == 0)
        {
            throw new ArgumentException("At least one URI should be provided.", nameof(uris));
        }

        _options.ReportUri = string.Join(" ", uris).Trim();;
        return this;
    }

    public ContentSecurityPolicyHeaderOptionsBuilder SetFrameAncestors(params string[] sources)
    {
        if (sources.Length == 0)
        {
            throw new ArgumentException("At least one source should be provided.", nameof(sources));
        }

        _options.FrameAncestors = string.Join(" ", sources).Trim();
        return this;
    }

    /// <summary>
    /// Adds the name of the report group to send the reports to.
    /// </summary>
    /// <param name="groupName">The name of the group.</param>
    /// <remarks>Ensure the Report-To or Reporting-Endpoints are configured.</remarks>
    /// <returns>The <see cref="ContentSecurityPolicyHeaderOptionsBuilder"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when the group name is invalid.</exception>
    public ContentSecurityPolicyHeaderOptionsBuilder AddReportTo(string groupName)
    {
        if (string.IsNullOrWhiteSpace(groupName))
        {
            throw new ArgumentException("The group name should not be null or empty.", nameof(groupName));
        }

        _options.ReportTo = groupName;
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

    public ContentSecurityPolicyHeaderOptionsBuilder AddTrustedTypes(bool allowDuplicates = false, params string[] policyNames)
    {
        _options.TrustedTypes = string.Empty;
        if (policyNames.Length > 0)
        {
            _options.TrustedTypes = string.Join(" ", policyNames);
        }

        if (allowDuplicates)
        {
            _options.TrustedTypes += " 'allow-duplicates'";
        }

        _options.TrustedTypes = _options.TrustedTypes.Trim();
        return this;
    }

    /// <summary>
    /// Instructs user agents to treat all of a site's insecure URLs (those served over HTTP) as though they have
    /// been replaced with secure URLs (those served over HTTPS)
    /// </summary>
    /// <returns></returns>
    public ContentSecurityPolicyHeaderOptionsBuilder UpgradeInsecureRequests()
    {
        _options.UpgradeInsecureRequests = true;
        return this;
    }

    /// <summary>
    /// Builds the Content Security Policy header options.
    /// </summary>
    /// <returns>An instance of <see cref="ContentSecurityPolicyHeaderOptions"/>.</returns>
    public ContentSecurityPolicyHeaderOptions Build() => _options;
}