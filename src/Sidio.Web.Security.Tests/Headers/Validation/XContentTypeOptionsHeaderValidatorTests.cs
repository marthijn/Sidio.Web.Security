using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Headers.Validation;

namespace Sidio.Web.Security.Tests.Headers.Validation;

public sealed class XContentTypeOptionsHeaderValidatorTests : HeaderValidatorTests<XContentTypeOptionsHeaderOptions>
{
    protected override IHeaderValidator<XContentTypeOptionsHeaderOptions> Validator =>
        new XContentTypeOptionsHeaderValidator();

    [Fact]
    public void Validate_WithValidValue_ReturnsValid()
    {
        // arrange
        var value = "nosniff";

        // act
        var result = Validator.Validate(value, out var options);

        // assert
        result.IsValid.Should().BeTrue();
        options.Should().NotBeNull();
        options!.Value.Should().Be(value);
    }

    [Fact]
    public void Validate_WithInvalidValue_ReturnsInvalid()
    {
        // arrange
        var value = "invalid";

        // act
        var result = Validator.Validate(value, out var options);

        // assert
        result.IsValid.Should().BeFalse();
        options.Should().BeNull();
    }

    [Fact]
    public void Validate_FromOptions_ShouldReturnValidResult()
    {
        // act
        var result = Validator.Validate(new XContentTypeOptionsHeaderOptions());

        // assert
        result.IsValid.Should().BeTrue();
    }
}