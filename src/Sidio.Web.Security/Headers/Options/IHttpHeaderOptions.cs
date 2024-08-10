namespace Sidio.Web.Security.Headers.Options;

/// <summary>
/// The HTTP header options interface.
/// </summary>
public interface IHttpHeaderOptions
{
    /// <summary>
    /// Gets the header value.
    /// </summary>
    public string Value { get; }
}