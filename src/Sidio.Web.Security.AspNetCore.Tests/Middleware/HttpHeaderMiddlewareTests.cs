using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Sidio.Web.Security.AspNetCore.Middleware;
using Sidio.Web.Security.Headers;
using Sidio.Web.Security.Headers.Validation;

namespace Sidio.Web.Security.AspNetCore.Tests.Middleware;

public sealed class HttpHeaderMiddlewareTests
{
    [Fact]
    public async Task InvokeAsync_HeaderAlreadySetWithEqualValue_ShouldNotLogWarning()
    {
        // arrange
        var header = new CustomHttpHeader("test");
        var logger = new Mock<ILogger<CustomMiddleware>>();

        var middleware = new CustomMiddleware(
            _ => Task.CompletedTask,
            header,
            logger.Object);

        var context = new DefaultHttpContext();
        context.Response.Headers.Append(header.Name, header.Value);

        // act
        await middleware.InvokeAsync(context);

        // assert
        logger.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task InvokeAsync_HeaderAlreadySetWithDifferentValue_ShouldLogWarning()
    {
        // arrange
        var header = new CustomHttpHeader("test");
        var logger = new Mock<ILogger<CustomMiddleware>>();

        var middleware = new CustomMiddleware(
            _ => Task.CompletedTask,
            header,
            logger.Object);

        var context = new DefaultHttpContext();
        context.Response.Headers.Append(header.Name, "different");

        // act
        await middleware.InvokeAsync(context);

        // assert
        logger.Verify(
            x => x.Log(
                It.Is<LogLevel>(y => y == LogLevel.Warning),
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()));
    }


    internal sealed class CustomMiddleware : HttpHeaderMiddleware
    {
        public CustomMiddleware(RequestDelegate next, ILogger<CustomMiddleware> logger) : base(next, logger)
        {
        }

        public CustomMiddleware(RequestDelegate next, HttpHeader header, ILogger<CustomMiddleware> logger) : base(next, header, logger)
        {
        }
    }

    private sealed class CustomHttpHeader : HttpHeader
    {
        public CustomHttpHeader(string? value) : base(value)
        {
        }

        public override string Name => "X-Test";

        public override HeaderValidationResult Validate()
        {
            return new HeaderValidationResult(Array.Empty<HeaderValidation>());
        }
    }
}