using Sidio.Web.Security.Cryptography;

namespace Sidio.Web.Security.Tests.Cryptography;

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

    [Fact]
    public void Equals_WithSameValue_ReturnsTrue()
    {
        // arrange
        var nonce1 = new Nonce("test");
        var nonce2 = new Nonce("test");

        // act
        var result = nonce1 == nonce2;

        // assert
        result.Should().BeTrue();
    }
}