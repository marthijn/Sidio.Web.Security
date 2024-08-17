using Sidio.Web.Security.Headers;
using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Testing.Headers;
using Sidio.Web.Security.Testing.Headers.Exceptions;

namespace Sidio.Web.Security.Testing.Tests.Headers;

public sealed class HttpHeaderExtensionsTests
{
    [Fact]
    public void WithValue_WhenHeaderHasExpectedValue_ShouldNotThrowException()
    {
        // arrange
        var header = new XFrameOptionsHeader("DENY");

        // act
        var action = () => header.WithValue("DENY");

        // assert
        action.Should().NotThrow();
        action().Should().BeSameAs(header);
    }

    [Fact]
    public void WithValue_WhenHeaderHasDifferentValue_ShouldThrowException()
    {
        // arrange
        var header = new XFrameOptionsHeader("DENY");

        // act
        var action = () => header.WithValue("SAMEORIGIN");

        // assert
        action.Should().ThrowExactly<HttpHeaderShouldHaveValueException>();
    }

    [Fact]
    public void WithNonEmptyValue_WhenHeaderHasValue_ShouldNotThrowException()
    {
        // arrange
        var header = new XFrameOptionsHeader("DENY");

        // act
        var action = () => header.WithNonEmptyValue();

        // assert
        action.Should().NotThrow();
        action().Should().BeSameAs(header);
    }

    [Fact]
    public void WithNonEmptyValue_WhenHeaderHasEmptyValue_ShouldThrowException()
    {
        // arrange
        var header = new XFrameOptionsHeader(string.Empty);

        // act
        var action = () => header.WithNonEmptyValue();

        // assert
        action.Should().ThrowExactly<HttpHeaderShouldNotBeEmptyException>();
    }

    [Theory]
    [InlineData("DENY")]
    [InlineData("ENY")]
    [InlineData("DEN")]
    [InlineData("EN")]
    public void ContainsValue_WhenHeaderContainsValue_ShouldNotThrowException(string value)
    {
        // arrange
        var header = new XFrameOptionsHeader("DENY");

        // act
        var action = () => header.ContainsValue(value);

        // assert
        action.Should().NotThrow();
        action().Should().BeSameAs(header);
    }

    [Fact]
    public void ContainsValue_WhenHeaderDoesNotContainValue_ShouldThrowException()
    {
        // arrange
        var header = new XFrameOptionsHeader("DENY");

        // act
        var action = () => header.ContainsValue("SAMEORIGIN");

        // assert
        action.Should().ThrowExactly<HttpHeaderShouldHaveValueException>();
    }

    [Fact]
    public void HasValidOptions_WhenHeaderHasValidOptions_ShouldNotThrowException()
    {
        // arrange
        var header = new XFrameOptionsHeader("DENY");

        // act
        var action = () => header.HasValidOptions();

        // assert
        action.Should().NotThrow();
        action().Should().NotBeNull().And.BeOfType(typeof(XFrameOptionsHeaderOptions));
    }

    [Fact]
    public void HasValidOptions_WhenHeaderHasInvalidOptions_ShouldThrowException()
    {
        // arrange
        var header = new XFrameOptionsHeader("ALLOW-FROM https://example.com");

        // act
        var action = () => header.HasValidOptions();

        // assert
        action.Should().ThrowExactly<HeaderShouldBeValidException>();
    }
}