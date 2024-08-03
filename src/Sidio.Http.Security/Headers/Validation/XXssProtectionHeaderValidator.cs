using System.Text.RegularExpressions;
using Sidio.Http.Security.Headers.Options;

namespace Sidio.Http.Security.Headers.Validation;

public sealed class XXssProtectionHeaderValidator : IHeaderValidator<XXssProtectionHeaderOptions>
{
    private static readonly Regex HeaderRegex =
        new(
            @"^(?<Protection>0|1)(; mode=(?<Mode>block)|; report=(?<Report>.+))?$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public HeaderValidationResult Validate(string? headerValue, out XXssProtectionHeaderOptions? options)
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
            return new HeaderValidationResult(
                new[]
                {
                    new HeaderValidation(HeaderValidationSeverityLevel.Error, "The header value is not valid.")
                });
        }

        options = new XXssProtectionHeaderOptions();

        var protection = int.Parse(match.Groups["Protection"].Value);
        options.Enabled = protection == 1;
        options.Block = match.Groups["Mode"].Success;
        options.ReportUri = match.Groups["Report"].Success ? match.Groups["Report"].Value : null;

        var result = Validate(options);
        return result.ClearOptionsWhenInvalid(ref options);
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
}