using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sidio.Web.Security.Headers.Validation;

namespace Sidio.Web.Security.AspNetCore.Middleware;

internal sealed class HeaderValidationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly HeaderValidationService _headerValidationService;

    public HeaderValidationMiddleware(RequestDelegate next, IOptions<HeaderValidationOptions> options, ILoggerFactory loggerFactory)
    {
        _next = next;
        _headerValidationService = new HeaderValidationService(options, loggerFactory.CreateLogger<HeaderValidationService>());
    }

    public Task InvokeAsync(HttpContext context)
    {
        var headerDictionary = context.Response.Headers.ToDictionary(x => x.Key, x => x.Value.AsEnumerable());
        _headerValidationService.Validate(headerDictionary);
        return _next(context);
    }
}