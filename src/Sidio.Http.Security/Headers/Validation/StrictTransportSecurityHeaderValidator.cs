using System.Text.RegularExpressions;
using Sidio.Http.Security.Headers.Options;

namespace Sidio.Http.Security.Headers.Validation;

public sealed class StrictTransportSecurityHeaderValidator : IHeaderValidator<StrictTransportSecurityHeaderOptions>
{
    private const string MaxAge = "max-age";

    private static readonly char[] Separator = [';'];

    private static readonly Regex MaxAgeRegex = new ($@"{MaxAge}=(\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public HeaderValidationResult Validate(string? headerValue, out StrictTransportSecurityHeaderOptions? options)
    {
        if (headerValue.IsNullOrWhiteSpace(out var validations))
        {
            options = null;
            return new HeaderValidationResult(validations);
        }

        options = new StrictTransportSecurityHeaderOptions();

        // check for valid values
        var values = headerValue.Split(Separator, StringSplitOptions.RemoveEmptyEntries).Select(v => v.Trim()).ToList();
        var validationResult = values.Where(s => !IsValidValue(s)).Select(
            s => new HeaderValidation(HeaderValidationSeverityLevel.Error, $"The value '{s}' is not a valid directive.")).ToList();

        options.Preload = values.Any(v => v.Equals("preload", StringComparison.OrdinalIgnoreCase));
        options.IncludeSubDomains = values.Any(v => v.Equals("includeSubDomains", StringComparison.OrdinalIgnoreCase));

        // check max age
        var maxAgeValueMatch = MaxAgeRegex.Match(headerValue);
        if (!maxAgeValueMatch.Success)
        {
            validationResult.Add(new HeaderValidation(HeaderValidationSeverityLevel.Error, $"The {MaxAge} value is missing."));
        }
        else
        {
            options.MaxAge = long.Parse(maxAgeValueMatch.Groups[1].Value);
            validationResult.AddRange(Validate(options).ValidationResults);
        }

        return new HeaderValidationResult(validationResult).ClearOptionsWhenInvalid(ref options);
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

    private static bool IsValidValue(string s)
    {
        return s.StartsWith($"{MaxAge}=", StringComparison.OrdinalIgnoreCase) ||
               s.Equals("includeSubDomains", StringComparison.OrdinalIgnoreCase) || s.Equals(
                   "preload",
                   StringComparison.OrdinalIgnoreCase);
    }
}