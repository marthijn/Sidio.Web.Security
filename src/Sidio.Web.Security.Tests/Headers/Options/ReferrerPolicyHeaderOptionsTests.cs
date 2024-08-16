using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.Tests.Headers.Options;

public sealed class ReferrerPolicyHeaderOptionsTests
{
    [Fact]
    public void ToString_ReferrerPolicyHeaderOptions_ReturnsString()
    {
        // arrange
        var options = new ReferrerPolicyHeaderOptions
        {
            Policy = ReferrerPolicy.Origin,
        };

        // act
        var result = options.ToString();

        // assert
        result.Should().Be("origin");
        result.Should().BeEquivalentTo(options.Value);
    }
}