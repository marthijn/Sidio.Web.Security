using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Headers.Validation;

namespace Sidio.Web.Security.Headers;

/// <summary>
/// The X-XSS-Protection header that controls the Cross-Site Scripting (XSS) Filter built into most browsers.
/// </summary>
public sealed class XXssProtectionHeader : ValidatableHttpHeader<XXssProtectionHeaderOptions>
{
    /// <summary>
    /// The name of the header.
    /// </summary>
    public const string HeaderName = "X-XSS-Protection";

    /// <summary>
    /// Initializes a new instance of the <see cref="XXssProtectionHeader"/> class.
    /// </summary>
    /// <param name="value">The header value.</param>
    public XXssProtectionHeader(string? value) : base(value)
    {
    }

    /// <inheritdoc />
    public override string Name => HeaderName;

    /// <inheritdoc />
    protected override IHeaderValidator<XXssProtectionHeaderOptions> Validator => new XXssProtectionHeaderValidator();
}