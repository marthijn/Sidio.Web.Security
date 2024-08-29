namespace Sidio.Web.Security.Html;

/// <summary>
/// The collection of script tags.
/// </summary>
public sealed class ScriptTagCollection : List<ScriptTag>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ScriptTagCollection"/> class.
    /// </summary>
    public ScriptTagCollection()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ScriptTagCollection"/> class.
    /// </summary>
    /// <param name="scriptTags">The script tags.</param>
    public ScriptTagCollection(IEnumerable<ScriptTag> scriptTags)
    {
        AddRange(scriptTags);
    }

    /// <summary>
    /// Gets the script tags that have a src attribute that points to an external origin.
    /// </summary>
    public ScriptTagCollection FromExternalOrigin
    {
        get
        {
            var result = this.Where(
                x => !string.IsNullOrWhiteSpace(x.Src) && (x.Src.StartsWith("//", StringComparison.OrdinalIgnoreCase) ||
                                                           x.Src.StartsWith(
                                                               "http://",
                                                               StringComparison.OrdinalIgnoreCase) || x.Src.StartsWith(
                                                               "https://",
                                                               StringComparison.OrdinalIgnoreCase)));
            return new ScriptTagCollection(result);
        }
    }
}