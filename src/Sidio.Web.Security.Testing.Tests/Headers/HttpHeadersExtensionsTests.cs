using Sidio.Web.Security.Headers;
using Sidio.Web.Security.Testing.Headers;
using Sidio.Web.Security.Testing.Headers.Exceptions;

namespace Sidio.Web.Security.Testing.Tests.Headers;

public sealed class HttpHeadersExtensionsTests
{
    [Fact]
    public void ShouldHaveXFrameOptionsHeader_WhenHeaderExists_ShouldNotThrowException()
    {
        // arrange
        var headers = new MockHttpHeaders(new XFrameOptionsHeader("DENY"));

        // act
        var action = () => headers.ShouldHaveXFrameOptionsHeader();

        // assert
        action.Should().NotThrow();
        action().Should().NotBeNull();
    }

    [Fact]
    public void ShouldHaveXFrameOptionsHeader_WhenHeaderDoesNotExist_ShouldThrowException()
    {
        // arrange
        var headers = new MockHttpHeaders();

        // act
        var action = () => headers.ShouldHaveXFrameOptionsHeader();

        // assert
        action.Should().Throw<HeaderShouldExistException>();
    }

    [Fact]
    public void ShouldHaveXContentTypeOptionsHeader_WhenHeaderExists_ShouldNotThrowException()
    {
        // arrange
        var headers = new MockHttpHeaders(new XContentTypeOptionsHeader());

        // act
        var action = () => headers.ShouldHaveXContentTypeOptionsHeader();

        // assert
        action.Should().NotThrow();
        action().Should().NotBeNull();
    }

    [Fact]
    public void ShouldHaveXContentTypeOptionsHeader_WhenHeaderDoesNotExist_ShouldThrowException()
    {
        // arrange
        var headers = new MockHttpHeaders();

        // act
        var action = () => headers.ShouldHaveXContentTypeOptionsHeader();

        // assert
        action.Should().Throw<HeaderShouldExistException>();
    }

    [Fact]
    public void ShouldHaveStrictTransportSecurityHeader_WhenHeaderExists_ShouldNotThrowException()
    {
        // arrange
        var headers = new MockHttpHeaders(new StrictTransportSecurityHeader("max-age=31536000"));

        // act
        var action = () => headers.ShouldHaveStrictTransportSecurityHeader();

        // assert
        action.Should().NotThrow();
        action().Should().NotBeNull();
    }

    [Fact]
    public void ShouldHaveStrictTransportSecurityHeader_WhenHeaderDoesNotExist_ShouldThrowException()
    {
        // arrange
        var headers = new MockHttpHeaders();

        // act
        var action = () => headers.ShouldHaveStrictTransportSecurityHeader();

        // assert
        action.Should().Throw<HeaderShouldExistException>();
    }

    [Fact]
    public void ShouldHaveXXssProtectionHeader_WhenHeaderExists_ShouldNotThrowException()
    {
        // arrange
        var headers = new MockHttpHeaders(new XXssProtectionHeader("1; mode=block"));

        // act
        var action = () => headers.ShouldHaveXXssProtectionHeader();

        // assert
        action.Should().NotThrow();
        action().Should().NotBeNull();
    }

    [Fact]
    public void ShouldHaveXXssProtectionHeader_WhenHeaderDoesNotExist_ShouldThrowException()
    {
        // arrange
        var headers = new MockHttpHeaders();

        // act
        var action = () => headers.ShouldHaveXXssProtectionHeader();

        // assert
        action.Should().Throw<HeaderShouldExistException>();
    }

    [Fact]
    public void ShouldNotHaveXXssProtectionHeader_WhenHeaderExists_ShouldThrowException()
    {
        // arrange
        var headers = new MockHttpHeaders(new XXssProtectionHeader("1; mode=block"));

        // act
        var action = () => headers.ShouldNotHaveXXssProtectionHeader();

        // assert
        action.Should().Throw<HeaderShouldNotExistException>();
    }

    [Fact]
    public void ShouldNotHaveXXssProtectionHeader_WhenHeaderDoesNotExist_ShouldNotThrowException()
    {
        // arrange
        var headers = new MockHttpHeaders();

        // act
        var action = () => headers.ShouldNotHaveXXssProtectionHeader();

        // assert
        action.Should().NotThrow();
    }

    [Fact]
    public void ShouldHaveContentSecurityPolicyHeader_WhenHeaderExists_ShouldNotThrowException()
    {
        // arrange
        var headers = new MockHttpHeaders(new ContentSecurityPolicyHeader("default-src 'self'"));

        // act
        var action = () => headers.ShouldHaveContentSecurityPolicyHeader();

        // assert
        action.Should().NotThrow();
        action().Should().NotBeNull();
    }

    [Fact]
    public void ShouldHaveContentSecurityPolicyHeader_WhenHeaderDoesNotExist_ShouldThrowException()
    {
        // arrange
        var headers = new MockHttpHeaders();

        // act
        var action = () => headers.ShouldHaveContentSecurityPolicyHeader();

        // assert
        action.Should().Throw<HeaderShouldExistException>();
    }

    [Fact]
    public void ShouldHaveReportToHeader_WhenHeaderExists_ShouldNotThrowException()
    {
        // arrange
        var headers = new MockHttpHeaders(new ReportToHeader(string.Empty));

        // act
        var action = () => headers.ShouldHaveReportToHeader();

        // assert
        action.Should().NotThrow();
        action().Should().NotBeNull();
    }

    [Fact]
    public void ShouldHaveReportToHeader_WhenHeaderDoesNotExist_ShouldThrowException()
    {
        // arrange
        var headers = new MockHttpHeaders();

        // act
        var action = () => headers.ShouldHaveReportToHeader();

        // assert
        action.Should().Throw<HeaderShouldExistException>();
    }

    [Fact]
    public void ShouldHaveReferrerPolicyHeader_WhenHeaderExists_ShouldNotThrowException()
    {
        // arrange
        var headers = new MockHttpHeaders(new ReferrerPolicyHeader(string.Empty));

        // act
        var action = () => headers.ShouldHaveReferrerPolicyHeader();

        // assert
        action.Should().NotThrow();
        action().Should().NotBeNull();
    }

    [Fact]
    public void ShouldHaveReferrerPolicyHeader_WhenHeaderDoesNotExist_ShouldThrowException()
    {
        // arrange
        var headers = new MockHttpHeaders();

        // act
        var action = () => headers.ShouldHaveReferrerPolicyHeader();

        // assert
        action.Should().Throw<HeaderShouldExistException>();
    }
}