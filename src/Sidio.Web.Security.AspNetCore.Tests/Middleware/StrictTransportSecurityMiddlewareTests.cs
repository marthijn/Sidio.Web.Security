using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Sidio.Web.Security.AspNetCore.Middleware;
using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.AspNetCore.Tests.Middleware;

public sealed class StrictTransportSecurityMiddlewareTests
{
    [Fact]
    public async Task InvokeAsync_WithDefaultOptions_ShouldSetStrictTransportSecurityHeader()
    {
        // arrange
        var middleware = new StrictTransportSecurityMiddleware(
            _ => Task.CompletedTask,
            Options.Create(new StrictTransportSecurityHeaderOptions()),
            NullLogger<StrictTransportSecurityMiddleware>.Instance);

        var context = new DefaultHttpContext();

        // act
        await middleware.InvokeAsync(context);

        // assert
        context.Response.Headers.Should().ContainKey("Strict-Transport-Security");
    }
}