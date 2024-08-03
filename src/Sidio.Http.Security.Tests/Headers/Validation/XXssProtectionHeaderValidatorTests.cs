using Sidio.Http.Security.Headers.Options;
using Sidio.Http.Security.Headers.Validation;

namespace Sidio.Http.Security.Tests.Headers.Validation;

public sealed class XXssProtectionHeaderValidatorTests : HeaderValidatorTests<XXssProtectionHeaderOptions>
{
    protected override IHeaderValidator<XXssProtectionHeaderOptions> Validator => new XXssProtectionHeaderValidator();

    [Theory]
    [InlineData("0",  false,false, null)]
    [InlineData("1",  true,false, null)]
    [InlineData("1; mode=block",  true,true, null)]
    [InlineData("1; report=<reporting-uri>",  true,false, "<reporting-uri>")]
    public void Validate_GivenValidValue_ShouldReturnValidResult(string value, bool enabled, bool block, string? reportUri)
    {
        // act
        var result = Validator.Validate(value, out var options);

        // assert
        result.IsValid.Should().BeTrue();
        options.Should().NotBeNull();
        options!.Enabled.Should().Be(enabled);
        options.Block.Should().Be(block);
        options.ReportUri.Should().Be(reportUri);
    }

    [Theory]
    [InlineData("-1")]
    [InlineData("2")]
    [InlineData("0; mode=block")]
    [InlineData("1; mode=")]
    [InlineData("1; mode=block; report=<reporting-uri>")]
    [InlineData("1; mode=block; report=<reporting-uri>; a=b")]
    [InlineData("1; report=")]
    public void Validate_GivenInvalidValue_ShouldReturnInvalidResult(string? value)
    {
        // act
        var result = Validator.Validate(value, out var options);

        // assert
        result.IsValid.Should().BeFalse();
        options.Should().BeNull();
    }

    [Theory]
    [InlineData(false, false, "")]
    [InlineData(true, false, null)]
    [InlineData(true, true, "")]
    [InlineData(true, false, "report-uri")]
    public void Validate_FromOptions_ShouldReturnValidResult(bool enabled, bool block, string? reportUri)
    {
        // arrange
        var options = new XXssProtectionHeaderOptions
        {
            Enabled = enabled,
            Block = block,
            ReportUri = reportUri
        };

        // act
        var result = Validator.Validate(options);

        // assert
        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData(false, true, "")]
    [InlineData(false, true, "report-uri")]
    [InlineData(false, false, "report-uri")]
    [InlineData(true, true, "report-uri")]
    public void Validate_FromOptions_ShouldReturnInvalidResult(bool enabled, bool block, string? reportUri)
    {
        // arrange
        var options = new XXssProtectionHeaderOptions
        {
            Enabled = enabled,
            Block = block,
            ReportUri = reportUri
        };

        // act
        var result = Validator.Validate(options);

        // assert
        result.IsValid.Should().BeFalse();
    }
}