using Sidio.Web.Security.AspNetCore.ContentSecurityPolicy;
using Sidio.Web.Security.Cryptography;
using Sidio.Web.Security.Headers.Options.ContentSecurityPolicy;

namespace Sidio.Web.Security.AspNetCore.Tests.ContentSecurityPolicy;

public sealed class SrcBuilderExtensionsTests
{
    private readonly Fixture _fixture = new();

    [Fact]
    public void AddNonce_ScriptSrcBuilderIsNull_ThrowsArgumentNullException()
    {
        // arrange
        ScriptSrcBuilder scriptSrcBuilder = null!;
        var serviceProvider = new Mock<IServiceProvider>();

        // act
        Action act = () => scriptSrcBuilder.AddNonce(serviceProvider.Object);

        // assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void AddNonce_ScriptSrcBuilderIsNotNull_AddsNonce()
    {
        // arrange
        var scriptSrcBuilder = new ScriptSrcBuilder();
        var serviceProvider = new Mock<IServiceProvider>();
        var nonceService = new Mock<INonceService>();
        var nonce = new Nonce(_fixture.Create<string>());
        nonceService.Setup(x => x.GetOrCreateNonce()).Returns(nonce);
        serviceProvider.Setup(x => x.GetService(typeof(INonceService))).Returns(nonceService.Object);

        // act
        var result = scriptSrcBuilder.AddNonce(serviceProvider.Object);

        // assert
        result.ToString().Should().Contain(nonce.Value);
    }

    [Fact]
    public void AddNonce_StyleSrcBuilderIsNull_ThrowsArgumentNullException()
    {
        // arrange
        StyleSrcBuilder styleSrcBuilder = null!;
        var serviceProvider = new Mock<IServiceProvider>();

        // act
        Action act = () => styleSrcBuilder.AddNonce(serviceProvider.Object);

        // assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void AddNonce_StyleSrcBuilderIsNotNull_AddsNonce()
    {
        // arrange
        var styleSrcBuilder = new StyleSrcBuilder();
        var serviceProvider = new Mock<IServiceProvider>();
        var nonceService = new Mock<INonceService>();
        var nonce = new Nonce(_fixture.Create<string>());
        nonceService.Setup(x => x.GetOrCreateNonce()).Returns(nonce);
        serviceProvider.Setup(x => x.GetService(typeof(INonceService))).Returns(nonceService.Object);

        // act
        var result = styleSrcBuilder.AddNonce(serviceProvider.Object);

        // assert
        result.ToString().Should().Contain(nonce.Value);
    }
}