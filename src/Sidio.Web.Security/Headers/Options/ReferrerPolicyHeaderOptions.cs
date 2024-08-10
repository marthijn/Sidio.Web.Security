namespace Sidio.Web.Security.Headers.Options;

/// <summary>
/// The Referrer-Policy header options.
/// </summary>
public sealed class ReferrerPolicyHeaderOptions : IHttpHeaderOptions
{
    /// <inheritdoc />
    public string Value { get; }
}