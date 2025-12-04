using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.Tests.Headers.Options;

public sealed class ContentSecurityPolicyHeaderOptionsBuilderExtensionsTests
{
    [Fact]
    public void AppendBrowserLinkPolicy_ShouldAppendDirectives()
    {
        // Arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AppendBrowserLinkPolicy();

        // Assert
        result.Options.ConnectSrc.Should().Be("'unsafe-inline' http://localhost:* https://localhost:* ws://localhost:* wss://localhost:*");
        result.Options.ScriptSrc.Should().Be("'unsafe-inline' http://localhost:* https://localhost:*");
    }

    [Fact]
    public void AppendBrowserLinkPolicy_DirectivesAlreadyExist_ShouldAppendDirectives()
    {
        // Arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder
        {
            Options =
            {
                ConnectSrc = "'self'",
                ScriptSrc = "'self'"
            }
        };

        // Act
        var result = builder.AppendBrowserLinkPolicy();

        // Assert
        result.Options.ConnectSrc.Should().Be("'self' 'unsafe-inline' http://localhost:* https://localhost:* ws://localhost:* wss://localhost:*");
        result.Options.ScriptSrc.Should().Be("'self' 'unsafe-inline' http://localhost:* https://localhost:*");
    }
}