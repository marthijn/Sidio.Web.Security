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
            Policies = [ReferrerPolicy.Origin],
        };

        // act
        var result = options.ToString();

        // assert
        result.Should().Be("origin");
        result.Should().BeEquivalentTo(options.Value);
    }

    [Fact]
    public void ToString_ReferrerPolicyHeaderOptionsWithFallback_ReturnsString()
    {
        // arrange
        var options = new ReferrerPolicyHeaderOptions
        {
            Policies = [ReferrerPolicy.Origin, ReferrerPolicy.SameOrigin, ReferrerPolicy.StrictOriginWhenCrossOrigin],
        };

        // act
        var result = options.ToString();

        // assert
        result.Should().Be("origin, same-origin, strict-origin-when-cross-origin");
        result.Should().BeEquivalentTo(options.Value);
    }
}