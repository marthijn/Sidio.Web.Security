namespace Sidio.Web.Security.AspNetCore.Html;

/// <summary>
/// The options for the tag helper.
/// </summary>
public sealed class TagHelperOptions
{
    /// <summary>
    /// Gets or sets a value indicating whether to automatically apply the nonce to the script or link tag.
    /// Default is <c>false</c>.
    /// </summary>
    public bool AutoApplyNonce { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to automatically apply subresource integrity to the script or link tag.
    /// Default is <c>false</c>.
    /// </summary>
    public bool AutoApplySubresourceIntegrity { get; set; }
}