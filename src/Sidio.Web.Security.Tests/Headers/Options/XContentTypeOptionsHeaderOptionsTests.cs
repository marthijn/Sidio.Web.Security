using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.Tests.Headers.Options;

public sealed class XContentTypeOptionsHeaderOptionsTests
{
    [Fact]
    public void ToString_ReturnsExpected()
    {
        // Arrange
        var options = new XContentTypeOptionsHeaderOptions();

        // Act
        var result = options.ToString();

        // Assert
        result.Should().Be("nosniff");
        result.Should().BeEquivalentTo(options.Value);
    }
}