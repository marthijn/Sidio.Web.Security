using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.Headers.Validation;

/// <summary>
/// The Cross-Origin-Resource-Policy header validator.
/// </summary>
public sealed class CrossOriginResourcePolicyHeaderValidator : IHeaderValidator<CrossOriginResourcePolicyHeaderOptions>
{
    /// <inheritdoc />
    public HeaderValidationResult Validate(string? headerValue, out CrossOriginResourcePolicyHeaderOptions? options)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public HeaderValidationResult Validate(CrossOriginResourcePolicyHeaderOptions options)
    {
        throw new NotImplementedException();
    }
}