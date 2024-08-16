using Sidio.Web.Security.Headers;

namespace Sidio.Web.Security.Tests.Headers;

public sealed class ReferrerPolicyHeaderTests
{
    private readonly Fixture _fixture = new();

    [Fact]
    public void Constructor_GivenValue_ShouldSetProperties()
    {
        // arrange
        var value = _fixture.Create<string>();

        // act
        var header = new ReferrerPolicyHeader(value);

        // assert
        header.Value.Should().Be(value);
    }
}