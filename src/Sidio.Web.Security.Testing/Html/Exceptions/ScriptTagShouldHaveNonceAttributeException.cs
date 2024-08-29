using Sidio.Web.Security.Html;

namespace Sidio.Web.Security.Testing.Html.Exceptions;

/// <summary>
/// The exception that is thrown when a script tag should have a nonce attribute.
/// </summary>
public sealed class ScriptTagShouldHaveNonceAttributeException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ScriptTagShouldHaveNonceAttributeException"/> class.
    /// </summary>
    /// <param name="scriptTag">The script tag.</param>
    public ScriptTagShouldHaveNonceAttributeException(ScriptTag scriptTag) : base(
        $"The script tag with index {scriptTag.Index} content `{scriptTag}` should have a nonce attribute.")
    {
    }
}