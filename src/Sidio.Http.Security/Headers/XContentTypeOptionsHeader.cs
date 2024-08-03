using Sidio.Http.Security.Headers.Options;
using Sidio.Http.Security.Headers.Validation;

namespace Sidio.Http.Security.Headers;

public sealed class XContentTypeOptionsHeader : ValidatableHttpHeader<XContentTypeOptionsHeaderOptions>
{
    /// <summary>
    /// The name of the header.
    /// </summary>
    public const string HeaderName = "X-Content-Type-Options";

    internal const string DefaultValue = "nosniff";

    public XContentTypeOptionsHeader(string? value = DefaultValue)
        : base(value)
    {
    }

    public override string Name => HeaderName;

    protected override IHeaderValidator<XContentTypeOptionsHeaderOptions> Validator =>
        new XContentTypeOptionsHeaderValidator();
}