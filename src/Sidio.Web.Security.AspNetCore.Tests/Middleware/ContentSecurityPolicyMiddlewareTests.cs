using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging.Abstractions;
using Sidio.Web.Security.AspNetCore.Middleware;
using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.AspNetCore.Tests.Middleware;

public sealed class ContentSecurityPolicyMiddlewareTests
{
    [Fact]
    public async Task InvokeAsync_WithOptionsBuilder_ShouldSetContentSecurityPolicyHeader()
    {
        // arrange
        void OptionsBuilder(IServiceProvider serviceProvider, ContentSecurityPolicyHeaderOptionsBuilder b)
        {
            b.AddDefaultSrc(x => x.AllowAll());
        }

        var middleware = new ContentSecurityPolicyMiddleware(
            _ => Task.CompletedTask,
            OptionsBuilder,
            NullLogger<ContentSecurityPolicyMiddleware>.Instance);

        var context = new DefaultHttpContext();

        // act
        await middleware.InvokeAsync(context);

        // assert
        context.Response.Headers.Should().ContainKey("Content-Security-Policy");
    }
}