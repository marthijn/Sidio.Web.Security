using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Headers.Validation;

namespace Sidio.Web.Security.Tests.Headers.Validation;

public sealed class ReportToHeaderValidationTests : HeaderValidatorTests<ReportToHeaderOptions>
{
    protected override IHeaderValidator<ReportToHeaderOptions> Validator => new ReportToHeaderValidation();

    [Theory]
    [InlineData("{}")]
    public void Validate_GivenInvalidValue_ReturnsInvalidResult(string? value)
    {
        // act
        var result = Validator.Validate(value, out var options);

        // assert
        result.IsValid.Should().BeFalse();
        options.Should().BeNull();
    }

    [Fact]
    public void Validate_GivenValidValue_ShouldReturnValidResult()
    {
        // act
        const string Json =
            "{ \"group\": \"csp-endpoint\",\n              \"max_age\": 10886400,\n              \"endpoints\": [\n                { \"url\": \"https://example.com/csp-reports\" }\n              ] },\n            { \"group\": \"hpkp-endpoint\",\n              \"max_age\": 10886400,\n              \"endpoints\": [\n                { \"url\": \"https://example.com/hpkp-reports\" }\n              ] }";
        var result = Validator.Validate(Json, out var options);

        // assert
        result.IsValid.Should().BeTrue();
        options.Should().NotBeNull();

        options!.Groups.Should().HaveCount(2);

        var cspGroup = options.Groups.Single(x => x.Group == "csp-endpoint");
        cspGroup.Endpoints.Should().HaveCount(1);
        cspGroup.Endpoints.Single().Url.Should().Be("https://example.com/csp-reports");
        cspGroup.MaxAge.Should().Be(10886400);
    }
}