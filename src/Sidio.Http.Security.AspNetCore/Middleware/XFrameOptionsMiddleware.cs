using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sidio.Http.Security.Headers;

namespace Sidio.Http.Security.AspNetCore.Middleware;

internal sealed class XFrameOptionsMiddleware : HttpHeaderMiddleware
{
    public XFrameOptionsMiddleware(
        RequestDelegate next,
        IOptions<XFrameOptionsHeaderOptions> options,
        ILogger<XFrameOptionsMiddleware> logger)
        : base(next, XFrameOptionsHeader.Create(options.Value.Value.ToString().ToUpperInvariant()), logger)
    {
    }
}