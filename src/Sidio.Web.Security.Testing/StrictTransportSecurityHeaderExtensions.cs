using Sidio.Web.Security.Headers;
using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Testing.Exceptions;

namespace Sidio.Web.Security.Testing;

/// <summary>
/// Extensions for <see cref="StrictTransportSecurityHeader"/> and <see cref="StrictTransportSecurityHeaderOptions"/>.
/// </summary>
public static class StrictTransportSecurityHeaderExtensions
{
    /// <summary>
    /// Asserts that the header has valid options.
    /// </summary>
    /// <param name="header">The header.</param>
    /// <returns>The <see cref="StrictTransportSecurityHeaderOptions"/>.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the result is valid, but the options are null.</exception>
    /// <exception cref="HeaderShouldBeValidException">Thrown when the options are invalid.</exception>
    public static StrictTransportSecurityHeaderOptions HasValidOptions(this StrictTransportSecurityHeader header)
    {
        var validationResult = header.Validate(out var options);
        if (validationResult.IsValid)
        {
            return options ?? throw new InvalidOperationException("The options should not be null.");
        }

        throw new HeaderShouldBeValidException(header);
    }

    /// <summary>
    /// Asserts that the header has a specific value for the max-age directive.
    /// </summary>
    /// <param name="options">The options.</param>
    /// <param name="expectedMaxAge">The expected value.</param>
    /// <returns>The <see cref="StrictTransportSecurityHeaderOptions"/>.</returns>
    /// <exception cref="DirectiveShouldHaveValueException">Thrown when the expected value is different from the actual value.</exception>
    public static StrictTransportSecurityHeaderOptions WithMaxAge(
        this StrictTransportSecurityHeaderOptions options,
        long expectedMaxAge)
    {
        if (options.MaxAge != expectedMaxAge)
        {
            throw new DirectiveShouldHaveValueException(nameof(options.MaxAge), expectedMaxAge, options.MaxAge);
        }

        return options;
    }

    /// <summary>
    /// Asserts that the header has a specific value for the includeSubDomains directive.
    /// </summary>
    /// <param name="options">The options.</param>
    /// <param name="expectedIncludeSubDomains">The expected value.</param>
    /// <returns>The <see cref="StrictTransportSecurityHeaderOptions"/>.</returns>
    /// <exception cref="DirectiveShouldHaveValueException">Thrown when the expected value is different from the actual value.</exception>
    public static StrictTransportSecurityHeaderOptions WithIncludeSubDomains(
        this StrictTransportSecurityHeaderOptions options,
        bool expectedIncludeSubDomains)
    {
        if (options.IncludeSubDomains != expectedIncludeSubDomains)
        {
            throw new DirectiveShouldHaveValueException(nameof(options.IncludeSubDomains), expectedIncludeSubDomains, options.IncludeSubDomains);
        }

        return options;
    }

    /// <summary>
    /// Asserts that the header has a specific value for the preload directive.
    /// </summary>
    /// <param name="options">The options.</param>
    /// <param name="expectedPreload">The expected value.</param>
    /// <returns>The <see cref="StrictTransportSecurityHeaderOptions"/>.</returns>
    /// <exception cref="DirectiveShouldHaveValueException">Thrown when the expected value is different from the actual value.</exception>
    public static StrictTransportSecurityHeaderOptions WithPreload(
        this StrictTransportSecurityHeaderOptions options,
        bool expectedPreload)
    {
        if (options.Preload != expectedPreload)
        {
            throw new DirectiveShouldHaveValueException(nameof(options.Preload), expectedPreload, options.Preload);
        }

        return options;
    }
}