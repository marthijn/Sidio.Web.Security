namespace Sidio.Http.Security.Headers.Options;

public sealed class XContentTypeOptionsHeaderOptions : IHttpHeaderOptions
{
    public string Value => ToString();

    public override string ToString() => XContentTypeOptionsHeader.DefaultValue;
}