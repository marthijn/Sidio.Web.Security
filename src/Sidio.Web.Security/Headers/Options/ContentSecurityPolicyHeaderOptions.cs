using Sidio.Web.Security.Headers.Options.ContentSecurityPolicy;

namespace Sidio.Web.Security.Headers.Options;

public sealed class ContentSecurityPolicyHeaderOptions : IHttpHeaderOptions
{
    /// <summary>
    /// Gets or sets a value that services as a fallback for the other Content Security Policy fetch directives.
    /// </summary>
    public string? DefaultSrc { get; set; }

    /// <summary>
    /// Gets or sets a value that specifies valid sources for JavaScript. This includes script elements, inline handlers
    /// and XSLT stylesheets which can trigger script execution.
    /// </summary>
    public string? ScriptSrc { get; set; }

    /// <summary>
    /// Gets or sets a value that specifies valid sources for JavaScript inline event handlers
    /// </summary>
    public string? ScriptSrcAttr { get; set; }

    /// <summary>
    /// Gets or sets a value that specifies valid sources for JavaScript script elements.
    /// </summary>
    public string? ScriptSrcElem { get; set; }

    /// <summary>
    /// Gets or sets a value that specifies valid sources for stylesheets.
    /// </summary>
    public string? StyleSrc { get; set; }

    /// <summary>
    /// Gets or sets a value that specifies valid sources for inline styles applied to individual DOM elements.
    /// </summary>
    public string? StyleSrcAttr { get; set; }

    /// <summary>
    /// Gets or sets a value that specifies valid sources for stylesheet style elements and link elements
    /// with rel="stylesheet".
    /// </summary>
    public string? StyleSrcElem { get; set; }

    /// <summary>
    /// Gets or sets a value that specifies valid sources for images and favicons.
    /// </summary>
    public string? ImgSrc { get; set; }

    /// <summary>
    /// Gets or sets a value that restricts the URLs which can be loaded using script interfaces.
    /// </summary>
    public string? ConnectSrc { get; set; }

    /// <summary>
    /// Gets or sets a value that specifies valid sources for fonts loaded using @font-face.
    /// </summary>
    public string? FontSrc { get; set; }

    /// <summary>
    /// Gets or sets a value that specifies valid sources for the object and embed elements.
    /// </summary>
    public string? ObjectSrc { get; set; }

    /// <summary>
    /// Gets or sets a value that specifies valid sources for the audio and video elements.
    /// </summary>
    public string? MediaSrc { get; set; }

    /// <summary>
    /// Gets or sets a value that specifies valid sources for nested browsing contexts loading using elements such as
    /// frame and iframe.
    /// </summary>
    public string? FrameSrc { get; set; }

    /// <summary>
    /// Gets or sets a value that defines the valid sources for web workers and nested browsing contexts loaded
    /// using elements such as frame and iframe.
    /// </summary>
    public string? ChildSrc { get; set; }

    /// <summary>
    /// Gets or sets a value that specifies valid sources for Worker, SharedWorker, or ServiceWorker scripts.
    /// </summary>
    public string? WorkerSrc { get; set; }

    /// <summary>
    /// Gets or sets a value that specifies valid sources for the application manifest.
    /// </summary>
    public string? ManifestSrc { get; set; }

    /// <summary>
    /// Gets or sets a value that defines valid sources for request prefetch and prerendering.
    /// </summary>
    /// <remarks>This feature is non-standard and is not on a standards track.</remarks>
    [Obsolete("This feature is non-standard and is not on a standards track.")]
    public string? PrefetchSrc { get; set; }

    /// <summary>
    /// Gets or sets a value that enables a sandbox for the requested resource similar to the iframe sandbox attribute.
    /// To enable the sandbox, the value must be an empty string or a space-separated list of directives.
    /// </summary>
    public string? Sandbox { get; set; }

    /// <summary>
    /// Gets or sets a value that instructs the user agent to report attempts to violate the Content Security Policy.
    /// </summary>
    /// <remarks>This feature is no longer recommended, use report-to instead.</remarks>
    [Obsolete("This feature is no longer recommended, use report-to instead.")]
    public string? ReportUri { get; set; }

    /// <summary>
    /// Gets or sets a value that restricts the URLs which may be used as the target of a
    /// form submissions from a given context.
    /// </summary>
    public string? FormAction { get; set; }

    /// <summary>
    /// Gets or sets a value that specifies valid parents that may embed a page using frame, iframe, object or embed.
    /// </summary>
    public string? FrameAncestors { get; set; }

    /// <summary>
    /// Gets or sets a value that restricts the URLs which may be loaded as a document's base URL.
    /// </summary>
    public string? BaseUri { get; set; }

    /// <summary>
    /// Gets or sets a value that specifies valid sources for nested browsing contexts loaded into fencedframe-elements.
    /// </summary>
    /// <remarks>This is an experimental technology.</remarks>
    public string? FencedFrameSrc { get; set; }

    /// <summary>
    /// Gets or sets a value that instructs the user agent to store reporting endpoints for an origin.
    /// The directive has no effect in and of itself, but only gains meaning in combination with other directives.
    /// </summary>
    public string? ReportTo { get; set; }

    /// <summary>
    /// Gets or sets a value that restricts the URL that the document may navigate to.
    /// </summary>
    /// <remarks>Removed from the CSP 3 Spec.</remarks>
    public string? NavigateTo { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the browser should upgrade http to https.
    /// </summary>
    public bool UpgradeInsecureRequests { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the browser should block all mixed content.
    /// </summary>
    /// <remarks>This directive is marked as obsolete in the specification.</remarks>
    public bool BlockAllMixedContent { get; set; }

    /// <summary>
    /// Gets or sets a value that instructs user agents to control the data passed to DOM XSS sink functions,
    /// like Element.innerHTML setter.
    /// </summary>
    /// <remarks>This is an experimental technology.</remarks>
    public string? RequireTrustedTypesFor { get; set; }

    /// <summary>
    /// Gets or sets a value that  instructs user agents to restrict the creation of Trusted Types
    /// policies - functions that build non-spoofable, typed values intended to be passed to DOM XSS
    /// sinks in place of strings.
    /// </summary>
    /// <remarks>This is an experimental technology.</remarks>
    public string? TrustedTypes { get; set; }

    public string Value => ToString();

    public override string ToString()
    {
        var policies = new List<string>();

        policies
            .AddIfNotNull(Directives.DefaultSrc, DefaultSrc)
            .AddIfNotNull(Directives.ScriptSrc, ScriptSrc)
            .AddIfNotNull(Directives.ScriptSrcAttr, ScriptSrcAttr)
            .AddIfNotNull(Directives.ScriptSrcElem, ScriptSrcElem)
            .AddIfNotNull(Directives.StyleSrc, StyleSrc)
            .AddIfNotNull(Directives.StyleSrcAttr, StyleSrcAttr)
            .AddIfNotNull(Directives.StyleSrcElem, StyleSrcElem)
            .AddIfNotNull(Directives.ImgSrc, ImgSrc)
            .AddIfNotNull(Directives.ConnectSrc, ConnectSrc)
            .AddIfNotNull(Directives.FontSrc, FontSrc)
            .AddIfNotNull(Directives.ObjectSrc, ObjectSrc)
            .AddIfNotNull(Directives.MediaSrc, MediaSrc)
            .AddIfNotNull(Directives.FrameSrc, FrameSrc)
            .AddIfNotNull(Directives.ChildSrc, ChildSrc)
            .AddIfNotNull(Directives.WorkerSrc, WorkerSrc)
            .AddIfNotNull(Directives.ManifestSrc, ManifestSrc)
            .AddIfNotNull(Directives.PrefetchSrc, PrefetchSrc)
            .AddIfNotNull(Directives.FormAction, FormAction)
            .AddIfNotNull(Directives.FrameAncestors, FrameAncestors)
            .AddIfNotNull(Directives.BaseUri, BaseUri)
            .AddIfNotNull(Directives.FencedFrameSrc, FencedFrameSrc)
            .AddIfNotNull(Directives.Sandbox, Sandbox)
            .AddIfNotNull(Directives.ReportTo, ReportTo)
            .AddIfNotNull(Directives.RequireTrustedTypesFor, RequireTrustedTypesFor)
            .AddIfNotNull(Directives.TrustedTypes, TrustedTypes)
            .AddIfNotNull(Directives.ReportUri, ReportUri)
            .AddIfNotNull(Directives.NavigateTo, NavigateTo)
            .AddIfTrue(Directives.UpgradeInsecureRequests, UpgradeInsecureRequests)
            .AddIfTrue(Directives.BlockAllMixedContent, BlockAllMixedContent);

        return string.Join("; ", policies);
    }
}