using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Sidio.Web.Security.AspNetCore.Middleware;
using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.AspNetCore.Tests.Middleware;

public sealed class ReportToMiddlewareTests
{
    [Fact]
    public async Task InvokeAsync_WithDefaultOptions_ShouldSetReportToHeader()
    {
        // arrange
        var middleware = new ReportToMiddleware(
            _ => Task.CompletedTask,
            Options.Create(new ReportToHeaderOptions
            {
                Groups = [new ReportGroup("test", "https://example.com")]
            }),
            NullLogger<ReportToMiddleware>.Instance);

        var context = new DefaultHttpContext();

        // act
        await middleware.InvokeAsync(context);

        // assert
        context.Response.Headers.Should().ContainKey("Report-To");
    }
}