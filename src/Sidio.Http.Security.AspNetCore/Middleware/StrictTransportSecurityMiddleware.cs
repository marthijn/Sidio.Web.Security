using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sidio.Http.Security.Headers;
using Sidio.Http.Security.Headers.Options;

namespace Sidio.Http.Security.AspNetCore.Middleware;

internal sealed class StrictTransportSecurityMiddleware : HttpHeaderMiddleware
{
    public StrictTransportSecurityMiddleware(
        RequestDelegate next,
        IOptions<StrictTransportSecurityHeaderOptions> options,
        ILogger<StrictTransportSecurityMiddleware> logger) : base(
        next,
        HttpHeaderFactory.Create<StrictTransportSecurityHeader>(options.Value.ToString()),
        logger)
    {
    }
}