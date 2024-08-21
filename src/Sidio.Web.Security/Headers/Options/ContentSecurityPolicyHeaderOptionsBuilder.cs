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
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="ContentSecurityPolicyHeaderOptionsBuilder"/>.</returns>
    public ContentSecurityPolicyHeaderOptionsBuilder AddDefaultSrc(Func<SrcBuilder, SrcBuilderBase<SrcBuilder>> builder)
    {
        var srcBuilder = new SrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.DefaultSrc = result.ToString();
        return this;
    }

    /// <summary>
    /// Adds the 'script-src' directive to the Content Security Policy, which specifies valid sources for JavaScript.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="ContentSecurityPolicyHeaderOptionsBuilder"/>.</returns>
    public ContentSecurityPolicyHeaderOptionsBuilder AddScriptSrc(Func<ScriptSrcBuilder, ScriptSrcBuilder> builder)
    {
        var srcBuilder = new ScriptSrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.ScriptSrc = result.ToString();
        return this;
    }

    /// <summary>
    /// Adds the 'script-src-attr' directive to the Content Security Policy, which specifies valid sources for JavaScript inline event handlers.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="ContentSecurityPolicyHeaderOptionsBuilder"/>.</returns>
    public ContentSecurityPolicyHeaderOptionsBuilder AddScriptSrcAttr(Func<ScriptSrcBuilder, ScriptSrcBuilder> builder)
    {
        var srcBuilder = new ScriptSrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.ScriptSrcAttr = result.ToString();
        return this;
    }

    /// <summary>
    /// Adds the 'script-src-elem' directive to the Content Security Policy, which specifies valid sources for JavaScript script elements.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="ContentSecurityPolicyHeaderOptionsBuilder"/>.</returns>
    public ContentSecurityPolicyHeaderOptionsBuilder AddScriptSrcElem(Func<ScriptSrcBuilder, ScriptSrcBuilder> builder)
    {
        var srcBuilder = new ScriptSrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.ScriptSrcElem = result.ToString();
        return this;
    }

    /// <summary>
    /// Adds the 'style-src' directive to the Content Security Policy, which specifies valid sources for stylesheets.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="ContentSecurityPolicyHeaderOptionsBuilder"/>.</returns>
    public ContentSecurityPolicyHeaderOptionsBuilder AddStyleSrc(Func<StyleSrcBuilder, StyleSrcBuilder> builder)
    {
        var srcBuilder = new StyleSrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.StyleSrc = result.ToString();
        return this;
    }

    /// <summary>
    /// Adds the 'style-src-attr' directive to the Content Security Policy, which specifies valid sources for inline styles applied to individual DOM elements.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="ContentSecurityPolicyHeaderOptionsBuilder"/>.</returns>
    public ContentSecurityPolicyHeaderOptionsBuilder AddStyleSrcAttr(Func<StyleSrcBuilder, StyleSrcBuilder> builder)
    {
        var srcBuilder = new StyleSrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.StyleSrcAttr = result.ToString();
        return this;
    }

    /// <summary>
    /// Adds the 'style-src-elem' directive to the Content Security Policy, which specifies valid sources for stylesheet style elements and link elements with rel="stylesheet".
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="ContentSecurityPolicyHeaderOptionsBuilder"/>.</returns>
    public ContentSecurityPolicyHeaderOptionsBuilder AddStyleSrcElem(Func<StyleSrcBuilder, StyleSrcBuilder> builder)
    {
        var srcBuilder = new StyleSrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.StyleSrcElem = result.ToString();
        return this;
    }

    /// <summary>
    /// Adds the 'img-src' directive to the Content Security Policy, which specifies valid sources for images and favicons.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="ContentSecurityPolicyHeaderOptionsBuilder"/>.</returns>
    public ContentSecurityPolicyHeaderOptionsBuilder AddImgSrc(Func<SrcBuilder, SrcBuilder> builder)
    {
        var srcBuilder = new SrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.ImgSrc = result.ToString();
        return this;
    }

    /// <summary>
    /// Adds the 'connect-src' directive to the Content Security Policy, which restricts the URLs which can be loaded using script interfaces.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="ContentSecurityPolicyHeaderOptionsBuilder"/>.</returns>
    public ContentSecurityPolicyHeaderOptionsBuilder AddConnectSrc(Func<SrcBuilder, SrcBuilder> builder)
    {
        var srcBuilder = new SrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.ConnectSrc = result.ToString();
        return this;
    }

    /// <summary>
    /// Adds the 'font-src' directive to the Content Security Policy, which specifies valid sources for fonts loaded using @font-face.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="ContentSecurityPolicyHeaderOptionsBuilder"/>.</returns>
    public ContentSecurityPolicyHeaderOptionsBuilder AddFontSrc(Func<SrcBuilder, SrcBuilder> builder)
    {
        var srcBuilder = new SrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.FontSrc = result.ToString();
        return this;
    }

    /// <summary>
    /// Adds the 'object-src' directive to the Content Security Policy, which specifies valid sources for the object, embed, and applet elements.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="ContentSecurityPolicyHeaderOptionsBuilder"/>.</returns>
    public ContentSecurityPolicyHeaderOptionsBuilder AddObjectSrc(Func<SrcBuilder, SrcBuilder> builder)
    {
        var srcBuilder = new SrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.ObjectSrc = result.ToString();
        return this;
    }

    /// <summary>
    /// Adds the 'media-src' directive to the Content Security Policy, which specifies valid sources for loading media using the audio and video elements.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="ContentSecurityPolicyHeaderOptionsBuilder"/>.</returns>
    public ContentSecurityPolicyHeaderOptionsBuilder AddMediaSrc(Func<SrcBuilder, SrcBuilder> builder)
    {
        var srcBuilder = new SrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.MediaSrc = result.ToString();
        return this;
    }

    /// <summary>
    /// Adds the 'frame-src' directive to the Content Security Policy, which specifies valid sources for loading frames.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="ContentSecurityPolicyHeaderOptionsBuilder"/>.</returns>
    public ContentSecurityPolicyHeaderOptionsBuilder AddFrameSrc(Func<SrcBuilder, SrcBuilder> builder)
    {
        var srcBuilder = new SrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.FrameSrc = result.ToString();
        return this;
    }

    /// <summary>
    /// Adds the 'child-src' directive to the Content Security Policy, which specifies valid sources for loading frames.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="ContentSecurityPolicyHeaderOptionsBuilder"/>.</returns>
    public ContentSecurityPolicyHeaderOptionsBuilder AddChildSrc(Func<SrcBuilder, SrcBuilder> builder)
    {
        var srcBuilder = new SrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.ChildSrc = result.ToString();
        return this;
    }

    /// <summary>
    /// Adds the 'form-action' directive to the Content Security Policy, which specifies valid sources for form submissions.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="ContentSecurityPolicyHeaderOptionsBuilder"/>.</returns>
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
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="ContentSecurityPolicyHeaderOptionsBuilder"/>.</returns>
    public ContentSecurityPolicyHeaderOptionsBuilder AddBaseUri(Func<SrcBuilder, SrcBuilder> builder)
    {
        var srcBuilder = new SrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.BaseUri = result.ToString();
        return this;
    }

    /// <summary>
    /// Adds the 'worker-src' directive to the Content Security Policy, which specifies valid sources for Worker, SharedWorker, or ServiceWorker scripts.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="ContentSecurityPolicyHeaderOptionsBuilder"/>.</returns>
    public ContentSecurityPolicyHeaderOptionsBuilder AddWorkerSrc(Func<SrcBuilder, SrcBuilder> builder)
    {
        var srcBuilder = new SrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.WorkerSrc = result.ToString();
        return this;
    }

    /// <summary>
    /// Adds the 'manifest-src' directive to the Content Security Policy, which specifies valid sources for the application manifest.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="ContentSecurityPolicyHeaderOptionsBuilder"/>.</returns>
    public ContentSecurityPolicyHeaderOptionsBuilder AddManifestSrc(Func<SrcBuilder, SrcBuilder> builder)
    {
        var srcBuilder = new SrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.ManifestSrc = result.ToString();
        return this;
    }

    /// <summary>
    /// Adds the 'prefetch-src' directive to the Content Security Policy, which specifies valid sources for request prefetch and prerendering.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="ContentSecurityPolicyHeaderOptionsBuilder"/>.</returns>
    [Obsolete("This feature is no longer recommended.")]
    public ContentSecurityPolicyHeaderOptionsBuilder AddPrefetchSrc(Func<SrcBuilder, SrcBuilder> builder)
    {
        var srcBuilder = new SrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.PrefetchSrc = result.ToString();
        return this;
    }

    /// <summary>
    /// Adds the 'fenced-frame-src' directive to the Content Security Policy, which specifies valid sources for nested browsing contexts loading using elements such as frame and iframe.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="ContentSecurityPolicyHeaderOptionsBuilder"/>.</returns>
    public ContentSecurityPolicyHeaderOptionsBuilder AddFencedFrameSrc(Func<SrcBuilder, SrcBuilder> builder)
    {
        var srcBuilder = new SrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.FencedFrameSrc = result.ToString();
        return this;
    }

    /// <summary>
    /// Adds the 'sandbox' directive to the Content Security Policy, which enables a sandbox for the requested resource similar to the iframe sandbox attribute.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>The <see cref="ContentSecurityPolicyHeaderOptionsBuilder"/>.</returns>
    public ContentSecurityPolicyHeaderOptionsBuilder AddSandbox(Sandbox value = Sandbox.Default)
    {
        _options.Sandbox = value.ToStringValue();
        return this;
    }

    /// <summary>
    /// Adds the 'report-uri' directive to the Content Security Policy, which instructs the user agent to report attempts to violate the Content Security Policy.
    /// </summary>
    /// <param name="uris"></param>
    /// <returns>The <see cref="ContentSecurityPolicyHeaderOptionsBuilder"/>.</returns>
    /// <exception cref="ArgumentException"></exception>
    [Obsolete("This feature is no longer recommended, use report-to instead.")]
    public ContentSecurityPolicyHeaderOptionsBuilder AddReportUri(params string[] uris)
    {
        if (uris.Length == 0)
        {
            throw new ArgumentException("At least one URI should be provided.", nameof(uris));
        }

        _options.ReportUri = string.Join(" ", uris).Trim();
        return this;
    }

    /// <summary>
    /// Adds the 'frame-ancestors' directive to the Content Security Policy, which specifies valid sources for embedding the resource using frame, iframe, object, embed, or applet.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="ContentSecurityPolicyHeaderOptionsBuilder"/>.</returns>
    public ContentSecurityPolicyHeaderOptionsBuilder SetFrameAncestors(Func<SrcBuilder, SrcBuilder> builder)
    {
        var srcBuilder = new SrcBuilder();
        var result = builder.Invoke(srcBuilder);
        _options.FrameAncestors = result.ToString();
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
    /// Instructs user agents to control the data passed to DOM XSS sink functions.
    /// When used, those functions only accept non-spoofable, typed values created by Trusted Type policies, and reject strings.
    /// </summary>
    /// <returns>The <see cref="ContentSecurityPolicyHeaderOptionsBuilder"/>.</returns>
    public ContentSecurityPolicyHeaderOptionsBuilder RequireTrustedTypesForScript()
    {
        _options.RequireTrustedTypesFor = "'script'";
        return this;
    }

    /// <summary>
    /// Adds the 'trusted-types' directive to the Content Security Policy, which restricts the creation of Trusted Types policies.
    /// </summary>
    /// <param name="allowDuplicates"></param>
    /// <param name="policyNames"></param>
    /// <returns>The <see cref="ContentSecurityPolicyHeaderOptionsBuilder"/>.</returns>
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
    /// <returns>The <see cref="ContentSecurityPolicyHeaderOptionsBuilder"/>.</returns>
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