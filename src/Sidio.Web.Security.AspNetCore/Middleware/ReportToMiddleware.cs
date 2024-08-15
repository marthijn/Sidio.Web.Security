using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sidio.Web.Security.Headers;
using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.AspNetCore.Middleware;

internal sealed class ReportToMiddleware : HttpHeaderMiddleware
{
    public ReportToMiddleware(
        RequestDelegate next,
        IOptions<ReportToHeaderOptions> options,
        ILogger<ReportToMiddleware> logger) : base(
        next,
        HttpHeaderFactory.Create<ReportToHeader>(options.Value.ToString()),
        logger)
    {
    }
}