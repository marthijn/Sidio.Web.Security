using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.Tests.Headers.Options;

public sealed class CrossOriginResourcePolicyHeaderOptionsTests
{
    [Theory]
    [InlineData(CrossOriginResourcePolicy.SameSite, "same-site")]
    [InlineData(CrossOriginResourcePolicy.CrossOrigin, "cross-origin")]
    [InlineData(CrossOriginResourcePolicy.SameOrigin, "same-origin")]
    public void ToString_CrossOriginResourcePolicyHeaderOptions_ReturnsString(CrossOriginResourcePolicy policy, string expectedValue)
    {
        // arrange
        var options = new CrossOriginResourcePolicyHeaderOptions
        {
            Policy = policy,
        };

        // act
        var result = options.ToString();

        // assert
        result.Should().Be(expectedValue);
        result.Should().BeEquivalentTo(options.Value);
    }
}