using Sidio.Web.Security.Headers.Cryptography;

namespace Sidio.Web.Security.Tests.Headers.Cryptography;

public sealed class NonceTests
{
    [Fact]
    public void Constructor_WithNullValue_ThrowsArgumentNullException()
    {
        // act
        var act = () => new Nonce(null!);

        // assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Create_WithDefaultLength_ReturnsNonce()
    {
        // act
        var nonce = Nonce.Create();

        // assert
        nonce.Should().NotBeNull();
        nonce.Value.Should().NotBeNullOrWhiteSpace();
        nonce.Value.Should().NotContain("=");
        nonce.Value.Should().NotContain("+");
        nonce.Value.Should().NotContain("/");
    }
}