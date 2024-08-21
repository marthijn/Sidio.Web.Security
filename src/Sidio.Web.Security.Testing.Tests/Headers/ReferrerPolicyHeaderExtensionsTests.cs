using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Testing.Headers;
using Sidio.Web.Security.Testing.Headers.Exceptions;

namespace Sidio.Web.Security.Testing.Tests.Headers;

public sealed class ReferrerPolicyHeaderExtensionsTests
{
    [Fact]
    public void ContainsPolicy_WhenHeaderHasExpectedPolicy_ShouldNotThrowException()
    {
        // arrange
        var header = new ReferrerPolicyHeaderOptions
        {
            Policies = [ReferrerPolicy.StrictOrigin, ReferrerPolicy.UnsafeUrl]
        };

        // act
        var action = () => header.ContainsPolicy(ReferrerPolicy.StrictOrigin);

        // assert
        action.Should().NotThrow();
        action().Should().BeSameAs(header);
    }

    [Fact]
    public void ContainsPolicy_WhenHeaderHasDifferentPolicy_ShouldThrowException()
    {
        // arrange
        var header = new ReferrerPolicyHeaderOptions
        {
            Policies = [ReferrerPolicy.StrictOrigin, ReferrerPolicy.UnsafeUrl]
        };

        // act
        var action = () => header.ContainsPolicy(ReferrerPolicy.NoReferrer);

        // assert
        action.Should().ThrowExactly<DirectiveShouldHaveValueException>();
    }
}