using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Headers.Validation;

namespace Sidio.Web.Security.Headers;

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

    /// <inheritdoc />
    public override string Name => HeaderName;

    /// <inheritdoc />
    protected override IHeaderValidator<StrictTransportSecurityHeaderOptions> Validator =>
        new StrictTransportSecurityHeaderValidator();
}