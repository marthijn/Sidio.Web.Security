using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Headers.Validation;

namespace Sidio.Web.Security.Headers;

/// <summary>
/// The HTTP header factory.
/// </summary>
public static class HttpHeaderFactory
{
    /// <summary>
    /// Creates a new instance of the specified header type with the given value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <typeparam name="T">The header type.</typeparam>
    /// <returns>An HTTP header of type <see cref="T"/>.</returns>
    /// <exception cref="InvalidHeaderException">Thrown when the header value is invalid.</exception>
    public static T Create<T>(string? value)
        where T : HttpHeader
    {
        var header = Activator.CreateInstance(typeof(T), value) as T ??
                     throw new InvalidOperationException($"Failed to create header instance of type {typeof(T).Name}");
        var validationResult = header.Validate();
        if (validationResult.HasErrors)
        {
            throw new InvalidHeaderException(header, validationResult);
        }

        return header;
    }

    /// <summary>
    /// Creates a new instance of the specified header type with the given value.
    /// </summary>
    /// <param name="options">The options.</param>
    /// <typeparam name="T">The header type.</typeparam>
    /// <returns>An HTTP header of type <see cref="T"/>.</returns>
    /// <exception cref="InvalidHeaderException">Thrown when the header value is invalid.</exception>
    public static T Create<T>(IHttpHeaderOptions options)
        where T : HttpHeader =>
        Create<T>(options.Value);
}