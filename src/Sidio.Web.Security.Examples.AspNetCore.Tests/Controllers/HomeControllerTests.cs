using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Testing.Headers;

namespace Sidio.Web.Security.Examples.AspNetCore.Tests.Controllers;

public sealed class HomeControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public HomeControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Index_ReturnsView()
    {
        // arrange
        var client = _factory.CreateClient();

        // act
        var response = await client.GetAsync("/");

        // assert
        response.IsSuccessStatusCode.Should().BeTrue();

        response.Headers.ShouldHaveXFrameOptionsHeader().WithNonEmptyValue();
        response.Headers.ShouldHaveXFrameOptionsHeader().WithValue("DENY");

        response.Headers.ShouldHaveXContentTypeOptionsHeader().WithValue("nosniff");

        response.Headers.ShouldHaveStrictTransportSecurityHeader()
            .HasValidOptions().WithMaxAge(0).WithIncludeSubDomains(true).WithPreload(false);

        response.Headers.ShouldNotHaveXXssProtectionHeader();

        response.Headers.ShouldHaveContentSecurityPolicyHeader().ContainsValue("nonce");

        response.Headers.ShouldHaveReportToHeader();

        response.Headers.ShouldHaveReferrerPolicyHeader().HasValidOptions().ContainsPolicy(ReferrerPolicy.NoReferrer);

        var content = await response.Content.ReadAsStringAsync();
        content.Should().Contain("Home");
    }
}