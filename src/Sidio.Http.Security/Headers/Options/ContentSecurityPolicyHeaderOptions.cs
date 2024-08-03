namespace Sidio.Http.Security.Headers.Options;

public sealed class ContentSecurityPolicyHeaderOptions : IHttpHeaderOptions
{
    public string Value => ToString();

    public override string ToString()
    {
        return base.ToString();
    }
}