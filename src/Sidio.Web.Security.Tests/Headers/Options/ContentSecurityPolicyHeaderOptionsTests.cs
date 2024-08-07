using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.Tests.Headers.Options;

public sealed class ContentSecurityPolicyHeaderOptionsTests
{
    private readonly Fixture _fixture = new();

    [Fact]
    public void ToString_ShouldReturnPolicy()
    {
        // arrange
        var options = _fixture.Create<ContentSecurityPolicyHeaderOptions>();

        // act
        var result = options.ToString();

        // assert
        result.Should().NotBeNullOrWhiteSpace();

        result.Should().Contain($"default-src {options.DefaultSrc}");
        result.Should().Contain($"script-src {options.ScriptSrc}");
        result.Should().Contain($"script-src-attr {options.ScriptSrcAttr}");
        result.Should().Contain($"script-src-elem {options.ScriptSrcElem}");
        result.Should().Contain($"style-src {options.StyleSrc}");
        result.Should().Contain($"style-src-attr {options.StyleSrcAttr}");
        result.Should().Contain($"style-src-elem {options.StyleSrcElem}");
    }
}