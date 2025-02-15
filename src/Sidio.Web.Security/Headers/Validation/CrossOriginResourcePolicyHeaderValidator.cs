using Sidio.Web.Security.Common;
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
        if (headerValue.IsNullOrWhiteSpace(out var validations))
        {
            options = null;
            return new HeaderValidationResult(validations);
        }

        var validation = new List<HeaderValidation>();
        options = new CrossOriginResourcePolicyHeaderOptions();

        if (!headerValue.TryToEnum(out CrossOriginResourcePolicy policy))
        {
            validation.Add(new HeaderValidation(HeaderValidationSeverityLevel.Error, "The header value is not a valid Cross-Origin Resource directive."));
        }
        else
        {
            options.Policy = policy;
        }

        return new HeaderValidationResult(validation).ClearOptionsWhenInvalid(ref options);
    }

    /// <inheritdoc />
    public HeaderValidationResult Validate(CrossOriginResourcePolicyHeaderOptions options)
    {
        return new HeaderValidationResult([]);
    }
}