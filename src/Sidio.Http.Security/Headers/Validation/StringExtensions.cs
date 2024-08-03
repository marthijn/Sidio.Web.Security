namespace Sidio.Http.Security.Headers.Validation;

internal static class StringExtensions
{
#if NETSTANDARD2_0
    public static bool IsNullOrWhiteSpace(this string? input, out IEnumerable<HeaderValidation>? validations)
#else
    public static bool IsNullOrWhiteSpace([System.Diagnostics.CodeAnalysis.NotNullWhen(false)] this string? input, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out IEnumerable<HeaderValidation>? validations)
#endif
    {
#if NETSTANDARD2_0
        if (input == null || string.IsNullOrWhiteSpace(input))
#else
        if (string.IsNullOrWhiteSpace(input))
#endif
        {
            validations = new[]
            {
                new HeaderValidation(HeaderValidationSeverityLevel.Error, "The header value must not be empty.")
            };

            return true;
        }

        validations = null;
        return false;
    }
}