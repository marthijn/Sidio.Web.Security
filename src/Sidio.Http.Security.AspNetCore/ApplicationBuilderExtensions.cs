using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Sidio.Http.Security.AspNetCore.Middleware;
using Sidio.Http.Security.Headers.Options;
using Sidio.Http.Security.Headers.Validation;

namespace Sidio.Http.Security.AspNetCore;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseHeaderValidation(this IApplicationBuilder app, HeaderValidationOptions? options = null)
    {
        var optionsValue = options ?? new HeaderValidationOptions();
        app.UseMiddleware<HeaderValidationMiddleware>(Options.Create(optionsValue));
        return app;
    }

    public static IApplicationBuilder UseXFrameOptions(this IApplicationBuilder app, XFrameOptionsHeaderOptions? options = null)
    {
        var optionsValue = options ?? new XFrameOptionsHeaderOptions();
        app.UseMiddleware<XFrameOptionsMiddleware>(Options.Create(optionsValue));
        return app;
    }

    public static IApplicationBuilder UseXContentTypeOptions(this IApplicationBuilder app)
    {
        app.UseMiddleware<XContentTypeOptionsMiddleware>();
        return app;
    }

    public static IApplicationBuilder UseStrictTransportSecurity(this IApplicationBuilder app, StrictTransportSecurityHeaderOptions? options = null)
    {
        var optionsValue = options ?? new StrictTransportSecurityHeaderOptions();
        app.UseMiddleware<StrictTransportSecurityMiddleware>(Options.Create(optionsValue));
        return app;
    }

    public static IApplicationBuilder UseContentSecurityPolicy(this IApplicationBuilder app, ContentSecurityPolicyHeaderOptions? options = null)
    {
        var optionsValue = options ?? new ContentSecurityPolicyHeaderOptions();
        app.UseMiddleware<ContentSecurityPolicyMiddleware>(Options.Create(optionsValue));
        return app;
    }

    public static IApplicationBuilder UseContentSecurityPolicy(
        this IApplicationBuilder app,
        Action<ContentSecurityPolicyHeaderOptionsBuilder> options)
    {
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();
        options(builder);
        var optionsValue = builder.Build();
        app.UseMiddleware<ContentSecurityPolicyMiddleware>(Options.Create(optionsValue));
        return app;
    }
}