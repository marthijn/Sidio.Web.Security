using Sidio.Web.Security.Html;

namespace Sidio.Web.Security.Testing.Html.Exceptions;

/// <summary>
/// The exception that is thrown when a script tag should have a valid cross-origin attribute.
/// </summary>
public sealed class ScriptTagShouldHaveValidCrossOriginAttributeException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ScriptTagShouldHaveValidCrossOriginAttributeException"/> class.
    /// </summary>
    /// <param name="scriptTag">The script tag.</param>
    public ScriptTagShouldHaveValidCrossOriginAttributeException(ScriptTag scriptTag) : base(
        $"The script tag with index {scriptTag.Index} content `{scriptTag}` should have a valid cross origin attribute value.")
    {
    }
}