using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sidio.Web.Security.Headers;
using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.AspNetCore.Middleware;

internal sealed class PermissionsPolicyMiddleware : HttpHeaderMiddleware
{
    public PermissionsPolicyMiddleware(
        RequestDelegate next,
        IOptions<PermissionsPolicyHeaderOptions> options,
        ILogger<PermissionsPolicyMiddleware> logger) : base(
            next,
            HttpHeaderFactory.Create<PermissionsPolicyHeader>(options.Value.ToString()),
            logger)
    {
    }
}