using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Logging;
using Sidio.Web.Security.AspNetCore.ContentSecurityPolicy;

namespace Sidio.Web.Security.AspNetCore.Html;

/// <summary>
/// The nonce tag helper.
/// </summary>
[HtmlTargetElement("script", Attributes = "asp-add-nonce")]
[HtmlTargetElement("style", Attributes = "asp-add-nonce")]
[HtmlTargetElement("link", Attributes = "asp-add-nonce")]
public sealed class NonceTagHelper : TagHelper
{
    private readonly INonceService _nonceService;
    private readonly ILogger<NonceTagHelper> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="NonceTagHelper"/> class.
    /// </summary>
    /// <param name="nonceService">The nonce service.</param>
    /// <param name="logger">The logger.</param>
    public NonceTagHelper(INonceService nonceService, ILogger<NonceTagHelper> logger)
    {
        _nonceService = nonceService;
        _logger = logger;
    }

    /// <summary>
    /// When <c>true</c>, the nonce will be added to the tag.
    /// </summary>
    [HtmlAttributeName("asp-add-nonce")]
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public bool AddNonce { get; set; }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (!AddNonce)
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
            output.Attributes.SetAttribute("nonce", nonce.Value);
        }
    }
}