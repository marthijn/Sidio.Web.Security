using Sidio.Web.Security.Html;
using Sidio.Web.Security.Testing.Html.Exceptions;

namespace Sidio.Web.Security.Testing.Html;

/// <summary>
/// Extensions for <see cref="ScriptTagCollection"/>.
/// </summary>
public static class ScriptTagCollectionExtensions
{
    private static readonly string[] ValidCrossOriginValues = ["anonymous", ""];

    /// <summary>
    /// Asserts that the <see cref="ScriptTagCollection"/> is not empty.
    /// </summary>
    /// <param name="collection">The script tag collection.</param>
    /// <returns>The <see cref="ScriptTagCollection"/>.</returns>
    /// <exception cref="ScriptTagCollectionShouldNotBeEmptyException">Thrown when the collection is empty.</exception>
    public static ScriptTagCollection ShouldNotBeEmpty(this ScriptTagCollection? collection)
    {
        if (collection == null || collection.Count == 0)
        {
            throw new ScriptTagCollectionShouldNotBeEmptyException();
        }

        return collection;
    }

    /// <summary>
    /// Asserts that all <see cref="ScriptTag"/>s have a nonce attribute.
    /// </summary>
    /// <param name="collection">The script tag collection.</param>
    /// <returns>The <see cref="ScriptTagCollection"/>.</returns>
    /// <exception cref="ScriptTagShouldHaveNonceAttributeException">Thrown when the nonce attribute is missing.</exception>
    public static ScriptTagCollection ShouldAllHaveNonceAttribute(this ScriptTagCollection collection)
    {
        foreach (var scriptTag in collection.Where(scriptTag => string.IsNullOrWhiteSpace(scriptTag.Nonce)))
        {
            throw new ScriptTagShouldHaveNonceAttributeException(scriptTag);
        }

        return collection;
    }

    /// <summary>
    /// Asserts that all <see cref="ScriptTag"/>s have an integrity attribute.
    /// </summary>
    /// <param name="collection">The script tag collection.</param>
    /// <returns>The <see cref="ScriptTagCollection"/>.</returns>
    /// <exception cref="ScriptTagShouldHaveIntegrityAttributeException">Thrown when the integrity attribute is missing.</exception>
    public static ScriptTagCollection ShouldAllHaveIntegrityAttribute(this ScriptTagCollection collection)
    {
        foreach (var scriptTag in collection.Where(scriptTag => string.IsNullOrWhiteSpace(scriptTag.Integrity)))
        {
            throw new ScriptTagShouldHaveIntegrityAttributeException(scriptTag);
        }

        return collection;
    }

    /// <summary>
    /// Asserts that all <see cref="ScriptTag"/>s have a cross-origin attribute.
    /// </summary>
    /// <param name="collection">The script tag collection.</param>
    /// <returns>The <see cref="ScriptTagCollection"/>.</returns>
    /// <exception cref="ScriptTagShouldHaveCrossOriginAttributeException">Thrown when the cross-origin attribute is missing.</exception>
    /// <exception cref="ScriptTagShouldHaveValidCrossOriginAttributeException">Thrown when the cross-origin attribute have an invalid value.</exception>
    public static ScriptTagCollection ShouldAllHaveCrossOriginAttribute(this ScriptTagCollection collection)
    {
        foreach (var scriptTag in collection.Where(scriptTag => scriptTag.CrossOrigin == null))
        {
            throw new ScriptTagShouldHaveCrossOriginAttributeException(scriptTag);
        }

        foreach (var scriptTag in collection.Where(
                     scriptTag => !ValidCrossOriginValues.Contains(
                         scriptTag.CrossOrigin,
                         StringComparer.OrdinalIgnoreCase)))
        {
            throw new ScriptTagShouldHaveValidCrossOriginAttributeException(scriptTag);
        }

        return collection;
    }
}