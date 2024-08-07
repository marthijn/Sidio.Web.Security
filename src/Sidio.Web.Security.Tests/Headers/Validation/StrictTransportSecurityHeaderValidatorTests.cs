using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Headers.Validation;

namespace Sidio.Web.Security.Tests.Headers.Validation;

public sealed class StrictTransportSecurityHeaderValidatorTests : HeaderValidatorTests<StrictTransportSecurityHeaderOptions>
{
    protected override IHeaderValidator<StrictTransportSecurityHeaderOptions> Validator =>
        new StrictTransportSecurityHeaderValidator();

    [Theory]
    [InlineData("max-age=5",5, false, false)]
    [InlineData("max-age=31536000; includeSubDomains", 31536000, true, false)]
    [InlineData("max-age=31536000; includeSubDomains; preload", 31536000, true, true)]
    [InlineData("max-age=0", 0, false, false)]
    public void Validate_GivenValidValue_ShouldReturnValidResult(string value, long maxAge, bool includeSubDomains, bool preload)
    {
        // act
        var result = Validator.Validate(value, out var options);

        // assert
        result.IsValid.Should().BeTrue();
        options.Should().NotBeNull();
        options!.MaxAge.Should().Be(maxAge);
        options.IncludeSubDomains.Should().Be(includeSubDomains);
        options.Preload.Should().Be(preload);
    }

    [Fact]
    public void Validate_GivenMaxAgeIsZero_ShouldReturnWarning()
    {
        // act
        var result = Validator.Validate("max-age=0", out var options);

        // assert
        result.IsValid.Should().BeTrue();
        result.HasWarnings.Should().BeTrue();
        options.Should().NotBeNull();
    }

    [Theory]
    [InlineData("")]
    [InlineData("test")]
    [InlineData(null)]
    [InlineData("max-age=")]
    [InlineData("max-age=a")]
    [InlineData("max-age=-1")]
    [InlineData("max-age=31536000; includeSubDomain")]
    [InlineData("max-age=31536000; includeSubDomains; preloa")]
    [InlineData("max-age=31536000; preload")]
    [InlineData("max-age=31535999; includeSubDomains; preload")]
    public void Validate_GivenInvalidValue_ShouldReturnInvalidResult(string? value)
    {
        // act
        var result = Validator.Validate(value, out var options);

        // assert
        result.IsValid.Should().BeFalse();
        options.Should().BeNull();
    }

    [Theory]
    [InlineData(0, false, false)]
    [InlineData(1, false, false)]
    [InlineData(31536000, true, false)]
    [InlineData(31536000, true, true)]
    public void Validate_FromOptions_ShouldReturnValidResult(long maxAge, bool includeSubDomains, bool preload)
    {
        // arrange
        var options = new StrictTransportSecurityHeaderOptions
        {
            MaxAge = maxAge,
            IncludeSubDomains = includeSubDomains,
            Preload = preload,
        };

        // act
        var result = Validator.Validate(options);

        // assert
        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData(31535999, true, true)]
    [InlineData(-1, false, false)]
    public void Validate_FromOptions_ShouldReturnInvalidResult(long maxAge, bool includeSubDomains, bool preload)
    {
        // arrange
        var options = new StrictTransportSecurityHeaderOptions
        {
            MaxAge = maxAge,
            IncludeSubDomains = includeSubDomains,
            Preload = preload,
        };

        // act
        var result = Validator.Validate(options);

        // assert
        result.IsValid.Should().BeFalse();
    }
}