using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Headers.Validation;

namespace Sidio.Web.Security.Headers;

/// <summary>
/// The Cross-Origin-Resource-Policy header.
/// </summary>
public sealed class CrossOriginResourcePolicyHeader : ValidatableHttpHeader<CrossOriginResourcePolicyHeaderOptions>
{
    /// <summary>
    /// The name of the header.
    /// </summary>
    public const string HeaderName = "Cross-Origin-Resource-Policy";

    /// <summary>
    /// Initializes a new instance of the <see cref="CrossOriginResourcePolicyHeader"/> class.
    /// </summary>
    /// <param name="value">The header value.</param>
    public CrossOriginResourcePolicyHeader(string? value) : base(value)
    {
    }

    /// <inheritdoc />
    public override string Name => HeaderName;

    /// <inheritdoc />
    protected override IHeaderValidator<CrossOriginResourcePolicyHeaderOptions> Validator =>
        new CrossOriginResourcePolicyHeaderValidator();
}