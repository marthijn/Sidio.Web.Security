using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sidio.Web.Security.Headers;
using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.AspNetCore.Middleware;

internal sealed class ReferrerPolicyMiddleware : HttpHeaderMiddleware
{
    public ReferrerPolicyMiddleware(
        RequestDelegate next,
        IOptions<ReferrerPolicyHeaderOptions> options,
        ILogger<ReferrerPolicyMiddleware> logger)
        : base(
            next,
            HttpHeaderFactory.Create<ReferrerPolicyHeader>(options.Value.ToString()),
            logger)
    {
    }
}