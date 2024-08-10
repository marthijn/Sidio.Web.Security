using Sidio.Web.Security.Headers;

namespace Sidio.Web.Security.Tests.Headers;

public sealed class XContentTypeOptionsHeaderTests
{
    private readonly Fixture _fixture = new();

    [Fact]
    public void Constructor_GivenValue_ShouldSetProperties()
    {
        // arrange
        var value = _fixture.Create<string>();

        // act
        var header = new XContentTypeOptionsHeader(value);

        // assert
        header.Value.Should().Be(value);
    }

    [Fact]
    public void Validate_GivenValidValue_ShouldReturnValidResult()
    {
        // arrange
        var header = new XContentTypeOptionsHeader();

        // act
        var result = header.Validate();

        // assert
        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData("test")]
    [InlineData(null)]
    public void Validate_GivenInvalidValue_ShouldReturnInvalidResult(string? value)
    {
        // arrange
        var header = new XContentTypeOptionsHeader(value);

        // act
        var result = header.Validate();

        // assert
        result.IsValid.Should().BeFalse();
    }
}