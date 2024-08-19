using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Sidio.Web.Security.Headers;

namespace Sidio.Web.Security.AspNetCore.Middleware;

internal abstract class HttpHeaderMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<HttpHeaderMiddleware> _logger;

    protected HttpHeaderMiddleware(RequestDelegate next, ILogger<HttpHeaderMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    protected HttpHeaderMiddleware(RequestDelegate next, HttpHeader header, ILogger<HttpHeaderMiddleware> logger)
    {
        _next = next;
        Header = header;
        _logger = logger;
    }

    protected virtual HttpHeader? Header { get; }

    public Task InvokeAsync(HttpContext context)
    {
        if (Header == null)
        {
            throw new InvalidOperationException("The header is not set.");
        }

        if (ShouldAppendHeader(context))
        {
            if (!context.Response.AppendHeaderIfNotExists(Header))
            {
                _logger.LogWarning("The header `{HeaderName}` is already set", Header.Name);
            }
        }
        else
        {
            _logger.LogDebug("The header `{HeaderName}` is not appended due to specific conditions", Header.Name);
        }

        return _next(context);
    }

    protected virtual bool ShouldAppendHeader(HttpContext context)
    {
        return true;
    }
}