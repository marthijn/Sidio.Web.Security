using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.Headers.Validation;

/// <summary>
/// The Permissions-Policy header validator.
/// </summary>
public sealed class PermissionsPolicyHeaderValidator : IHeaderValidator<PermissionsPolicyHeaderOptions>
{
    /// <inheritdoc />
    public HeaderValidationResult Validate(string? headerValue, out PermissionsPolicyHeaderOptions? options)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public HeaderValidationResult Validate(PermissionsPolicyHeaderOptions options)
    {
        throw new NotImplementedException();
    }
}