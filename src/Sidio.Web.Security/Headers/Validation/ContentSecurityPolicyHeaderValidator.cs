using System.Text.RegularExpressions;
using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Headers.Options.ContentSecurityPolicy;

namespace Sidio.Web.Security.Headers.Validation;

/// <summary>
/// The Content-Security-Policy header validator.
/// </summary>
public sealed partial class ContentSecurityPolicyHeaderValidator : IHeaderValidator<ContentSecurityPolicyHeaderOptions>
{
    /// <inheritdoc />
    public HeaderValidationResult Validate(string? headerValue, out ContentSecurityPolicyHeaderOptions? options)
    {
        if (headerValue.IsNullOrWhiteSpace(out var validations))
        {
            options = null;
            return new HeaderValidationResult(validations);
        }

        options = new ContentSecurityPolicyHeaderOptions();

        var headerValueLower = headerValue.ToLowerInvariant();
        ParseHeaderValue(headerValueLower, ref options);

        var result = Validate(options);
        if (!result.IsValid)
        {
            options = null;
        }

        return result;
    }

    /// <inheritdoc />
    public HeaderValidationResult Validate(ContentSecurityPolicyHeaderOptions options)
    {
        var validationResult = new List<HeaderValidation>();

        validationResult.AddRange(Warnings(options));
        validationResult.AddRange(Errors(options));

        return new HeaderValidationResult(validationResult);
    }

    private static void ParseHeaderValue(string headerValue, ref ContentSecurityPolicyHeaderOptions options)
    {
        // src
        options.DefaultSrc = GetDirectiveValue(Directives.DefaultSrc, headerValue);
        options.ScriptSrc = GetDirectiveValue(Directives.ScriptSrc, headerValue);
        options.ScriptSrcAttr = GetDirectiveValue(Directives.ScriptSrcAttr, headerValue);
        options.ScriptSrcElem = GetDirectiveValue(Directives.ScriptSrcElem, headerValue);
        options.StyleSrc = GetDirectiveValue(Directives.StyleSrc, headerValue);
        options.StyleSrcAttr = GetDirectiveValue(Directives.StyleSrcAttr, headerValue);
        options.StyleSrcElem = GetDirectiveValue(Directives.StyleSrcElem, headerValue);
        options.ImgSrc = GetDirectiveValue(Directives.ImgSrc, headerValue);
        options.PrefetchSrc = GetDirectiveValue(Directives.PrefetchSrc, headerValue);
        options.ConnectSrc = GetDirectiveValue(Directives.ConnectSrc, headerValue);
        options.FontSrc = GetDirectiveValue(Directives.FontSrc, headerValue);
        options.ObjectSrc = GetDirectiveValue(Directives.ObjectSrc, headerValue);
        options.MediaSrc = GetDirectiveValue(Directives.MediaSrc, headerValue);
        options.FrameSrc = GetDirectiveValue(Directives.FrameSrc, headerValue);
        options.ChildSrc = GetDirectiveValue(Directives.ChildSrc, headerValue);
        options.WorkerSrc = GetDirectiveValue(Directives.WorkerSrc, headerValue);
        options.ManifestSrc = GetDirectiveValue(Directives.ManifestSrc, headerValue);
        options.FormAction = GetDirectiveValue(Directives.FormAction, headerValue);
        options.FrameAncestors = GetDirectiveValue(Directives.FrameAncestors, headerValue);
        options.BaseUri = GetDirectiveValue(Directives.BaseUri, headerValue);
        options.FencedFrameSrc = GetDirectiveValue(Directives.FencedFrameSrc, headerValue);

        // other
        options.Sandbox = GetDirectiveValue(Directives.Sandbox, headerValue) ??
                          (GetDirectiveBoolValue(Directives.Sandbox, headerValue) ? string.Empty : null);
        options.ReportTo = GetDirectiveValue(Directives.ReportTo, headerValue);
        options.RequireTrustedTypesFor = GetDirectiveValue(Directives.RequireTrustedTypesFor, headerValue);
        options.TrustedTypes = GetDirectiveValue(Directives.TrustedTypes, headerValue) ??
                               (GetDirectiveBoolValue(Directives.TrustedTypes, headerValue) ? string.Empty : null);

        // deprecated or unofficial
        options.ReportUri = GetDirectiveValue(Directives.ReportUri, headerValue);
        options.NavigateTo = GetDirectiveValue(Directives.NavigateTo, headerValue);
        options.UpgradeInsecureRequests = GetDirectiveBoolValue(Directives.UpgradeInsecureRequests, headerValue);
        options.BlockAllMixedContent = GetDirectiveBoolValue(Directives.BlockAllMixedContent, headerValue);
    }

#if NET7_0_OR_GREATER
    private static string? GetDirectiveValue([System.Diagnostics.CodeAnalysis.ConstantExpected] string directive, string headerValue)
#else
    private static string? GetDirectiveValue(string directive, string headerValue)
#endif
    {
        var regex = new Regex($@"{directive}\s+([a-z0-9.'\s-\*:/]*)");
        var match = regex.Match(headerValue);
        if (match.Success)
        {
            return match.Groups[1].Value.Trim();
        }

        return null;
    }

#if NET7_0_OR_GREATER
    private static bool GetDirectiveBoolValue([System.Diagnostics.CodeAnalysis.ConstantExpected] string directive, string headerValue)
#else
    private static bool GetDirectiveBoolValue(string directive, string headerValue)
#endif
    {
        var regex = new Regex($@"{directive}");
        var match = regex.Match(headerValue);
        return match.Success;
    }

    private static IReadOnlyCollection<HeaderValidation> Warnings(ContentSecurityPolicyHeaderOptions options)
    {
        var validationResult = new List<HeaderValidation>();

        if (!string.IsNullOrWhiteSpace(options.ReportUri))
        {
            validationResult.Add(
                new HeaderValidation(
                    HeaderValidationSeverityLevel.Warning,
                    "The report-uri directive is deprecated. Use the report-to directive instead."));
        }

        if (!string.IsNullOrWhiteSpace(options.PrefetchSrc))
        {
            validationResult.Add(
                new HeaderValidation(
                    HeaderValidationSeverityLevel.Warning,
                    "The prefetch-src directive is not recommended."));
        }

        if (!string.IsNullOrWhiteSpace(options.NavigateTo))
        {
            validationResult.Add(
                new HeaderValidation(
                    HeaderValidationSeverityLevel.Warning,
                    "The navigate-to directive is removed from the CSP 3 specification."));
        }

        if (options.BlockAllMixedContent)
        {
            validationResult.Add(
                new HeaderValidation(
                    HeaderValidationSeverityLevel.Warning,
                    "The block-all-mixed-content directive is not part of the CSP specification."));
        }

        return validationResult;
    }

    private static IReadOnlyCollection<HeaderValidation> Errors(ContentSecurityPolicyHeaderOptions options)
    {
        var validationResult = new List<HeaderValidation>();

        if (options.Sandbox != null && !options.Sandbox.TryToEnum(out Sandbox _))
        {
            options.Sandbox = null;
            validationResult.Add(
                new HeaderValidation(
                    HeaderValidationSeverityLevel.Error,
                    "The sandbox directive contains an invalid value."));
        }

        if (options.ReportTo != null && !IsValidReportTo(options.ReportTo))
        {
            validationResult.Add(
                new HeaderValidation(
                    HeaderValidationSeverityLevel.Error,
                    "The report-to header is empty or contains an invalid value."));
        }

        return validationResult;
    }
}