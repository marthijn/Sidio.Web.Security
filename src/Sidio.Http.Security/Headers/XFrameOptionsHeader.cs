using Sidio.Http.Security.Headers.Options;
using Sidio.Http.Security.Headers.Validation;

namespace Sidio.Http.Security.Headers;

/// <summary>
/// The X-Frame-Options header.
/// </summary>
public sealed class XFrameOptionsHeader : ValidatableHttpHeader<XFrameOptionsHeaderOptions>
{
    /// <summary>
    /// The name of the header.
    /// </summary>
    public const string HeaderName = "X-Frame-Options";

    public const string Deny = "DENY";

    public const string SameOrigin = "SAMEORIGIN";

    internal const string AllowFrom = "ALLOW-FROM";

    internal static string[] AllowedValues = { Deny, SameOrigin };

    /// <summary>
    /// Initializes a new instance of the <see cref="XFrameOptionsHeader"/> class.
    /// </summary>
    /// <param name="value">The header value.</param>
    public XFrameOptionsHeader(string? value) : base(value)
    {
    }

    /// <inheritdoc />
    public override string Name => HeaderName;

    protected override IHeaderValidator<XFrameOptionsHeaderOptions> Validator => new XFrameOptionsHeaderValidator();
}