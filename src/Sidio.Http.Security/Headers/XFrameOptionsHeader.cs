namespace Sidio.Http.Security.Headers;

public sealed class XFrameOptionsHeader : HttpHeader
{
    public const string HeaderName = "X-Frame-Options";

    private static string[] AllowedValues = { "DENY", "SAMEORIGIN" };

    public XFrameOptionsHeader(string? value) : base(value)
    {
    }

    public override string Name => HeaderName;

    protected override IEnumerable<HeaderValidation> ValidateHeader()
    {
#if NETSTANDARD2_0
        if (Value == null || string.IsNullOrWhiteSpace(Value))
#else
        if (string.IsNullOrWhiteSpace(Value))
#endif
        {
            return new[]
            {
                new HeaderValidation(HeaderValidationSeverityLevel.Error, "The header value must not be empty.")
            };
        }

        if (Value.StartsWith("ALLOW-FROM", StringComparison.OrdinalIgnoreCase))
        {
            return new[]
            {
                new HeaderValidation(HeaderValidationSeverityLevel.Error, "The ALLOW-FROM option is is deprecated. Use the Content-Security-Policy with the frame-ancestors directive.")
            };
        }

        if (!AllowedValues.Contains(Value, StringComparer.OrdinalIgnoreCase))
        {
            return new[]
            {
                new HeaderValidation(HeaderValidationSeverityLevel.Error, $"The header value must be one of the following: {string.Join(", ", AllowedValues)}.")
            };
        }

        return [];
    }

    public static XFrameOptionsHeader Create(string? value)
    {
        var header = new XFrameOptionsHeader(value);
        var validationResult = header.Validate();
        if (validationResult.HasErrors)
        {
            throw new InvalidHeaderException(header, validationResult);
        }

        return header;
    }
}