using Sidio.Http.Security.Headers.Options;

namespace Sidio.Http.Security.Headers.Validation;

public sealed class XFrameOptionsHeaderValidator : IHeaderValidator<XFrameOptionsHeaderOptions>
{
    public HeaderValidationResult Validate(string? headerValue, out XFrameOptionsHeaderOptions? options)
    {
        if (headerValue.IsNullOrWhiteSpace(out var validations))
        {
            options = null;
            return new HeaderValidationResult(validations);
        }

        if (headerValue.StartsWith(XFrameOptionsHeader.AllowFrom, StringComparison.OrdinalIgnoreCase))
        {
            options = null;
            return new HeaderValidationResult(
                new[]
                {
                    new HeaderValidation(
                        HeaderValidationSeverityLevel.Error,
                        $"The {XFrameOptionsHeader.AllowFrom} directive is is deprecated. Use the Content-Security-Policy with the frame-ancestors directive.")
                });
        }

        if (!XFrameOptionsHeader.AllowedValues.Contains(headerValue, StringComparer.OrdinalIgnoreCase))
        {
            options = null;
            return  new HeaderValidationResult(
                new[]
                {
                    new HeaderValidation(
                        HeaderValidationSeverityLevel.Error,
                        $"The header value must be one of the following: {string.Join(", ", XFrameOptionsHeader.AllowedValues)}.")
                });
        }

        options = new XFrameOptionsHeaderOptions
        {
            Directive = headerValue.Equals(XFrameOptionsHeader.Deny, StringComparison.OrdinalIgnoreCase)
                ? XFrameOptionsHeaderOptions.XFrameOptionsDirective.Deny
                : XFrameOptionsHeaderOptions.XFrameOptionsDirective.SameOrigin
        };

        return new HeaderValidationResult([]);
    }

    public HeaderValidationResult Validate(XFrameOptionsHeaderOptions options)
    {
        return new HeaderValidationResult([]);
    }
}