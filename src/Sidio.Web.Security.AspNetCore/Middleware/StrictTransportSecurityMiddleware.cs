using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sidio.Web.Security.Headers;
using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.AspNetCore.Middleware;

internal sealed class StrictTransportSecurityMiddleware : HttpHeaderMiddleware
{
    /// <summary>
    /// The hosts that should be excluded from the HSTS header.
    /// </summary>
    private static readonly string[] ExcludedHosts = ["localhost", "127.0.0.1", "[::1]"];

    private readonly IOptions<StrictTransportSecurityHeaderOptions> _options;

    public StrictTransportSecurityMiddleware(
        RequestDelegate next,
        IOptions<StrictTransportSecurityHeaderOptions> options,
        ILogger<StrictTransportSecurityMiddleware> logger) : base(
        next,
        HttpHeaderFactory.Create<StrictTransportSecurityHeader>(options.Value.ToString()),
        logger)
    {
        _options = options;
    }

    protected override bool ShouldAppendHeader(HttpContext context)
    {
        if (!_options.Value.DisableForLocalhostRequests)
        {
            return true;
        }

        for (var i = ExcludedHosts.Length - 1; i >= 0 ; i--)
        {
            if (string.Equals(context.Request.Host.Host, ExcludedHosts[i], StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
        }

        return true;
    }
}