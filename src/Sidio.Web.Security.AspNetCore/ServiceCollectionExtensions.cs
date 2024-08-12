using Microsoft.Extensions.DependencyInjection;
using Sidio.Web.Security.AspNetCore.ContentSecurityPolicy;

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
}