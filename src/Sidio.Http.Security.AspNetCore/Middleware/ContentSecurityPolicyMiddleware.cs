using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sidio.Http.Security.Headers;
using Sidio.Http.Security.Headers.Options;

namespace Sidio.Http.Security.AspNetCore.Middleware;

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