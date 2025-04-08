using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Sidio.Web.Security.AspNetCore.Middleware;
using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.AspNetCore.Tests.Middleware;

public sealed class PermissionsPolicyMiddlewareTests
{
    [Fact]
    public async Task InvokeAsync_WithDefaultOptionsWithValue_ShouldSetPermissionsPolicyHeader()
    {
        // arrange
        var middleware = new PermissionsPolicyMiddleware(
            _ => Task.CompletedTask,
            Options.Create(new PermissionsPolicyHeaderOptions
            {
                Accelerometer = "()"
            }),
            NullLogger<PermissionsPolicyMiddleware>.Instance);

        var context = new DefaultHttpContext();

        // act
        await middleware.InvokeAsync(context);

        // assert
        context.Response.Headers.Should().ContainKey("Permissions-Policy");
    }

    [Fact]
    public async Task InvokeAsync_WithDefaultOptionsWithoutValue_ShouldNotSetPermissionsPolicyHeader()
    {
        // arrange
        var middleware = new PermissionsPolicyMiddleware(
            _ => Task.CompletedTask,
            Options.Create(new PermissionsPolicyHeaderOptions()),
            NullLogger<PermissionsPolicyMiddleware>.Instance);

        var context = new DefaultHttpContext();

        // act
        await middleware.InvokeAsync(context);

        // assert
        context.Response.Headers.Should().NotContainKey("Permissions-Policy");
    }
}