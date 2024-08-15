using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Sidio.Web.Security.AspNetCore.Middleware;
using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Headers.Validation;

namespace Sidio.Web.Security.AspNetCore;

/// <summary>
/// The application builder extensions.
/// </summary>
public static class ApplicationBuilderExtensions
{
    /// <summary>
    /// Adds the header validation middleware.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <param name="options">The options.</param>
    /// <returns>The <see cref="IApplicationBuilder"/>.</returns>
    public static IApplicationBuilder UseHeaderValidation(this IApplicationBuilder app, HeaderValidationOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(app);
        var optionsValue = options ?? new HeaderValidationOptions();
        app.UseMiddleware<HeaderValidationMiddleware>(Options.Create(optionsValue));
        return app;
    }


    /// <summary>
    /// Adds the X-Frame-Options header middleware.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <param name="options">The options.</param>
    /// <returns>The <see cref="IApplicationBuilder"/>.</returns>
    public static IApplicationBuilder UseXFrameOptions(this IApplicationBuilder app, XFrameOptionsHeaderOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(app);
        var optionsValue = options ?? new XFrameOptionsHeaderOptions();
        app.UseMiddleware<XFrameOptionsMiddleware>(Options.Create(optionsValue));
        return app;
    }

    /// <summary>
    /// Adds the X-Content-Type-Options header middleware.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <returns>The <see cref="IApplicationBuilder"/>.</returns>
    public static IApplicationBuilder UseXContentTypeOptions(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app);
        app.UseMiddleware<XContentTypeOptionsMiddleware>();
        return app;
    }

    /// <summary>
    /// Adds the strict transport security (HSTS) header middleware.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <param name="options">The options.</param>
    /// <returns>The <see cref="IApplicationBuilder"/>.</returns>
    public static IApplicationBuilder UseStrictTransportSecurity(this IApplicationBuilder app, StrictTransportSecurityHeaderOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(app);
        var optionsValue = options ?? new StrictTransportSecurityHeaderOptions();
        app.UseMiddleware<StrictTransportSecurityMiddleware>(Options.Create(optionsValue));
        return app;
    }

    /// <summary>
    /// Adds the content security policy (CSP) header middleware.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <param name="options">The options builder.</param>
    /// <returns>The <see cref="IApplicationBuilder"/>.</returns>
    public static IApplicationBuilder UseContentSecurityPolicy(
        this IApplicationBuilder app,
        Action<IServiceProvider, ContentSecurityPolicyHeaderOptionsBuilder> options)
    {
        ArgumentNullException.ThrowIfNull(app);
        app.UseMiddleware<ContentSecurityPolicyMiddleware>(options);
        return app;
    }

    /// <summary>
    /// Adds the Report-To header middleware.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <param name="options">The options.</param>
    /// <returns>The <see cref="IApplicationBuilder"/>.</returns>
    public static IApplicationBuilder UseReportTo(this IApplicationBuilder app, ReportToHeaderOptions options)
    {
        ArgumentNullException.ThrowIfNull(app);
        app.UseMiddleware<ReportToMiddleware>(Options.Create(options));
        return app;
    }

    /// <summary>
    /// Use a secure cookie policy.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <param name="secured">When true the cookies require HTTPS.</param>
    /// <param name="httpOnly">When true the cookies cannot be read by JavaScript.</param>
    /// <param name="strictSameSite">When true the same site policy is set to <see cref="SameSiteMode.Strict"/>,
    /// otherwise <see cref="SameSiteMode.Lax"/>.</param>
    /// <returns>The <see cref="IApplicationBuilder"/>.</returns>
    public static IApplicationBuilder UseSecureCookiePolicy(
        this IApplicationBuilder app,
        bool secured = true,
        bool httpOnly = true,
        bool strictSameSite = true)
    {
        ArgumentNullException.ThrowIfNull(app);
        return app.UseCookiePolicy(
            new CookiePolicyOptions
            {
                Secure = secured ? CookieSecurePolicy.Always : CookieSecurePolicy.SameAsRequest,
                HttpOnly = httpOnly ? HttpOnlyPolicy.Always : HttpOnlyPolicy.None,
                MinimumSameSitePolicy = strictSameSite ? SameSiteMode.Strict : SameSiteMode.Lax,
            });
    }
}