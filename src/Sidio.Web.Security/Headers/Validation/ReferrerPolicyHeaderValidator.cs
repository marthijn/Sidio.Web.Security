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
        if (headerValue.IsNullOrWhiteSpace(out var validations))
        {
            options = null;
            return new HeaderValidationResult(validations);
        }

        var validation = new List<HeaderValidation>();

        options = new ReferrerPolicyHeaderOptions();
        var stringValues = headerValue.Split(',').Select(v => v.Trim());
        foreach (var stringValue in stringValues)
        {
            if (!stringValue.TryToEnum(out ReferrerPolicy policy))
            {
                validation.Add(new HeaderValidation(HeaderValidationSeverityLevel.Error, "The header value is not a valid Referrer-Policy directive."));
            }
            else
            {
                options.Policies.Add(policy);
            }
        }

        return new HeaderValidationResult(validation).ClearOptionsWhenInvalid(ref options);
    }

    /// <inheritdoc />
    public HeaderValidationResult Validate(ReferrerPolicyHeaderOptions options)
    {
        return new HeaderValidationResult([]);
    }
}