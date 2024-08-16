using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Sidio.Web.Security.AspNetCore.Middleware;
using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.AspNetCore.Tests.Middleware;

public sealed class XXssProtectionMiddlewareTests
{
    [Fact]
    public async Task InvokeAsync_WithDefaultOptions_ShouldSetXFrameOptionsHeader()
    {
        // arrange
        var middleware = new XXssProtectionMiddleware(
            _ => Task.CompletedTask,
            Options.Create(new XXssProtectionHeaderOptions()),
            NullLogger<XXssProtectionMiddleware>.Instance);

        var context = new DefaultHttpContext();

        // act
        await middleware.InvokeAsync(context);

        // assert
        context.Response.Headers.Should().ContainKey("X-XSS-Protection");
    }
}