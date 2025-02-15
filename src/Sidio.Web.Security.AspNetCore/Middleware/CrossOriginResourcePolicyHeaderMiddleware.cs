using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sidio.Web.Security.Headers;
using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.AspNetCore.Middleware;

internal sealed class CrossOriginResourcePolicyHeaderMiddleware : HttpHeaderMiddleware
{
    public CrossOriginResourcePolicyHeaderMiddleware(
        RequestDelegate next,
        IOptions<CrossOriginResourcePolicyHeaderOptions> options,
        ILogger<CrossOriginResourcePolicyHeaderMiddleware> logger) : base(
        next,
        HttpHeaderFactory.Create<CrossOriginResourcePolicyHeader>(options.Value.ToString()),
        logger)
    {
    }
}