using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Sidio.Web.Security.Headers.Validation;

/// <summary>
/// The service that validates HTTP headers.
/// </summary>
public sealed class HeaderValidationService
{
    private static readonly string[] RecommendedHeaders = new[]
    {
        ContentSecurityPolicyHeader.HeaderName,
        StrictTransportSecurityHeader.HeaderName,
        XContentTypeOptionsHeader.HeaderName,
        XFrameOptionsHeader.HeaderName,
    };

    private static readonly string[] DeprecatedHeaders = new[]
    {
        XXssProtectionHeader.HeaderName
    };

    private readonly HeaderValidationOptions _options;
    private readonly ILogger<HeaderValidationService> _logger;

    /// <summary>
    /// Creates a new instance of the <see cref="HeaderValidationService"/> class.
    /// </summary>
    /// <param name="options"></param>
    /// <param name="logger"></param>
    public HeaderValidationService(IOptions<HeaderValidationOptions> options, ILogger<HeaderValidationService> logger)
    {
        _options = options.Value;
        _logger = logger;
    }

    /// <summary>
    /// Validates the HTTP headers.
    /// </summary>
    /// <param name="httpHeaders">A dictionary of HTTP headers.</param>
    public void Validate(IDictionary<string, IEnumerable<string?>> httpHeaders)
    {
        if (_options.ValidateRecommendedHeadersArePresent)
        {
            ValidateRecommendedHeaders(httpHeaders);
        }

        ValidateDeprecatedHeaders(httpHeaders);

        var nonValidatedHeaders = new List<string>();
        foreach (var httpHeader in httpHeaders)
        {
            HttpHeader? header = null;

            if (httpHeader.Key.Equals(XFrameOptionsHeader.HeaderName, StringComparison.OrdinalIgnoreCase))
            {
                header = new XFrameOptionsHeader(httpHeader.Value.FirstOrDefault());
            }
            else if (httpHeader.Key.Equals(StrictTransportSecurityHeader.HeaderName, StringComparison.OrdinalIgnoreCase))
            {
                header = new StrictTransportSecurityHeader(httpHeader.Value.FirstOrDefault());
            }
            else if (httpHeader.Key.Equals(XXssProtectionHeader.HeaderName, StringComparison.OrdinalIgnoreCase))
            {
                header = new XXssProtectionHeader(httpHeader.Value.FirstOrDefault());
            }
            else if (httpHeader.Key.Equals(ContentSecurityPolicyHeader.HeaderName, StringComparison.OrdinalIgnoreCase))
            {
                header = new ContentSecurityPolicyHeader(httpHeader.Value.FirstOrDefault());
            }
            else if (httpHeader.Key.Equals(XContentTypeOptionsHeader.HeaderName, StringComparison.OrdinalIgnoreCase))
            {
                header = new XContentTypeOptionsHeader(httpHeader.Value.FirstOrDefault());
            }

            if (header != null)
            {
                ValidateHeader(header);
            }
            else
            {
                nonValidatedHeaders.Add(httpHeader.Key);
            }
        }

        if (nonValidatedHeaders.Any())
        {
            _logger.LogDebug("The following headers are not validated: {Headers}", string.Join(", ", nonValidatedHeaders));
        }
    }

    private void ValidateRecommendedHeaders(IDictionary<string, IEnumerable<string?>> httpHeaders)
    {
        foreach (var header in RecommendedHeaders)
        {
            if (!httpHeaders.ContainsKey(header))
            {
                _logger.LogWarning("The recommended HTTP header '{HeaderName}' is missing", header);
            }
        }
    }

    private void ValidateDeprecatedHeaders(IDictionary<string, IEnumerable<string?>> httpHeaders)
    {
        foreach (var header in DeprecatedHeaders)
        {
            if (httpHeaders.ContainsKey(header))
            {
                _logger.LogWarning("The HTTP header '{HeaderName}' is deprecated or non-standard", header);
            }
        }
    }

    private void ValidateHeader(HttpHeader header)
    {
        var validationResult = header.Validate();

        if (!_options.SuppressWarnings && validationResult.HasWarnings)
        {
            foreach(var warning in validationResult.Warnings)
            {
                _logger.LogWarning("The HTTP header '{HeaderName}' has a warning: {WarningMessage}", header.Name, warning.Message);
            }
        }

        if (validationResult.HasErrors)
        {
            foreach(var error in validationResult.Errors)
            {
                _logger.LogError("The HTTP header '{HeaderName}' is invalid: {ErrorMessage}", header.Name, error.Message);
            }
        }
    }
}