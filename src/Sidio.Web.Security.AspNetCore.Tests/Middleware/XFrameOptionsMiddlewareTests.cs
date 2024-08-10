using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Sidio.Web.Security.AspNetCore.Middleware;
using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.AspNetCore.Tests.Middleware;

public sealed class XFrameOptionsMiddlewareTests
{
    [Fact]
    public async Task InvokeAsync_WithDefaultOptions_ShouldSetXFrameOptionsHeader()
    {
        // arrange
        var middleware = new XFrameOptionsMiddleware(
            _ => Task.CompletedTask,
            Options.Create(new XFrameOptionsHeaderOptions()),
            NullLogger<XFrameOptionsMiddleware>.Instance);

        var context = new DefaultHttpContext();

        // act
        await middleware.InvokeAsync(context);

        // assert
        context.Response.Headers.Should().ContainKey("X-Frame-Options");
    }
}