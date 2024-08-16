using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Headers.Validation;

namespace Sidio.Web.Security.Headers;

/// <summary>
/// The header that controls the referrer information that is sent with requests.
/// </summary>
public sealed class ReferrerPolicyHeader : ValidatableHttpHeader<ReferrerPolicyHeaderOptions>
{
    /// <summary>
    /// The name of the header.
    /// </summary>
    public const string HeaderName = "Referrer-Policy";

    /// <summary>
    /// Initializes a new instance of the <see cref="ReferrerPolicyHeader"/> class.
    /// </summary>
    /// <param name="value">The header value.</param>
    public ReferrerPolicyHeader(string? value) : base(value)
    {
    }

    /// <inheritdoc />
    public override string Name => HeaderName;

    /// <inheritdoc />
    protected override IHeaderValidator<ReferrerPolicyHeaderOptions> Validator => new ReferrerPolicyHeaderValidator();
}