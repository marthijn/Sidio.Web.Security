namespace Sidio.Web.Security.Html;

/// <summary>
/// The HTML script tag.
/// </summary>
public sealed record ScriptTag
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ScriptTag"/> class.
    /// </summary>
    /// <param name="index">The script index.</param>
    /// <param name="src">The src attribute.</param>
    /// <param name="nonce">The nonce attribute.</param>
    /// <param name="integrity">The integrity attribute.</param>
    /// <param name="crossOrigin">The cross-origin attribute.</param>
    /// <param name="content">The script content.</param>
    public ScriptTag(int index, string? src, string? nonce, string? integrity, string? crossOrigin, string? content)
    {
        Index = index;
        Src = src;
        Nonce = nonce;
        Integrity = integrity;
        CrossOrigin = crossOrigin;
        Content = content;
    }

    /// <summary>
    /// The script index.
    /// </summary>
    public int Index { get; }

    /// <summary>
    /// Gets the src attribute.
    /// </summary>
    public string? Src { get; }

    /// <summary>
    /// Gets the nonce attribute.
    /// </summary>
    public string? Nonce { get; }

    /// <summary>
    /// Gets the integrity attribute.
    /// </summary>
    public string? Integrity { get; }

    /// <summary>
    /// Gets the cross-origin attribute.
    /// </summary>
    public string? CrossOrigin { get; }

    /// <summary>
    /// Gets the script content.
    /// </summary>
    public string? Content { get; }

    /// <inheritdoc />
    public override string ToString()
    {
        if (!string.IsNullOrWhiteSpace(Src))
        {
            return Src;
        }

        if (!string.IsNullOrWhiteSpace(Content))
        {
            return Content.Length > 10 ?
                // ReSharper disable once ReplaceSubstringWithRangeIndexer
                Content.Substring(0, 10) : Content;
        }

        return "Script index " + Index;
    }
}