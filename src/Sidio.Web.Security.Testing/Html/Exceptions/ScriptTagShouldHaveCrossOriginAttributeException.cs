using Sidio.Web.Security.Html;

namespace Sidio.Web.Security.Testing.Html.Exceptions;

/// <summary>
/// The exception that is thrown when a script tag should have a cross-origin attribute.
/// </summary>
public sealed class ScriptTagShouldHaveCrossOriginAttributeException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ScriptTagShouldHaveCrossOriginAttributeException"/> class.
    /// </summary>
    /// <param name="scriptTag">The script tag.</param>
    public ScriptTagShouldHaveCrossOriginAttributeException(ScriptTag scriptTag) : base(
        $"The script tag with index {scriptTag.Index} and content `{scriptTag}` should have a cross origin attribute.")
    {
    }
}