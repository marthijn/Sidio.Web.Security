using Sidio.Http.Security.Headers.Options.ContentSecurityPolicy;

namespace Sidio.Http.Security.Headers.Options;

public sealed class ContentSecurityPolicyHeaderOptions : IHttpHeaderOptions
{
    public string? DefaultSrc { get; set; }

    public string? ScriptSrc { get; set; }

    public string? StyleSrc { get; set; }

    public string? ImgSrc { get; set; }

    public string? ConnectSrc { get; set; }

    public string? FontSrc { get; set; }

    public string? ObjectSrc { get; set; }

    public string? MediaSrc { get; set; }

    public string? FrameSrc { get; set; }

    public string? ChildSrc { get; set; }

    public string? WorkerSrc { get; set; }

    public string? ManifestSrc { get; set; }

    /// <summary>
    /// Gets or sets a value that defines valid sources for request prefetch and prerendering.
    /// </summary>
    /// <remarks>This feature is no longer recommended.</remarks>
    public string? PrefetchSrc { get; set; }

    public string? Sandbox { get; set; }

    /// <summary>
    ///
    /// </summary>
    /// <remarks>This feature is no longer recommended, use report-to instead.</remarks>
    [Obsolete("This feature is no longer recommended, use report-to instead.")]
    public string? ReportUri { get; set; }

    public string? FormAction { get; set; }

    public string? FrameAncestors { get; set; }

    public string? PluginTypes { get; set; }

    public string? BaseUri { get; set; }

    public string? FencedFrameSrc { get; set; }

    public string? ReportTo { get; set; }

    /// <summary>
    /// Gets or sets a value that restricts the URL that the document may navigate to.
    /// </summary>
    /// <remarks>Removed from the CSP 3 Spec.</remarks>
    public string? NavigateTo { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the browser should upgrade http to https.
    /// </summary>
    /// <remarks>This directive is not part of the CSP specification.</remarks>
    public bool UpgradeInsecureRequests { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the browser should block all mixed content.
    /// </summary>
    /// <remarks>This directive is not part of the CSP specification.</remarks>
    public bool BlockAllMixedContent { get; set; }

    public string? RequireTrustedTypesFor { get; set; }

    public string Value => ToString();

    public override string ToString()
    {
        var policies = new List<string>();

        policies
            .AddIfNotNull(Directives.DefaultSrc, DefaultSrc)
            .AddIfNotNull(Directives.ScriptSrc, ScriptSrc)
            .AddIfNotNull(Directives.StyleSrc, StyleSrc)
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
            .AddIfNotNull(Directives.PluginTypes, PluginTypes)
            .AddIfNotNull(Directives.RequireTrustedTypesFor, RequireTrustedTypesFor)
            .AddIfNotNull(Directives.ReportUri, ReportUri)
            .AddIfNotNull(Directives.NavigateTo, NavigateTo)
            .AddIfTrue(Directives.UpgradeInsecureRequests, UpgradeInsecureRequests)
            .AddIfTrue(Directives.BlockAllMixedContent, BlockAllMixedContent);

        return string.Join("; ", policies);
    }
}