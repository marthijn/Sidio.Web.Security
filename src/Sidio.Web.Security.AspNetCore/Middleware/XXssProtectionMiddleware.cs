using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sidio.Web.Security.Headers;
using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.AspNetCore.Middleware;

internal sealed class XXssProtectionMiddleware : HttpHeaderMiddleware
{
    public XXssProtectionMiddleware(
        RequestDelegate next,
        IOptions<XXssProtectionHeaderOptions> options,
        ILogger<XXssProtectionMiddleware> logger) : base(
        next,
        HttpHeaderFactory.Create<XXssProtectionHeader>(options.Value.ToString()),
        logger)
    {
    }
}