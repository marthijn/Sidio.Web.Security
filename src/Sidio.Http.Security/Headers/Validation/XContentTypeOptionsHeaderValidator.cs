using Sidio.Http.Security.Headers.Options;

namespace Sidio.Http.Security.Headers.Validation;

public sealed class XContentTypeOptionsHeaderValidator : IHeaderValidator<XContentTypeOptionsHeaderOptions>
{
    public HeaderValidationResult Validate(string? headerValue, out XContentTypeOptionsHeaderOptions? options)
    {
        if (headerValue.IsNullOrWhiteSpace(out var validations))
        {
            options = null;
            return new HeaderValidationResult(validations);
        }

        if (!headerValue.Equals(XContentTypeOptionsHeader.DefaultValue, StringComparison.OrdinalIgnoreCase))
        {
            options = null;
            return new HeaderValidationResult(
                new[]
                {
                    new HeaderValidation(
                        HeaderValidationSeverityLevel.Error,
                        $"The header value must be '{XContentTypeOptionsHeader.DefaultValue}'.")
                });
        }

        options = new XContentTypeOptionsHeaderOptions();
        return new HeaderValidationResult([]);
    }

    public HeaderValidationResult Validate(XContentTypeOptionsHeaderOptions options)
    {
        return new HeaderValidationResult([]);
    }
}