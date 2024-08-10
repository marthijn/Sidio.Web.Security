using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging.Abstractions;
using Sidio.Web.Security.AspNetCore.Middleware;

namespace Sidio.Web.Security.AspNetCore.Tests.Middleware;

public sealed class XContentTypeOptionsMiddlewareTests
{
    [Fact]
    public async Task InvokeAsync_WithDefaultOptions_ShouldSetXContentTypeOptionsHeader()
    {
        // arrange
        var middleware = new XContentTypeOptionsMiddleware(
            _ => Task.CompletedTask,
            NullLogger<XContentTypeOptionsMiddleware>.Instance);

        var context = new DefaultHttpContext();

        // act
        await middleware.InvokeAsync(context);

        // assert
        context.Response.Headers.Should().ContainKey("X-Content-Type-Options");
    }
}