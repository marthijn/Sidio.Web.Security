using Sidio.Web.Security.Html;

namespace Sidio.Web.Security.Tests.Html;

public sealed class ScriptTagCollectionTests
{
    private readonly Fixture _fixture = new();

    [Fact]
    public void Constructor_WhenScriptTagCollectionIsCreatedWithScriptTags_CollectionIsNotEmpty()
    {
        // arrange
        var items = _fixture.CreateMany<ScriptTag>(10);

        // act
        var collection = new ScriptTagCollection(items);

        // assert
        collection.Should().NotBeEmpty();
        collection.Should().HaveCount(10);
    }

    [Fact]
    public void FromExternalOrigin_WhenScriptTagCollectionContainsScriptTagsFromExternalOrigin_ReturnsScriptTagCollection()
    {
        // arrange
        var items = new List<ScriptTag>
        {
            new (1, "src", null, "integrity", "crossOrigin", null),
            new (2, "http://example.com/script.js", null, "integrity", "crossOrigin", null),
            new (3, "https://example.com/script.js", null, "integrity", "crossOrigin", null),
            new (4, "//example.com/script.js", null, "integrity", "crossOrigin", null),
        };

        // act
        var collection = new ScriptTagCollection(items).FromExternalOrigin;

        // assert
        collection.Should().NotBeEmpty();
        collection.Should().HaveCount(3);
    }
}