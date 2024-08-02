using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Sidio.Http.Security.AspNetCore.Middleware;

namespace Sidio.Http.Security.AspNetCore;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseXFrameOptions(this IApplicationBuilder app, XFrameOptionsHeaderOptions? options = null)
    {
        var optionsValue = options ?? new XFrameOptionsHeaderOptions();
        app.UseMiddleware<XFrameOptionsMiddleware>(Options.Create(optionsValue));
        return app;
    }
}