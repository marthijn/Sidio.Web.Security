using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sidio.Web.Security.Headers;
using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.AspNetCore.Middleware;

internal sealed class XFrameOptionsMiddleware : HttpHeaderMiddleware
{
    public XFrameOptionsMiddleware(
        RequestDelegate next,
        IOptions<XFrameOptionsHeaderOptions> options,
        ILogger<XFrameOptionsMiddleware> logger)
        : base(
            next,
            HttpHeaderFactory.Create<XFrameOptionsHeader>(options.Value.ToString()),
            logger)
    {
    }
}