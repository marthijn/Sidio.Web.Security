using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Sidio.Web.Security.AspNetCore.Middleware;
using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Headers.Validation;

namespace Sidio.Web.Security.AspNetCore;

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
        Action<IServiceProvider, ContentSecurityPolicyHeaderOptionsBuilder> options)
    {
        app.UseMiddleware<ContentSecurityPolicyMiddleware>(options);
        return app;
    }

    /// <summary>
    /// Apply a secure cookie policy.
    /// </summary>
    /// <param name="applicationBuilder">The application builder.</param>
    /// <param name="secured">When true the cookies require HTTPS.</param>
    /// <param name="httpOnly">When true the cookies cannot be read by JavaScript.</param>
    /// <param name="strictSameSite">When true the same site policy is set to <see cref="SameSiteMode.Strict"/>,
    /// otherwise <see cref="SameSiteMode.Lax"/>.</param>
    /// <returns>The <see cref="IApplicationBuilder"/>.</returns>
    public static IApplicationBuilder ApplySecureCookiePolicy(
        IApplicationBuilder applicationBuilder,
        bool secured = true,
        bool httpOnly = true,
        bool strictSameSite = true)
    {
        return applicationBuilder.UseCookiePolicy(
            new CookiePolicyOptions
            {
                Secure = secured ? CookieSecurePolicy.Always : CookieSecurePolicy.SameAsRequest,
                HttpOnly = httpOnly ? HttpOnlyPolicy.Always : HttpOnlyPolicy.None,
                MinimumSameSitePolicy = strictSameSite ? SameSiteMode.Strict : SameSiteMode.Lax,
            });
    }
}