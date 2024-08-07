using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sidio.Web.Security.Headers;
using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.AspNetCore.Middleware;

internal sealed class ContentSecurityPolicyMiddleware : HttpHeaderMiddleware
{
    public ContentSecurityPolicyMiddleware(
        RequestDelegate next,
        IOptions<ContentSecurityPolicyHeaderOptions> options,
        ILogger<ContentSecurityPolicyMiddleware> logger) : base(
        next,
        HttpHeaderFactory.Create<ContentSecurityPolicyHeader>(options.Value.ToString()),
        logger)
    {
    }
}