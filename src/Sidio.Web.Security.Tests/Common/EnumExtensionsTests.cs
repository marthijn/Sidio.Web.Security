using Sidio.Web.Security.Common;
using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Headers.Options.ContentSecurityPolicy;

namespace Sidio.Web.Security.Tests.Common;

public sealed class EnumExtensionsTests
{
    [Theory]
    [ClassData(typeof(SandboxDataGenerator))]
    public void ToStringValue_Sandbox_ReturnsString(Sandbox sandbox, string expected)
    {
        // act
        var result = sandbox.ToStringValue();

        // assert
        result.Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(ReferrerPolicyDataGenerator))]
    public void ToStringValue_ReferrerPolicy_ReturnsString(ReferrerPolicy policy, string expected)
    {
        // act
        var result = policy.ToStringValue();

        // assert
        result.Should().Be(expected);
    }
}