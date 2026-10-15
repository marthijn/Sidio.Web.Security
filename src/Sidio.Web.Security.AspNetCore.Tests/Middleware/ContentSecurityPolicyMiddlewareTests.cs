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
        var middleware = new ContentSecurityPolicyMiddleware(
            _ => Task.CompletedTask,
            OptionsBuilder,
            NullLogger<ContentSecurityPolicyMiddleware>.Instance);

        var context = new DefaultHttpContext();

        // act
        await middleware.InvokeAsync(context);

        // assert
        context.Response.Headers.Should().ContainKey("Content-Security-Policy");
        return;

        void OptionsBuilder(IServiceProvider serviceProvider, ContentSecurityPolicyHeaderOptionsBuilder b)
        {
            b.AddDefaultSrc(x => x.AllowAll());
        }
    }

    [Fact]
    public async Task InvokeAsync_WhenCalledTwiceOnTheSameRequest_ShouldOnlyAppendOnce()
    {
        // arrange
        var middleware = new ContentSecurityPolicyMiddleware(
            _ => Task.CompletedTask,
            OptionsBuilder,
            NullLogger<ContentSecurityPolicyMiddleware>.Instance);

        var context = new DefaultHttpContext();

        // act
        await middleware.InvokeAsync(context);
        var initialValue = context.Response.Headers["Content-Security-Policy"].ToString();
        await middleware.InvokeAsync(context);

        // assert
        context.Response.Headers["Content-Security-Policy"].ToString().Should().Be(initialValue);
        return;

        void OptionsBuilder(IServiceProvider serviceProvider, ContentSecurityPolicyHeaderOptionsBuilder b)
        {
            b.AddDefaultSrc(x => x.AllowAll());
        }
    }
}