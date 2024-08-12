using System.Diagnostics;

namespace Sidio.Web.Security.Headers.Options;

/// <summary>
/// The X-Content-Type-Options header options.
/// </summary>
[DebuggerDisplay("{Value}")]
public sealed class XContentTypeOptionsHeaderOptions : IHttpHeaderOptions
{
    /// <inheritdoc />
    public string Value => ToString();

    /// <inheritdoc />
    public override string ToString() => XContentTypeOptionsHeader.DefaultValue;
}