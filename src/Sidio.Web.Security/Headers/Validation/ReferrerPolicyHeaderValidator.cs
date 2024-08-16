using Sidio.Web.Security.Common;
using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.Headers.Validation;

/// <summary>
/// The Referrer-Policy header validator.
/// </summary>
public sealed class ReferrerPolicyHeaderValidator : IHeaderValidator<ReferrerPolicyHeaderOptions>
{
    /// <inheritdoc />
    public HeaderValidationResult Validate(string? headerValue, out ReferrerPolicyHeaderOptions? options)
    {
        options = null;
        if (headerValue.IsNullOrWhiteSpace(out var validations))
        {
            return new HeaderValidationResult(validations);
        }

        var validation = new List<HeaderValidation>();
        if (!headerValue.TryToEnum(out ReferrerPolicy policy))
        {
            validation.Add(new HeaderValidation(HeaderValidationSeverityLevel.Error, "The header value is not a valid Referrer-Policy directive."));
        }
        else
        {
            options = new ReferrerPolicyHeaderOptions { Policy = policy };
        }

        return new HeaderValidationResult(validation).ClearOptionsWhenInvalid(ref options);
    }

    /// <inheritdoc />
    public HeaderValidationResult Validate(ReferrerPolicyHeaderOptions options)
    {
        return new HeaderValidationResult([]);
    }
}