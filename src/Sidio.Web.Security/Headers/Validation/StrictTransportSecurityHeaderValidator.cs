using System.Text.RegularExpressions;
using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.Headers.Validation;

public sealed class StrictTransportSecurityHeaderValidator : IHeaderValidator<StrictTransportSecurityHeaderOptions>
{
    private const string MaxAge = "max-age";

    private static readonly Regex HeaderRegex = new(
        @"^max-age=(?<MaxAge>\d+)(;\s*includeSubDomains)?(;\s*preload)?$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public HeaderValidationResult Validate(string? headerValue, out StrictTransportSecurityHeaderOptions? options)
    {
        if (headerValue.IsNullOrWhiteSpace(out var validations))
        {
            options = null;
            return new HeaderValidationResult(validations);
        }

        var match = HeaderRegex.Match(headerValue);
        if (!match.Success)
        {
            options = null;
            return new HeaderValidationResult(new[]
            {
                new HeaderValidation(
                    HeaderValidationSeverityLevel.Error,
                    "The header value must be in the format 'max-age=<seconds>; includeSubDomains; preload'.")
            });
        }

        options = new StrictTransportSecurityHeaderOptions();
        options.MaxAge = long.Parse(match.Groups["MaxAge"].Value);
        options.IncludeSubDomains = match.Groups[1].Success;
        options.Preload = match.Groups[2].Success;

        var result = Validate(options);
        return new HeaderValidationResult(result.ValidationResults).ClearOptionsWhenInvalid(ref options);
    }

    public HeaderValidationResult Validate(StrictTransportSecurityHeaderOptions options)
    {
        var validationResult = new List<HeaderValidation>();
        if (options.MaxAge  < 0)
        {
            validationResult.Add(new HeaderValidation(HeaderValidationSeverityLevel.Error, $"The {MaxAge} value must be a positive number."));
        }
        else if (options.MaxAge  == 0)
        {
            validationResult.Add(new HeaderValidation(HeaderValidationSeverityLevel.Warning, $"The {MaxAge} value is set to 0. The Strict-Transport-Security header will not be cached."));
        }

        if (options.Preload)
        {
            if (!options.IncludeSubDomains)
            {
                validationResult.Add(new HeaderValidation(HeaderValidationSeverityLevel.Error, "The includeSubDomains directive must be present when using the preload directive."));
            }

            if (options.MaxAge < StrictTransportSecurityHeader.OneYear)
            {
                validationResult.Add(new HeaderValidation(HeaderValidationSeverityLevel.Error, $"The {MaxAge} value must be at least {StrictTransportSecurityHeader.OneYear} when using the preload directive."));
            }
        }

        return new HeaderValidationResult(validationResult);
    }
}