using Microsoft.Extensions.DependencyInjection;
using Sidio.Web.Security.AspNetCore.ContentSecurityPolicy;

namespace Sidio.Web.Security.AspNetCore;

public static class ServiceCollectionExtensions
{
    /*public static IServiceCollection ConfigureXFrameOptions(
        this IServiceCollection services,
        Action<XFrameOptionsHeaderOptions> options)
    {
        services.Configure(options);
        services.AddSingleton<XFrameOptionsHeaderOptions>();
        return services;
    }*/

    public static IServiceCollection AddContentSecurityPolicy(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);
        services.AddHttpContextAccessor().AddSingleton<INonceService, NonceService>();
        return services;
    }
}