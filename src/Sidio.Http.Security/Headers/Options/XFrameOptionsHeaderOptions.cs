using Sidio.Http.Security.Headers.Validation;

namespace Sidio.Http.Security.Headers.Options;

/// <summary>
/// The X-Frame-Options header options.
/// </summary>
public sealed class XFrameOptionsHeaderOptions : IHttpHeaderOptions
{
    /// <summary>
    /// Gets or sets the X-Frame-Options directive. The default value is <see cref="XFrameOptionsDirective.Deny"/>.
    /// </summary>
    public XFrameOptionsDirective Directive { get; set; } = XFrameOptionsDirective.Deny;

    /// <inheritdoc />
    public string Value => ToString();

    /// <inheritdoc />
    public override string ToString()
    {
        return Directive switch
        {
            XFrameOptionsDirective.Deny => XFrameOptionsHeader.Deny,
            XFrameOptionsDirective.SameOrigin => XFrameOptionsHeader.SameOrigin,
            _ => throw new InvalidOperationException($"Unknown X-Frame-Options directive: {Directive}")
        };
    }

    /// <summary>
    /// The X-Frame-Options header value.
    /// </summary>
    /// <remarks>The ALLOW-FROM option is not supported since it is deprecated. Use the Content-Security-Policy with
    /// the frame-ancestors directive.</remarks>
    public enum XFrameOptionsDirective
    {
        /// <summary>
        /// The page cannot be displayed in a frame, regardless of the site attempting to do so.
        /// </summary>
        Deny,

        /// <summary>
        /// The page can only be displayed in a frame on the same origin as the page itself.
        /// </summary>
        SameOrigin,
    }

#if NETSTANDARD2_0
    public static bool TryCreate(
        string? headerValue,
        out XFrameOptionsHeaderOptions? options,
        out HeaderValidationResult headerValidationResult)
#else
    public static bool TryCreate(
        string? headerValue,
        [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out XFrameOptionsHeaderOptions? options,
        out HeaderValidationResult headerValidationResult)
#endif
    {
        if (headerValue.IsNullOrWhiteSpace(out var validations))
        {
            options = null;
            headerValidationResult = new HeaderValidationResult(validations);
            return headerValidationResult.IsValid;
        }

        if (headerValue.StartsWith(XFrameOptionsHeader.AllowFrom, StringComparison.OrdinalIgnoreCase))
        {
            options = null;
            headerValidationResult = new HeaderValidationResult(
                new[]
                {
                    new HeaderValidation(
                        HeaderValidationSeverityLevel.Error,
                        $"The {XFrameOptionsHeader.AllowFrom} directive is is deprecated. Use the Content-Security-Policy with the frame-ancestors directive.")
                });
            return headerValidationResult.IsValid;
        }

        if (!XFrameOptionsHeader.AllowedValues.Contains(headerValue, StringComparer.OrdinalIgnoreCase))
        {
            options = null;
            headerValidationResult = new HeaderValidationResult(
                new[]
                {
                    new HeaderValidation(
                        HeaderValidationSeverityLevel.Error,
                        $"The header value must be one of the following: {string.Join(", ", XFrameOptionsHeader.AllowedValues)}.")
                });
            return headerValidationResult.IsValid;
        }

        options = new XFrameOptionsHeaderOptions
        {
            Directive = headerValue.Equals(XFrameOptionsHeader.Deny, StringComparison.OrdinalIgnoreCase)
                ? XFrameOptionsDirective.Deny
                : XFrameOptionsDirective.SameOrigin
        };

        headerValidationResult = new HeaderValidationResult([]);
        return headerValidationResult.IsValid;
    }
}