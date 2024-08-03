using Sidio.Http.Security.Headers.Options;
using Sidio.Http.Security.Headers.Validation;

namespace Sidio.Http.Security.Headers;

/// <summary>
/// The X-Content-Type-Options header.
/// </summary>
public sealed class XContentTypeOptionsHeader : ValidatableHttpHeader<XContentTypeOptionsHeaderOptions>
{
    /// <summary>
    /// The name of the header.
    /// </summary>
    public const string HeaderName = "X-Content-Type-Options";

    /// <summary>
    /// The default and only value.
    /// </summary>
    internal const string DefaultValue = "nosniff";

    /// <summary>
    /// Initializes a new instance of the <see cref="XContentTypeOptionsHeader"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public XContentTypeOptionsHeader(string? value = DefaultValue)
        : base(value)
    {
    }

    /// <inheritdoc />
    public override string Name => HeaderName;

    /// <inheritdoc />
    protected override IHeaderValidator<XContentTypeOptionsHeaderOptions> Validator =>
        new XContentTypeOptionsHeaderValidator();
}