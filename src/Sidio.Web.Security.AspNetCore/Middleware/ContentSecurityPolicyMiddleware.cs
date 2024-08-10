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
            _logger.LogWarning("The header `{HeaderName}` is already set", ContentSecurityPolicyHeader.HeaderName);
            return _next(context);
        }

        // since the CSP header contains dynamic content (e.g. a nonce), we need to build it on each request
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();
        _optionsBuilder(context.RequestServices, builder);
        var header = new ContentSecurityPolicyHeader(builder.Build().ToString());
        context.Response.Headers.Append(header.Name, header.Value);

        return _next(context);
    }
}