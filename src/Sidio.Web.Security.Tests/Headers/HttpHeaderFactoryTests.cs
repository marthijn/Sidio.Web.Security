using Sidio.Web.Security.Headers;
using Sidio.Web.Security.Headers.Validation;

namespace Sidio.Web.Security.Tests.Headers;

public sealed class HttpHeaderFactoryTests
{
    [Fact]
    public void Create_XFrameOptionsHeader_ReturnsInstance()
    {
        // act
        var result = HttpHeaderFactory.Create<XFrameOptionsHeader>("DENY");

        // assert
        result.Should().NotBeNull();
    }

    [Fact]
    public void Create_XContentTypeOptionsHeader_ReturnsInstance()
    {
        // act
        var result = HttpHeaderFactory.Create<XContentTypeOptionsHeader>("nosniff");

        // assert
        result.Should().NotBeNull();
    }

    [Fact]
    public void Create_StrictTransportSecurityHeader_ReturnsInstance()
    {
        // act
        var result = HttpHeaderFactory.Create<StrictTransportSecurityHeader>("max-age=5");

        // assert
        result.Should().NotBeNull();
    }

    [Fact]
    public void Create_ContentSecurityPolicyHeader_ReturnsInstance()
    {
        // act
        var result = HttpHeaderFactory.Create<ContentSecurityPolicyHeader>("default-src 'self'");

        // assert
        result.Should().NotBeNull();
    }

    [Fact]
    public void Create_PermissionsPolicyHeader_ReturnsInstance()
    {
        // act
        var result = HttpHeaderFactory.Create<PermissionsPolicyHeader>("geolocation=*");

        // assert
        result.Should().NotBeNull();
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void Create_WithInvalidHeaderValue_ShouldThrowException(bool validate)
    {
        // act
        Action act = () => HttpHeaderFactory.Create<XContentTypeOptionsHeader>(string.Empty, validate);

        // assert
        if (validate)
        {
            act.Should().Throw<InvalidHeaderException>();
        }
        else
        {
            act.Should().NotThrow();
        }
    }
}