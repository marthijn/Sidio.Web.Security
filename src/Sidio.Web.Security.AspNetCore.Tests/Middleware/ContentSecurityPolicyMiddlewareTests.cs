using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
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

    [Fact]
    public async Task InvokeAsync_HeaderAlreadySetWithDifferentValue_ShouldLogWarning()
    {
        // arrange
        var logger = new Mock<ILogger<ContentSecurityPolicyMiddleware>>();
        var middleware = new ContentSecurityPolicyMiddleware(
            _ => Task.CompletedTask,
            OptionsBuilder,
            logger.Object);

        var context = new DefaultHttpContext();
        context.Response.Headers.Append("Content-Security-Policy", "default-src 'self'");

        // act
        await middleware.InvokeAsync(context);

        // assert
        /*logger.Messages.Should().Contain(x =>
            x.LogLevel == LogLevel.Warning &&
            x.Message.Contains("Expected: `default-src *`", StringComparison.Ordinal) &&
            x.Message.Contains("Actual: `default-src 'self'`", StringComparison.Ordinal));*/

        logger.Verify(
            x => x.Log(
                It.Is<LogLevel>(y => y == LogLevel.Warning),
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((state, _) =>
                    state != null &&
                    (state.ToString() ?? string.Empty).Contains("Expected: `default-src *`", StringComparison.Ordinal) &&
                    (state.ToString() ?? string.Empty).Contains("Actual: `default-src 'self'`", StringComparison.Ordinal)),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()));

        return;

        void OptionsBuilder(IServiceProvider serviceProvider, ContentSecurityPolicyHeaderOptionsBuilder b)
        {
            b.AddDefaultSrc(x => x.AllowAll());
        }
    }
}