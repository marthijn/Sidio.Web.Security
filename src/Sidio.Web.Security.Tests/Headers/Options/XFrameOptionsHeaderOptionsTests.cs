using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.Tests.Headers.Options;

public sealed class XFrameOptionsHeaderOptionsTests
{
    [Theory]
    [InlineData(XFrameOptionsHeaderOptions.XFrameOptionsDirective.Deny, "DENY")]
    [InlineData(XFrameOptionsHeaderOptions.XFrameOptionsDirective.SameOrigin, "SAMEORIGIN")]
    public void ToString_ReturnsExpected(XFrameOptionsHeaderOptions.XFrameOptionsDirective directive, string expected)
    {
        // Arrange
        var options = new XFrameOptionsHeaderOptions
        {
            Directive = directive,
        };

        // Act
        var result = options.ToString();

        // Assert
        result.Should().Be(expected);
        result.Should().BeEquivalentTo(options.Value);
    }
}