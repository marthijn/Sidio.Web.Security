using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Headers.Validation;

namespace Sidio.Web.Security.Headers;

/// <summary>
/// The Permissions-Policy header.
/// </summary>
public sealed class PermissionsPolicyHeader : ValidatableHttpHeader<PermissionsPolicyHeaderOptions>
{
    /// <summary>
    /// The name of the header.
    /// </summary>
    public const string HeaderName = "Permissions-Policy";

    /// <summary>
    /// Initializes a new instance of the <see cref="PermissionsPolicyHeader"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public PermissionsPolicyHeader(string? value) : base(value)
    {
    }

    /// <inheritdoc />
    public override string Name => HeaderName;

    /// <inheritdoc />
    protected override IHeaderValidator<PermissionsPolicyHeaderOptions> Validator =>
        new PermissionsPolicyHeaderValidator();
}