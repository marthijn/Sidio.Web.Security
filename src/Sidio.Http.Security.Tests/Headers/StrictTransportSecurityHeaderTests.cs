using Sidio.Http.Security.Headers;

namespace Sidio.Http.Security.Tests.Headers;

public sealed class StrictTransportSecurityHeaderTests
{
    private readonly Fixture _fixture = new();

    [Fact]
    public void Constructor_GivenValue_ShouldSetProperties()
    {
        // arrange
        var value = _fixture.Create<string>();

        // act
        var header = new StrictTransportSecurityHeader(value);

        // assert
        header.Value.Should().Be(value);
    }
}