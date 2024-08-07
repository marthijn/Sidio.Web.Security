using Sidio.Web.Security.Headers;

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
}