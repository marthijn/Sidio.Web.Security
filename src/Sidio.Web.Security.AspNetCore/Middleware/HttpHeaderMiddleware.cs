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

        if (!ShouldAppendHeader(context))
        {
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug("The header `{HeaderName}` is not appended due to specific conditions", Header.Name);
            }

            return _next(context);
        }

        return AppendHeaderAsync(context);
    }

    protected virtual bool ShouldAppendHeader(HttpContext context)
    {
        return true;
    }

    private Task AppendHeaderAsync(HttpContext context)
    {
        if (Header == null)
        {
            throw new InvalidOperationException("The header is not set.");
        }

        if (!context.Response.AppendHeaderIfNotExists(Header))
        {
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug("The header `{HeaderName}` is already set", Header.Name);
            }

            string? currentHeaderValue = context.Response.Headers[Header.Name];
            if (!(currentHeaderValue ?? string.Empty).Equals(Header.Value, StringComparison.OrdinalIgnoreCase))
            {
                _logger.LogWarning(
                    "The header `{HeaderName}` is already set with a different value. Expected: `{ExpectedValue}`, Actual: `{ActualValue}`",
                    Header.Name,
                    Header.Value,
                    currentHeaderValue);
            }
        }

        return _next(context);
    }
}