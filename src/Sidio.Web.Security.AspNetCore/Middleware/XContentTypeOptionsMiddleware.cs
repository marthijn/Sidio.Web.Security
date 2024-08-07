using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Sidio.Web.Security.Headers;

namespace Sidio.Web.Security.AspNetCore.Middleware;

internal sealed class XContentTypeOptionsMiddleware : HttpHeaderMiddleware
{
    public XContentTypeOptionsMiddleware(RequestDelegate next, ILogger<XContentTypeOptionsMiddleware> logger) : base(
        next,
        HttpHeaderFactory.Create<XContentTypeOptionsHeader>(XContentTypeOptionsHeader.DefaultValue),
        logger)
    {
    }
}