using System.Text.Json;
using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.Headers.Validation;

/// <summary>
/// The Report-To header validator.
/// </summary>
public sealed class ReportToHeaderValidation : IHeaderValidator<ReportToHeaderOptions>
{
    /// <inheritdoc />
    public HeaderValidationResult Validate(string? headerValue, out ReportToHeaderOptions? options)
    {
        if (headerValue.IsNullOrWhiteSpace(out var validations))
        {
            options = null;
            return new HeaderValidationResult(validations);
        }

        var validationResult = Deserialize(headerValue, out var reportGroups);
        if (validationResult.Count > 0)
        {
            options = null;
            return new HeaderValidationResult(validationResult);
        }

        options = new ReportToHeaderOptions();
        if (reportGroups.Count > 0)
        {
            options.Groups.AddRange(reportGroups);
        }

        return Validate(options).ClearOptionsWhenInvalid(ref options);
    }

    /// <inheritdoc />
    public HeaderValidationResult Validate(ReportToHeaderOptions options)
    {
        var validationResult = new List<HeaderValidation>();
        if (options.Groups.Count == 0)
        {
            validationResult.Add(new HeaderValidation(HeaderValidationSeverityLevel.Error, "The report-to header must have at least one report group."));
        }

        foreach (var group in options.Groups)
        {
            if (string.IsNullOrWhiteSpace(group.Group))
            {
                validationResult.Add(new HeaderValidation(HeaderValidationSeverityLevel.Error, "The report group name must not be empty."));
            }

            if (group.Endpoints.Count == 0)
            {
                validationResult.Add(new HeaderValidation(HeaderValidationSeverityLevel.Error, "The report group must have at least one endpoint."));
            }

            if (group.MaxAge < 0)
            {
                validationResult.Add(new HeaderValidation(HeaderValidationSeverityLevel.Error, "The report group max-age value must be a positive number."));
            }
            else if (group.MaxAge == 0)
            {
                validationResult.Add(new HeaderValidation(HeaderValidationSeverityLevel.Warning, "The report group max-age value is set to 0. The report group will not be cached."));
            }
        }

        return new HeaderValidationResult(validationResult);
    }

    private static List<HeaderValidation> Deserialize(string headerValue, out List<ReportGroup> reportGroups)
    {
        var validationResult = new List<HeaderValidation>();
        reportGroups = [];

        try
        {
            // convert to array if it is an object
            // https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/report-to
            var value = headerValue.Trim();

#if NETSTANDARD2_0
            if (headerValue.StartsWith("{"))
#else
            if (headerValue.StartsWith('{'))
#endif
            {
                value = $"[{value}]";
            }

            var reportToValue = JsonSerializer.Deserialize<List<ReportGroup>>(value);

            if (reportToValue != null)
            {
                reportGroups.AddRange(reportToValue);
            }
        }
        catch (JsonException ex)
        {
            validationResult.Add(new HeaderValidation(HeaderValidationSeverityLevel.Error, ex.Message));
        }
        catch (ArgumentException argumentException)
        {
            validationResult.Add(new HeaderValidation(HeaderValidationSeverityLevel.Error, argumentException.Message));
        }

        return validationResult;
    }
}