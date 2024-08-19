using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Sidio.Web.Security.AspNetCore.Middleware;
using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.AspNetCore.Tests.Middleware;

public sealed class StrictTransportSecurityMiddlewareTests
{
    private readonly Fixture _fixture = new();

    [Fact]
    public async Task InvokeAsync_WithDefaultOptions_ShouldSetStrictTransportSecurityHeader()
    {
        // arrange
        var middleware = new StrictTransportSecurityMiddleware(
            _ => Task.CompletedTask,
            Options.Create(new StrictTransportSecurityHeaderOptions { DisableForLocalhostRequests = true }),
            NullLogger<StrictTransportSecurityMiddleware>.Instance);

        var context = new DefaultHttpContext
        {
            Request =
            {
                Host = new HostString(_fixture.Create<string>())
            }
        };

        // act
        await middleware.InvokeAsync(context);

        // assert
        context.Response.Headers.Should().ContainKey("Strict-Transport-Security");
    }

    [Theory]
    [InlineData("localhost")]
    [InlineData("LoCalHoSt")]
    [InlineData("127.0.0.1")]
    [InlineData("::1")]

    public async Task InvokeAsync_WithDisabledForLocalhostRequests_ShouldNotSetStrictTransportSecurityHeader(string host)
    {
        // arrange
        var middleware = new StrictTransportSecurityMiddleware(
            _ => Task.CompletedTask,
            Options.Create(new StrictTransportSecurityHeaderOptions { DisableForLocalhostRequests = true }),
            NullLogger<StrictTransportSecurityMiddleware>.Instance);

        var context = new DefaultHttpContext
        {
            Request =
            {
                Host = new HostString(host)
            }
        };

        // act
        await middleware.InvokeAsync(context);

        // assert
        context.Response.Headers.Should().BeEmpty();
    }

    [Theory]
    [InlineData("localhost")]
    [InlineData("LoCalHoSt")]
    [InlineData("127.0.0.1")]
    [InlineData("::1")]

    public async Task InvokeAsync_WithEnabledForLocalhostRequests_ShouldSetStrictTransportSecurityHeader(string host)
    {
        // arrange
        var middleware = new StrictTransportSecurityMiddleware(
            _ => Task.CompletedTask,
            Options.Create(new StrictTransportSecurityHeaderOptions { DisableForLocalhostRequests = false }),
            NullLogger<StrictTransportSecurityMiddleware>.Instance);

        var context = new DefaultHttpContext
        {
            Request =
            {
                Host = new HostString(host)
            }
        };

        // act
        await middleware.InvokeAsync(context);

        // assert
        context.Response.Headers.Should().ContainKey("Strict-Transport-Security");
    }
}