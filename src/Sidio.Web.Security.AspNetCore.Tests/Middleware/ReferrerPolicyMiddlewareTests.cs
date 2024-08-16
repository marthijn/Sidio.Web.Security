using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Sidio.Web.Security.AspNetCore.Middleware;
using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.AspNetCore.Tests.Middleware;

public sealed class ReferrerPolicyMiddlewareTests
{
    [Fact]
    public async Task InvokeAsync_WithDefaultOptions_ShouldSetReferrerPolicyHeader()
    {
        // arrange
        var middleware = new ReferrerPolicyMiddleware(
            _ => Task.CompletedTask,
            Options.Create(new ReferrerPolicyHeaderOptions
            {
                Policy = ReferrerPolicy.NoReferrer,
            }),
            NullLogger<ReferrerPolicyMiddleware>.Instance);

        var context = new DefaultHttpContext();

        // act
        await middleware.InvokeAsync(context);

        // assert
        context.Response.Headers.Should().ContainKey("Referrer-Policy");
    }
}