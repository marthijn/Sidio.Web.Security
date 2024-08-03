using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sidio.Http.Security.Headers;
using Sidio.Http.Security.Headers.Options;

namespace Sidio.Http.Security.AspNetCore.Middleware;

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