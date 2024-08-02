using Sidio.Http.Security.Headers;

namespace Sidio.Http.Security.Tests.Headers;

public sealed class XFrameOptionsHeaderTests
{
    private readonly Fixture _fixture = new();

    [Fact]
    public void Constructor_GivenValue_ShouldSetProperties()
    {
        // arrange
        var value = _fixture.Create<string>();

        // act
        var header = new XFrameOptionsHeader(value);

        // assert
        header.Value.Should().Be(value);
    }

    [Theory]
    [InlineData("DENY")]
    [InlineData("SAMEORIGIN")]
    public void Validate_GivenValidValue_ShouldReturnValidResult(string value)
    {
        // arrange
        var header = new XFrameOptionsHeader(value);

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
        var header = new XFrameOptionsHeader(value);

        // act
        var result = header.Validate();

        // assert
        result.IsValid.Should().BeFalse();
    }

    [Fact]
    public void Validate_GivenAllowFrom_ShouldReturnInvalidResult()
    {
        // arrange
        var header = new XFrameOptionsHeader("ALLOW-FROM https://example.com");

        // act
        var result = header.Validate();

        // assert
        result.IsValid.Should().BeFalse();
    }
}