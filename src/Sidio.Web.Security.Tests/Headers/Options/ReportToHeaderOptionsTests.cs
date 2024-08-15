using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.Tests.Headers.Options;

public sealed class ReportToHeaderOptionsTests
{
    private readonly Fixture _fixture = new();

    [Fact]
    public void ToString_ShouldReturnCorrectString()
    {
        // arrange
        var groups = _fixture.CreateMany<ReportGroup>().ToList();
        var reportToHeaderOptions = new ReportToHeaderOptions
        {
            Groups = groups
        };

        // act
        var result = reportToHeaderOptions.ToString();

        // assert
        result.Should().NotBeNullOrWhiteSpace();
        result.Should().NotStartWith("[");
        result.Should().NotEndWith("]");
    }
}