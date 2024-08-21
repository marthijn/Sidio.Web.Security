using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.Tests.Headers.Options;

public sealed class CrossOriginResourcePolicyHeaderOptionsTests
{
    [Fact]
    public void ToString_CrossOriginResourcePolicyHeaderOptions_ReturnsString()
    {
        // arrange
        var options = new CrossOriginResourcePolicyHeaderOptions
        {
            Policy = CrossOriginResourcePolicy.CrossOrigin,
        };

        // act
        var result = options.ToString();

        // assert
        result.Should().Be("cross-origin");
        result.Should().BeEquivalentTo(options.Value);
    }
}