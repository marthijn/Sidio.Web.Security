using Sidio.Web.Security.Html;
using Sidio.Web.Security.Testing.Html;
using Sidio.Web.Security.Testing.Html.Exceptions;

namespace Sidio.Web.Security.Testing.Tests.Html;

public sealed class ScriptTagCollectionExtensionsTests
{
    private readonly Fixture _fixture = new();

    [Fact]
    public void ShouldNotBeEmpty_WhenScriptTagCollectionIsEmpty_ThrowsScriptTagCollectionShouldNotBeEmptyException()
    {
        // arrange
        var scriptTagCollection = new ScriptTagCollection();

        // act
        var act = () => scriptTagCollection.ShouldNotBeEmpty();

        // assert
        act.Should().Throw<ScriptTagCollectionShouldNotBeEmptyException>();
    }

    [Fact]
    public void ShouldNotBeEmpty_WhenScriptTagCollectionIsNotEmpty_ReturnsScriptTagCollection()
    {
        // arrange
        var scriptTagCollection = new ScriptTagCollection
        {
            _fixture.Create<ScriptTag>(),
        };

        // act
        var result = scriptTagCollection.ShouldNotBeEmpty();

        // assert
        result.Should().NotBeEmpty();
        result.Should().BeSameAs(scriptTagCollection);
    }

    [Fact]
    public void ShouldAllHaveNonceAttribute_WhenScriptTagCollectionContainsScriptTagWithoutNonceAttribute_ThrowsScriptTagShouldHaveNonceAttributeException()
    {
        // arrange
        var scriptTagCollection = new ScriptTagCollection
        {
            new (1, "src", null, "integrity", "crossOrigin", null),
        };

        // act
        var act = () => scriptTagCollection.ShouldAllHaveNonceAttribute();

        // assert
        act.Should().Throw<ScriptTagShouldHaveNonceAttributeException>();
    }

    [Fact]
    public void ShouldAllHaveNonceAttribute_WhenScriptTagCollectionContainsScriptTagWithNonceAttribute_ReturnsScriptTagCollection()
    {
        // arrange
        var scriptTagCollection = new ScriptTagCollection
        {
            _fixture.Create<ScriptTag>(),
        };

        // act
        var result = scriptTagCollection.ShouldAllHaveNonceAttribute();

        // assert
        result.Should().NotBeEmpty();
        result.Should().BeSameAs(scriptTagCollection);
    }

    [Fact]
    public void ShouldAllHaveIntegrityAttribute_WhenScriptTagCollectionContainsScriptTagWithoutIntegrityAttribute_ThrowsScriptTagShouldHaveIntegrityAttributeException()
    {
        // arrange
        var scriptTagCollection = new ScriptTagCollection
        {
            new (1, "src", "nonce", null, "crossOrigin", null),
        };

        // act
        var act = () => scriptTagCollection.ShouldAllHaveIntegrityAttribute();

        // assert
        act.Should().Throw<ScriptTagShouldHaveIntegrityAttributeException>();
    }

    [Fact]
    public void ShouldAllHaveIntegrityAttribute_WhenScriptTagCollectionContainsScriptTagWithIntegrityAttribute_ReturnsScriptTagCollection()
    {
        // arrange
        var scriptTagCollection = new ScriptTagCollection
        {
            _fixture.Create<ScriptTag>(),
        };

        // act
        var result = scriptTagCollection.ShouldAllHaveIntegrityAttribute();

        // assert
        result.Should().NotBeEmpty();
        result.Should().BeSameAs(scriptTagCollection);
    }

    [Fact]
    public void ShouldAllHaveCrossOriginAttribute_WhenScriptTagCollectionContainsScriptTagWithoutCrossOriginAttribute_ThrowsScriptTagShouldHaveCrossOriginAttributeException()
    {
        // arrange
        var scriptTagCollection = new ScriptTagCollection
        {
            new (1, "src", "nonce", "integrity", null, null),
        };

        // act
        var act = () => scriptTagCollection.ShouldAllHaveCrossOriginAttribute();

        // assert
        act.Should().Throw<ScriptTagShouldHaveCrossOriginAttributeException>();
    }

    [Fact]
    public void ShouldAllHaveCrossOriginAttribute_WhenScriptTagCollectionContainsScriptTagWithInvalidCrossOriginAttribute_ThrowsScriptTagShouldHaveValidCrossOriginAttributeException()
    {
        // arrange
        var scriptTagCollection = new ScriptTagCollection
        {
            new (1, "src", "nonce", "integrity", "invalid", null),
        };

        // act
        var act = () => scriptTagCollection.ShouldAllHaveCrossOriginAttribute();

        // assert
        act.Should().Throw<ScriptTagShouldHaveValidCrossOriginAttributeException>();
    }

    [Theory]
    [InlineData("anonymous")]
    [InlineData("")]
    public void ShouldAllHaveCrossOriginAttribute_WhenScriptTagCollectionContainsScriptTagWithCrossOriginAttribute_ReturnsScriptTagCollection(string crossOrigin)
    {
        // arrange
        var scriptTagCollection = new ScriptTagCollection
        {
            new (1, "src", "nonce", "integrity", crossOrigin, null),
        };

        // act
        var result = scriptTagCollection.ShouldAllHaveCrossOriginAttribute();

        // assert
        result.Should().NotBeEmpty();
        result.Should().BeSameAs(scriptTagCollection);
    }
}