using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Headers.Validation;

namespace Sidio.Web.Security.Headers;

/// <summary>
/// The Content-Security-Policy header.
/// </summary>
public sealed class ContentSecurityPolicyHeader : ValidatableHttpHeader<ContentSecurityPolicyHeaderOptions>
{
    /// <summary>
    /// The name of the header.
    /// </summary>
    public const string HeaderName = "Content-Security-Policy";

    /// <summary>
    /// Initializes a new instance of the <see cref="ContentSecurityPolicyHeader"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public ContentSecurityPolicyHeader(string? value) : base(value)
    {
    }

    /// <inheritdoc />
    public override string Name => HeaderName;

    /// <inheritdoc />
    protected override IHeaderValidator<ContentSecurityPolicyHeaderOptions> Validator =>
        new ContentSecurityPolicyHeaderValidator();
}