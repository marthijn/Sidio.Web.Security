using Sidio.Web.Security.AspNetCore.Html;

namespace Sidio.Web.Security.AspNetCore.Tests.Html;

public sealed class TagHelperOptionsTests
{
    [Fact]
    public void Construct_VerifyDefaultValues()
    {
        // act
        var result = new TagHelperOptions();

        // assert
        result.AutoApplyNonce.Should().BeFalse();
        result.AutoApplySubresourceIntegrity.Should().BeFalse();
    }
}