using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Sidio.Web.Security.AspNetCore.Middleware;
using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.AspNetCore.Tests.Middleware;

public sealed class CrossOriginResourcePolicyHeaderMiddlewareTests
{
    [Fact]
    public async Task InvokeAsync_WithDefaultOptions_ShouldSetCrossOriginResourcePolicyHeader()
    {
        // arrange
        var middleware = new CrossOriginResourcePolicyHeaderMiddleware(
            _ => Task.CompletedTask,
            Options.Create(new CrossOriginResourcePolicyHeaderOptions()
            {
                Policy = CrossOriginResourcePolicy.CrossOrigin,
            }),
            NullLogger<CrossOriginResourcePolicyHeaderMiddleware>.Instance);

        var context = new DefaultHttpContext();

        // act
        await middleware.InvokeAsync(context);

        // assert
        context.Response.Headers.Should().ContainKey("Cross-Origin-Resource-Policy");
    }
}