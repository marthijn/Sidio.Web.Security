using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sidio.Web.Security.AspNetCore.ContentSecurityPolicy;

namespace Sidio.Web.Security.AspNetCore.Html;

/// <summary>
/// The nonce tag helper.
/// </summary>
[HtmlTargetElement("script")]
[HtmlTargetElement("style")]
[HtmlTargetElement("link", Attributes = "href,[rel='stylesheet']")]
[HtmlTargetElement("link", Attributes = "href,[rel='preload']")]
[HtmlTargetElement("link", Attributes = "href,[rel='modulepreload']")]
public sealed class NonceTagHelper : TagHelper
{
    private const string NonceAttributeName = "nonce";

    private readonly INonceService _nonceService;
    private readonly IOptions<TagHelperOptions> _options;
    private readonly ILogger<NonceTagHelper> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="NonceTagHelper"/> class.
    /// </summary>
    /// <param name="nonceService">The nonce service.</param>
    /// <param name="options">The options.</param>
    /// <param name="logger">The logger.</param>
    public NonceTagHelper(
        INonceService nonceService,
        IOptions<TagHelperOptions> options,
        ILogger<NonceTagHelper> logger)
    {
        _nonceService = nonceService;
        _options = options;
        _logger = logger;
    }

    /// <inheritdoc />
    public override int Order => int.MaxValue;

    /// <summary>
    /// When <c>true</c>, the nonce will be added to the tag when
    /// <see cref="TagHelperOptions.AutoApplyNonce"/> is <c>false</c>.
    /// </summary>
    [HtmlAttributeName("asp-add-nonce")]
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public bool AddNonce { get; set; }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (!_options.Value.AutoApplyNonce && !AddNonce)
        {
            return;
        }

        if (context.AllAttributes.ContainsName(NonceAttributeName))
        {
            return;
        }

        var nonce =  _nonceService.GetNonce();
        if (nonce == null)
        {
            _logger.LogWarning("The nonce is not set");
        }
        else
        {
            output.Attributes.SetAttribute(NonceAttributeName, nonce.Value);
        }
    }
}