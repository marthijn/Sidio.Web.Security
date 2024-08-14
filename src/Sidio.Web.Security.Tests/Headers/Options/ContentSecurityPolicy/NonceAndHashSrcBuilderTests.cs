using Sidio.Web.Security.Headers.Cryptography;
using Sidio.Web.Security.Headers.Options.ContentSecurityPolicy;

namespace Sidio.Web.Security.Tests.Headers.Options.ContentSecurityPolicy;

public abstract class NonceAndHashSrcBuilderTests<T> : SrcBuilderBaseTests<T>
    where T : NonceAndHashSrcBuilder<T>, new()
{
    private readonly Fixture _fixture = new();

    [Fact]
    public void AddNonce_GivenEmptyNonce_ShouldThrowException()
    {
        // act
        var act = () => Builder.AddNonce(string.Empty);

        // assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void AddNonce_GivenValidNonce_ShouldThrowException()
    {
        // arrange
        var nonce = Nonce.Create();

        // act
        var result = Builder.AddNonce(nonce.Value);

        // assert
        result.SourcesInternal.Should().ContainSingle($"'nonce-{nonce.Value}'");
        result.Should().BeSameAs(Builder);
    }

    [Fact]
    public void AddSha256_GivenEmptySha256_ShouldThrowException()
    {
        // act
        var act = () => Builder.AddSha256(string.Empty);

        // assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void AddSha256_GivenValidSha256_ShouldThrowException()
    {
        // arrange
        var hash = _fixture.Create<string>();

        // act
        var result = Builder.AddSha256(hash);

        // assert
        result.SourcesInternal.Should().ContainSingle($"'sha256-{hash}'");
        result.Should().BeSameAs(Builder);
    }

    [Fact]
    public void AddSha384_GivenEmptySha384_ShouldThrowException()
    {
        // act
        var act = () => Builder.AddSha384(string.Empty);

        // assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void AddSha384_GivenValidSha384_ShouldThrowException()
    {
        // arrange
        var hash = _fixture.Create<string>();

        // act
        var result = Builder.AddSha384(hash);

        // assert
        result.SourcesInternal.Should().ContainSingle($"'sha384-{hash}'");
        result.Should().BeSameAs(Builder);
    }

    [Fact]
    public void AddSha512_GivenEmptySha512_ShouldThrowException()
    {
        // act
        var act = () => Builder.AddSha512(string.Empty);

        // assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void AddSha512_GivenValidSha512_ShouldThrowException()
    {
        // arrange
        var hash = _fixture.Create<string>();

        // act
        var result = Builder.AddSha512(hash);

        // assert
        result.SourcesInternal.Should().ContainSingle($"'sha512-{hash}'");
        result.Should().BeSameAs(Builder);
    }
}