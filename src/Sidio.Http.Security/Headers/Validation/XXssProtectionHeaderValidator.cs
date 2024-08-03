using System.Text.RegularExpressions;
using Sidio.Http.Security.Headers.Options;

namespace Sidio.Http.Security.Headers.Validation;

public sealed class XXssProtectionHeaderValidator : IHeaderValidator<XXssProtectionHeaderOptions>
{
    private static readonly char[] Separator = [';'];

    private static readonly Regex ReportUriRegex = new (@"report=(?<uri>.+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public HeaderValidationResult Validate(string? headerValue, out XXssProtectionHeaderOptions? options)
    {
        if (headerValue.IsNullOrWhiteSpace(out var validations))
        {
            options = null;
            return new HeaderValidationResult(validations);
        }

        options = new XXssProtectionHeaderOptions();

        // always add a warning since this header is non-standard
        var validationResult = new List<HeaderValidation>
        {
            new HeaderValidation(HeaderValidationSeverityLevel.Warning, $"The {XXssProtectionHeader.HeaderName} header is non-standard and should not be used.")
        };

        var values = headerValue.Split(Separator, StringSplitOptions.RemoveEmptyEntries).Select(v => v.Trim()).ToList();
        if (values.Count > 2)
        {
            validationResult.Add(new HeaderValidation(HeaderValidationSeverityLevel.Error, "The header value contains too many directives."));
        }

        if (!int.TryParse(values.First(), out var enabled) || (enabled != 0 && enabled != 1))
        {
            validationResult.Add(new HeaderValidation(HeaderValidationSeverityLevel.Error, $"The directive '{values.First()}' is not 0 or 1."));
            return new HeaderValidationResult(validationResult).ClearOptionsWhenInvalid(ref options);
        }

        options.Enabled = enabled == 1;
        if (options.Enabled && values.Count == 2)
        {
            options.Block = GetMode(values.Last());
            options.ReportUri = GetReportUri(values.Last());
            if (options.Block && !string.IsNullOrWhiteSpace(options.ReportUri))
            {
                validationResult.Add(
                    new HeaderValidation(
                        HeaderValidationSeverityLevel.Error,
                        "When the block directive is set to true, the report directive must not be set."));
            }

            if (!options.Block && string.IsNullOrWhiteSpace(options.ReportUri))
            {
                validationResult.Add(new HeaderValidation(HeaderValidationSeverityLevel.Error, $"The directive '{values.Last()}' is not valid."));
            }
        }
        else if (!options.Enabled && values.Count != 1)
        {
            validationResult.Add(new HeaderValidation(HeaderValidationSeverityLevel.Error, $"The directive '{values.Last()}' is not valid when filtering is disabled."));
        }

        return new HeaderValidationResult(validationResult).ClearOptionsWhenInvalid(ref options);
    }

    public HeaderValidationResult Validate(XXssProtectionHeaderOptions options)
    {
        if (options.Enabled)
        {
            if (options.Block && !string.IsNullOrWhiteSpace(options.ReportUri))
            {
                return new HeaderValidationResult(
                    new[]
                    {
                        new HeaderValidation(
                            HeaderValidationSeverityLevel.Error,
                            "When the block directive is set to true, the report directive must not be set.")
                    });
            }
        }
        else if (!options.Enabled && (options.Block || !string.IsNullOrWhiteSpace(options.ReportUri)))
        {
            return new HeaderValidationResult(
                new[]
                {
                    new HeaderValidation(
                        HeaderValidationSeverityLevel.Error,
                        "The block and report directives are not valid when filtering is disabled.")
                });
        }

        return new HeaderValidationResult([]);
    }

    private static bool GetMode(string value) => value.Equals("mode=block", StringComparison.OrdinalIgnoreCase);

    private static string? GetReportUri(string value)
    {
        var match = ReportUriRegex.Match(value);
        return match.Success ? match.Groups["uri"].Value : null;
    }
}