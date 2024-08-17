using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Testing.Headers;
using Sidio.Web.Security.Testing.Headers.Exceptions;

namespace Sidio.Web.Security.Testing.Tests.Headers;

public sealed class StrictTransportSecurityHeaderExtensionsTests
{
    [Fact]
    public void WithMaxAge_WhenHeaderHasExpectedMaxAge_ShouldNotThrowException()
    {
        // arrange
        var header = new StrictTransportSecurityHeaderOptions
        {
            MaxAge = 31536000
        };

        // act
        var action = () => header.WithMaxAge(31536000);

        // assert
        action.Should().NotThrow();
        action().Should().BeSameAs(header);
    }

    [Fact]
    public void WithMaxAge_WhenHeaderHasDifferentMaxAge_ShouldThrowException()
    {
        // arrange
        var header = new StrictTransportSecurityHeaderOptions
        {
            MaxAge = 31536000
        };

        // act
        var action = () => header.WithMaxAge(0);

        // assert
        action.Should().ThrowExactly<DirectiveShouldHaveValueException>();
    }

    [Fact]
    public void WithIncludeSubDomains_WhenHeaderHasExpectedIncludeSubDomains_ShouldNotThrowException()
    {
        // arrange
        var header = new StrictTransportSecurityHeaderOptions
        {
            IncludeSubDomains = true
        };

        // act
        var action = () => header.WithIncludeSubDomains(true);

        // assert
        action.Should().NotThrow();
        action().Should().BeSameAs(header);
    }

    [Fact]
    public void WithIncludeSubDomains_WhenHeaderHasDifferentIncludeSubDomains_ShouldThrowException()
    {
        // arrange
        var header = new StrictTransportSecurityHeaderOptions
        {
            IncludeSubDomains = true
        };

        // act
        var action = () => header.WithIncludeSubDomains(false);

        // assert
        action.Should().ThrowExactly<DirectiveShouldHaveValueException>();
    }

    [Fact]
    public void WithPreload_WhenHeaderHasExpectedPreload_ShouldNotThrowException()
    {
        // arrange
        var header = new StrictTransportSecurityHeaderOptions
        {
            Preload = true
        };

        // act
        var action = () => header.WithPreload(true);

        // assert
        action.Should().NotThrow();
        action().Should().BeSameAs(header);
    }

    [Fact]
    public void WithPreload_WhenHeaderHasDifferentPreload_ShouldThrowException()
    {
        // arrange
        var header = new StrictTransportSecurityHeaderOptions
        {
            Preload = true
        };

        // act
        var action = () => header.WithPreload(false);

        // assert
        action.Should().ThrowExactly<DirectiveShouldHaveValueException>();
    }
}