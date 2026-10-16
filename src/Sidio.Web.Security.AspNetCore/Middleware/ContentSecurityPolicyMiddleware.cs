using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Sidio.Web.Security.Headers;
using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.AspNetCore.Middleware;

internal sealed class ContentSecurityPolicyMiddleware
{
    private readonly RequestDelegate _next;
    private readonly Action<IServiceProvider, ContentSecurityPolicyHeaderOptionsBuilder> _optionsBuilder;
    private readonly ILogger<ContentSecurityPolicyMiddleware> _logger;

    public ContentSecurityPolicyMiddleware(
        RequestDelegate next,
        Action<IServiceProvider, ContentSecurityPolicyHeaderOptionsBuilder> optionsBuilder,
        ILogger<ContentSecurityPolicyMiddleware> logger)
    {
        _next = next;
        _optionsBuilder = optionsBuilder;
        _logger = logger;
    }

    public Task InvokeAsync(HttpContext context)
    {
        if (context.Response.HeaderExists(ContentSecurityPolicyHeader.HeaderName))
        {
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug("The header `{HeaderName}` is already set", ContentSecurityPolicyHeader.HeaderName);
            }

            var expectedHeader = GetHeaderValue(context);
            var actualValue = context.Response.Headers[ContentSecurityPolicyHeader.HeaderName].ToString();
            if (!string.Equals(expectedHeader.Value, actualValue, StringComparison.OrdinalIgnoreCase))
            {
                _logger.LogWarning(
                    "The header `{HeaderName}` is already set with a different value. Expected: `{ExpectedValue}`, Actual: `{ActualValue}`",
                    ContentSecurityPolicyHeader.HeaderName,
                    expectedHeader.Value,
                    actualValue);
            }

            return _next(context);
        }

        // since the CSP header contains dynamic content (e.g. a nonce), we need to build it on each request
        var header = GetHeaderValue(context);
        if (!string.IsNullOrWhiteSpace(header.Value))
        {
            context.Response.Headers.Append(header.Name, header.Value);
        }

        return _next(context);
    }

    private ContentSecurityPolicyHeader GetHeaderValue(HttpContext context)
    {
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();
        _optionsBuilder(context.RequestServices, builder);
        var header = new ContentSecurityPolicyHeader(builder.Build().ToString());
        return header;
    }
}