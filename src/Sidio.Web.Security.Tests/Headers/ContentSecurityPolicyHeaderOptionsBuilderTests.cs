using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.Tests.Headers;

public sealed class ContentSecurityPolicyHeaderOptionsBuilderTests
{
    private readonly Fixture _fixture = new();

    [Fact]
    public void AddDefaultSrc_FromSelf_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();

        // act
        var result = builder.AddDefaultSrc(x => x.AllowSelf()).Build();

        // assert
        result.DefaultSrc.Should().Be("'self'");
    }

    [Fact]
    public void AddDefaultSrc_FromAll_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();

        // act
        var result = builder.AddDefaultSrc(x => x.AllowAll()).Build();

        // assert
        result.DefaultSrc.Should().Be("*");
    }

    [Fact]
    public void AddDefaultSrc_FromUrl_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();
        var url = _fixture.Create<string>();

        // act
        var result = builder.AddDefaultSrc(x => x.AllowUrl(url)).Build();

        // assert
        result.DefaultSrc.Should().Be($"{url}");
    }

    [Fact]
    public void AddDefaultSrc_FromUrl_Multiple_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();
        var url1 = _fixture.Create<string>();
        var url2 = _fixture.Create<string>();
        var url3 = _fixture.Create<string>();

        // act
        var result = builder.AddDefaultSrc(x => x.AllowUrl(url1).AllowUrl(url2).AllowUrl(url3)).Build();

        // assert
        result.DefaultSrc.Should().Be($"{url1} {url2} {url3}");
    }

    [Fact]
    public void AddDefaultSrc_FromSelfFormUrl_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();
        var url = _fixture.Create<string>();

        // act
        var result = builder.AddDefaultSrc(x => x.AllowSelf().AllowUrl(url)).Build();

        // assert
        result.DefaultSrc.Should().Be($"'self' {url}");
    }
}