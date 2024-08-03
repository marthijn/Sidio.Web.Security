using Sidio.Http.Security.Headers.Options;
using Sidio.Http.Security.Headers.Validation;

namespace Sidio.Http.Security.Headers;

/// <summary>
/// The Strict-Transport-Security header (HSTS) is used to inform the browser that it should only be accessed using HTTPS.
/// </summary>
public sealed class StrictTransportSecurityHeader : ValidatableHttpHeader<StrictTransportSecurityHeaderOptions>
{
    /// <summary>
    /// The name of the header.
    /// </summary>
    public const string HeaderName = "Strict-Transport-Security";

    /// <summary>
    /// One year in seconds.
    /// </summary>
    internal const int OneYear = 31536000;

    /// <summary>
    /// Two years in seconds.
    /// </summary>
    public const int TwoYears = OneYear * 2;

    public StrictTransportSecurityHeader(string? value)
        : base(value)
    {
    }

    public override string Name => HeaderName;

    protected override IHeaderValidator<StrictTransportSecurityHeaderOptions> Validator =>
        new StrictTransportSecurityHeaderValidator();
}