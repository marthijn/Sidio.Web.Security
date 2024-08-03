using Sidio.Http.Security.Testing;

namespace Sidio.Http.Security.Examples.AspNetCore.Tests.Controllers;

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

        var content = await response.Content.ReadAsStringAsync();
        content.Should().Contain("Home");
    }
}