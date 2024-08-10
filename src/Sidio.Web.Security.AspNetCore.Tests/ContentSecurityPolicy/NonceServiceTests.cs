using Microsoft.AspNetCore.Http;
using Sidio.Web.Security.AspNetCore.ContentSecurityPolicy;
using Sidio.Web.Security.Headers.Cryptography;

namespace Sidio.Web.Security.AspNetCore.Tests.ContentSecurityPolicy;

public sealed class NonceServiceTests
{
    private readonly Fixture _fixture = new();

    [Fact]
    public void StoreNewNonce_OverwriteIsFalseAndNonceIsAlreadyStored_ThrowsInvalidOperationException()
    {
        // arrange
        var httpContextAccessor = new Mock<IHttpContextAccessor>();
        var nonceService = new NonceService(httpContextAccessor.Object);
        var nonce = new Nonce(_fixture.Create<string>());

        httpContextAccessor.Setup(x => x.HttpContext!.Items[It.IsAny<string>()]).Returns(nonce);

        // act
        Action act = () => nonceService.StoreNewNonce();

        // assert
        act.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void StoreNewNonce_OverwriteIsTrueAndNonceIsAlreadyStored_ReturnsNewNonce()
    {
        // arrange
        var httpContextAccessor = new Mock<IHttpContextAccessor>();
        var nonceService = new NonceService(httpContextAccessor.Object);
        var nonce = new Nonce(_fixture.Create<string>());

        httpContextAccessor.Setup(x => x.HttpContext!.Items[It.IsAny<string>()]).Returns(nonce);

        // act
        var result = nonceService.StoreNewNonce(overwrite: true);

        // assert
        result.Should().NotBe(nonce);
    }

    [Fact]
    public void StoreNewNonce_OverwriteIsFalseAndNonceIsNotStored_ReturnsNewNonce()
    {
        // arrange
        var httpContextAccessor = new Mock<IHttpContextAccessor>();
        var nonceService = new NonceService(httpContextAccessor.Object);

        httpContextAccessor.Setup(x => x.HttpContext!.Items[It.IsAny<string>()]).Returns(null!);

        // act
        var result = nonceService.StoreNewNonce();

        // assert
        result.Should().NotBeNull();
    }

    [Fact]
    public void GetNonce_NonceIsNotStored_ReturnsNull()
    {
        // arrange
        var httpContextAccessor = new Mock<IHttpContextAccessor>();
        var nonceService = new NonceService(httpContextAccessor.Object);

        httpContextAccessor.Setup(x => x.HttpContext!.Items[It.IsAny<string>()]).Returns(null!);

        // act
        var result = nonceService.GetNonce();

        // assert
        result.Should().BeNull();
    }

    [Fact]
    public void GetNonce_NonceIsStored_ReturnsNonce()
    {
        // arrange
        var httpContextAccessor = new Mock<IHttpContextAccessor>();
        var nonceService = new NonceService(httpContextAccessor.Object);
        var nonce = new Nonce(_fixture.Create<string>());

        httpContextAccessor.Setup(x => x.HttpContext!.Items[It.IsAny<string>()]).Returns(nonce);

        // act
        var result = nonceService.GetNonce();

        // assert
        result.Should().Be(nonce);
    }

    [Fact]
    public void GetOrCreateNonce_NonceIsNotStored_ReturnsNewNonce()
    {
        // arrange
        var httpContextAccessor = new Mock<IHttpContextAccessor>();
        var nonceService = new NonceService(httpContextAccessor.Object);

        httpContextAccessor.Setup(x => x.HttpContext!.Items[It.IsAny<string>()]).Returns(null!);

        // act
        var result = nonceService.GetOrCreateNonce();

        // assert
        result.Should().NotBeNull();
    }

    [Fact]
    public void GetOrCreateNonce_NonceIsStored_ReturnsNonce()
    {
        // arrange
        var httpContextAccessor = new Mock<IHttpContextAccessor>();
        var nonceService = new NonceService(httpContextAccessor.Object);
        var nonce = new Nonce(_fixture.Create<string>());

        httpContextAccessor.Setup(x => x.HttpContext!.Items[It.IsAny<string>()]).Returns(nonce);

        // act
        var result = nonceService.GetOrCreateNonce();

        // assert
        result.Should().Be(nonce);
    }
}