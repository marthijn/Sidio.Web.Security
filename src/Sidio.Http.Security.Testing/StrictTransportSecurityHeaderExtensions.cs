using Sidio.Http.Security.Headers;
using Sidio.Http.Security.Headers.Options;
using Sidio.Http.Security.Testing.Exceptions;

namespace Sidio.Http.Security.Testing;

/// <summary>
/// Extensions for <see cref="StrictTransportSecurityHeader"/> and <see cref="StrictTransportSecurityHeaderOptions"/>.
/// </summary>
public static class StrictTransportSecurityHeaderExtensions
{
    public static StrictTransportSecurityHeaderOptions HasValidOptions(this StrictTransportSecurityHeader header)
    {
        var validationResult = header.Validate(out var options);
        if (validationResult.IsValid)
        {
            return options ?? throw new InvalidOperationException("The options should not be null.");
        }

        throw new HeaderShouldBeValidException(header);
    }

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