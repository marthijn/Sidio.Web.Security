using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Logging;
using Sidio.Web.Security.AspNetCore.ContentSecurityPolicy;

namespace Sidio.Web.Security.AspNetCore.Html;

[HtmlTargetElement("script", Attributes = "asp-add-nonce")]
[HtmlTargetElement("style", Attributes = "asp-add-nonce")]
[HtmlTargetElement("link", Attributes = "asp-add-nonce")]
public sealed class NonceTagHelper : TagHelper
{
    private readonly INonceService _nonceService;
    private readonly ILogger<NonceTagHelper> _logger;

    [HtmlAttributeName("asp-add-nonce")]
    public bool AddNonce { get; set; }

    public NonceTagHelper(INonceService nonceService, ILogger<NonceTagHelper> logger)
    {
        _nonceService = nonceService;
        _logger = logger;
    }

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