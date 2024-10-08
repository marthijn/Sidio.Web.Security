﻿using Sidio.Web.Security.Headers;
using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Testing.Headers.Exceptions;

namespace Sidio.Web.Security.Testing.Headers;

/// <summary>
/// The extension methods for <see cref="HttpHeader"/>.
/// </summary>
public static class HttpHeaderExtensions
{
    /// <summary>
    /// Asserts that the header has a specific value.
    /// </summary>
    /// <param name="header">The header.</param>
    /// <param name="expectedValue">The expected value.</param>
    /// <typeparam name="T">The header type.</typeparam>
    /// <returns>The header of type <see cref="HttpHeader"/>.</returns>
    /// <exception cref="HttpHeaderShouldHaveValueException">Thrown when the actual value is different from the expected value.</exception>
    public static T WithValue<T>(this T header, string expectedValue)
        where T : HttpHeader
    {
        if (!expectedValue.Equals(header.Value, StringComparison.OrdinalIgnoreCase))
        {
            throw new HttpHeaderShouldHaveValueException(header, expectedValue);
        }

        return header;
    }

    /// <summary>
    /// Asserts that the header has a non-empty value.
    /// </summary>
    /// <param name="header">The header.</param>
    /// <typeparam name="T">The header type.</typeparam>
    /// <returns>The header of type <see cref="HttpHeader"/>.</returns>
    /// <exception cref="HttpHeaderShouldNotBeEmptyException">Thrown when the header value is empty.</exception>
    public static T WithNonEmptyValue<T>(this T header)
        where T : HttpHeader
    {
        if (string.IsNullOrEmpty(header.Value))
        {
            throw new HttpHeaderShouldNotBeEmptyException(header);
        }

        return header;
    }

    /// <summary>
    /// Asserts that the header contains a specific value.
    /// </summary>
    /// <param name="header">The header.</param>
    /// <param name="expectedValue">The expected value.</param>
    /// <typeparam name="T">The header type.</typeparam>
    /// <returns>The header of type <see cref="HttpHeader"/>.</returns>
    /// <exception cref="HttpHeaderShouldHaveValueException">Thrown when the header value does not contain the expected value.</exception>
    public static T ContainsValue<T>(this T header, string expectedValue)
        where T : HttpHeader
    {
        if (header.Value == null || header.Value.IndexOf(expectedValue, StringComparison.OrdinalIgnoreCase) < 0)
        {
            throw new HttpHeaderShouldHaveValueException(header, expectedValue);
        }

        return header;
    }

    /// <summary>
    /// Asserts that the header has a valid value that can be converted to the corresponding options.
    /// </summary>
    /// <param name="header">The header.</param>
    /// <typeparam name="TOptions">The options type.</typeparam>
    /// <returns>Options of type <see cref="TOptions"/>.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the result is valid, but the options are null.</exception>
    /// <exception cref="HeaderShouldBeValidException">Thrown when the header value is invalid.</exception>
    public static TOptions HasValidOptions<TOptions>(this ValidatableHttpHeader<TOptions> header)
        where TOptions : class, IHttpHeaderOptions, new()
    {
        var validationResult = header.Validate(out TOptions? options);
        if (validationResult.IsValid)
        {
            return options ?? throw new InvalidOperationException("The options should not be null.");
        }

        throw new HeaderShouldBeValidException(header);
    }
}