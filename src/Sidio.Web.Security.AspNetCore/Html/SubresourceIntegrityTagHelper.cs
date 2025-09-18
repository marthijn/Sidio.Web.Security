using System.Diagnostics.CodeAnalysis;
using System.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sidio.Web.Security.Cryptography;

namespace Sidio.Web.Security.AspNetCore.Html;

/// <summary>
/// The tag helper to add subresource integrity to the script or link tag.
/// </summary>
[HtmlTargetElement("script", Attributes = "src")]
[HtmlTargetElement("link", Attributes = "href,[rel='stylesheet']")]
[HtmlTargetElement("link", Attributes = "href,[rel='preload']")]
[HtmlTargetElement("link", Attributes = "href,[rel='modulepreload']")]
public sealed class SubresourceIntegrityTagHelper : TagHelper
{
    private const string IntegrityAttributeName = "integrity";
    private const string CrossOriginAttributeName = "crossorigin";
    private const string Anonymous = "anonymous";

    private readonly ISubresourceIntegrityHashService _subresourceIntegrityHashService;
    private readonly IOptions<TagHelperOptions> _options;
    private readonly ILogger<SubresourceIntegrityTagHelper> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="SubresourceIntegrityTagHelper"/> class.
    /// </summary>
    /// <param name="subresourceIntegrityHashService">The subresource integrity hash service.</param>
    /// <param name="options">The options.</param>
    /// <param name="logger">The logger.</param>
    public SubresourceIntegrityTagHelper(
        ISubresourceIntegrityHashService subresourceIntegrityHashService,
        IOptions<TagHelperOptions> options,
        ILogger<SubresourceIntegrityTagHelper> logger)
    {
        _subresourceIntegrityHashService = subresourceIntegrityHashService;
        _options = options;
        _logger = logger;
    }

    /// <inheritdoc />
    public override int Order => int.MaxValue;

    /// <summary>
    /// Gets or sets the view context.
    /// <remarks>Property must have a public setter.</remarks>
    /// </summary>
    [ViewContext]
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public required ViewContext ViewContext { get; set; }

    /// <summary>
    /// When <c>true</c>, the subresource integrity will be added to the tag when
    /// <see cref="TagHelperOptions.AutoApplySubresourceIntegrity"/> is <c>false</c>.
    /// </summary>
    [HtmlAttributeName("asp-add-subresource-integrity")]
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public bool AddSubresourceIntegrity { get; set; }

    private HttpRequest Request => ViewContext.HttpContext.Request;

    /// <inheritdoc />
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        if (!_options.Value.AutoApplySubresourceIntegrity && !AddSubresourceIntegrity)
        {
            return;
        }

        if (context.AllAttributes.ContainsName(IntegrityAttributeName))
        {
            return;
        }

        var attribute = GetAttribute(context);
        var url = GetAttributeValue(attribute);

        if (!IsValidUrl(url, out var uri))
        {
            return;
        }

        var integrityHash = await _subresourceIntegrityHashService.GetIntegrityHashFromUrlAsync(uri).ConfigureAwait(false);
        if (!integrityHash.Success)
        {
            return;
        }

        output.Attributes.Add(IntegrityAttributeName, integrityHash.Hash);
        output.Attributes.Add(CrossOriginAttributeName, Anonymous);
    }

    private static TagHelperAttribute GetAttribute(TagHelperContext context) =>
        context.TagName switch
        {
            "script" => context.AllAttributes["src"],
            "link" => context.AllAttributes["href"],
            _ => throw new NotSupportedException($"Tag `{context.TagName}` is not supported for subresource integrity.")
        };

    private static string? GetAttributeValue(TagHelperAttribute attribute) =>
        attribute.Value switch
        {
            HtmlString htmlString => htmlString.Value,
            string value => value,
            _ => null
        };

    private bool IsValidUrl(string? url, [NotNullWhen(true)] out Uri? uri)
    {
        uri = null;
        if (string.IsNullOrWhiteSpace(url))
        {
            return false;
        }

        if (url.StartsWith("//", StringComparison.OrdinalIgnoreCase))
        {
            url = $"{Request.Scheme}:{url}";
        }

        if (!url.Contains("://"))
        {
            _logger.LogTrace("Ignore relative url `{Url}`", HttpUtility.UrlEncode(url));
            return false;
        }

        if (!Uri.TryCreate(url, UriKind.Absolute, out var absoluteUri))
        {
            _logger.LogDebug("Unable to convert `{Url}` into an absolut URI", HttpUtility.UrlEncode(url));
            return false;
        }

        uri = absoluteUri;
        return true;
    }
}