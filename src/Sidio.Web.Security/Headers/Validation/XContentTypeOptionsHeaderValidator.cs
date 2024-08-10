using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.Headers.Validation;

/// <summary>
/// The X-Content-Type-Options header validator.
/// </summary>
public sealed class XContentTypeOptionsHeaderValidator : IHeaderValidator<XContentTypeOptionsHeaderOptions>
{
    /// <inheritdoc />
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

    /// <inheritdoc />
    public HeaderValidationResult Validate(XContentTypeOptionsHeaderOptions options)
    {
        return new HeaderValidationResult([]);
    }
}