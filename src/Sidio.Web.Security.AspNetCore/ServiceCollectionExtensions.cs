using Microsoft.Extensions.DependencyInjection;
using Sidio.Web.Security.AspNetCore.ContentSecurityPolicy;
using Sidio.Web.Security.AspNetCore.Html;
using Sidio.Web.Security.Cryptography;

namespace Sidio.Web.Security.AspNetCore;

/// <summary>
/// The service collection extensions.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the content security policy services.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <returns>The <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddContentSecurityPolicy(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);
        services.AddHttpContextAccessor().AddSingleton<INonceService, NonceService>();
        return services;
    }

    /// <summary>
    /// Adds the subresource integrity services.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configureOptions">The options (optional).</param>
    /// <returns>The <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddSubresourceIntegrity(
        this IServiceCollection services,
        Action<SubresourceIntegrityOptions>? configureOptions = null)
    {
        ArgumentNullException.ThrowIfNull(services);
        if (configureOptions is not null)
        {
            services.Configure(configureOptions);
        }

        services.AddSingleton<ISubresourceIntegrityHashService, SubresourceIntegrityHashService>();
        services.AddHttpClient();
        return services;
    }

    /// <summary>
    /// Configures the tag helpers.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configureOptions"></param>
    /// <returns>The <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection ConfigureTagHelpers(this IServiceCollection services, Action<TagHelperOptions> configureOptions)
    {
        ArgumentNullException.ThrowIfNull(services);
        return services.Configure(configureOptions);
    }
}