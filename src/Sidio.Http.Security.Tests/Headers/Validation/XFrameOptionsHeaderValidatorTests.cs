using Sidio.Http.Security.Headers.Options;
using Sidio.Http.Security.Headers.Validation;

namespace Sidio.Http.Security.Tests.Headers.Validation;

public sealed class XFrameOptionsHeaderValidatorTests : HeaderValidatorTests<XFrameOptionsHeaderOptions>
{
    protected override IHeaderValidator<XFrameOptionsHeaderOptions> Validator => new XFrameOptionsHeaderValidator();

    [Theory]
    [InlineData("DENY")]
    [InlineData("SAMEORIGIN")]
    public void Validate_GivenValidValue_ShouldReturnValidResult(string value)
    {
        // act
        var result = Validator.Validate(value, out var options);

        // assert
        result.IsValid.Should().BeTrue();
        options.Should().NotBeNull();
    }

    [Theory]
    [InlineData("")]
    [InlineData("test")]
    [InlineData(null)]
    public void Validate_GivenInvalidValue_ShouldReturnInvalidResult(string? value)
    {
        // act
        var result = Validator.Validate(value, out var options);

        // assert
        result.IsValid.Should().BeFalse();
    }

    [Fact]
    public void Validate_GivenAllowFrom_ShouldReturnInvalidResult()
    {
        // act
        var result = Validator.Validate("ALLOW-FROM https://example.com", out var options);

        // assert
        result.IsValid.Should().BeFalse();
    }

    [Fact]
    public void Validate_FromOptions_ShouldReturnValidResult()
    {
        // act
        var result = Validator.Validate(new XFrameOptionsHeaderOptions());

        // assert
        result.IsValid.Should().BeTrue();
    }
}