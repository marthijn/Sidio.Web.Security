namespace Sidio.Web.Security.Headers.Options.ContentSecurityPolicy;

/// <summary>
/// The Content Security Policy directives.
/// </summary>
public static class Directives
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public const string DefaultSrc = "default-src";
    public const string ScriptSrc = "script-src";
    public const string ScriptSrcAttr = "script-src-attr";
    public const string ScriptSrcElem = "script-src-elem";
    public const string StyleSrc = "style-src";
    public const string StyleSrcAttr = "style-src-attr";
    public const string StyleSrcElem = "style-src-elem";
    public const string ImgSrc = "img-src";
    public const string ConnectSrc = "connect-src";
    public const string FontSrc = "font-src";
    public const string ObjectSrc = "object-src";
    public const string MediaSrc = "media-src";
    public const string FrameSrc = "frame-src";
    public const string ChildSrc = "child-src";
    public const string WorkerSrc = "worker-src";
    public const string ManifestSrc = "manifest-src";
    public const string PrefetchSrc = "prefetch-src";
    public const string FormAction = "form-action";
    public const string FrameAncestors = "frame-ancestors";
    public const string BaseUri = "base-uri";
    public const string FencedFrameSrc = "fenced-frame-src";

    public const string Sandbox = "sandbox";
    public const string ReportTo = "report-to";
    public const string RequireTrustedTypesFor = "require-trusted-types-for";
    public const string TrustedTypes = "trusted-types";

    public const string ReportUri = "report-uri";
    public const string NavigateTo = "navigate-to";
    public const string UpgradeInsecureRequests = "upgrade-insecure-requests";
    public const string BlockAllMixedContent = "block-all-mixed-content";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}