using Microsoft.Extensions.DependencyInjection;
using Sidio.Http.Security.AspNetCore.ContentSecurityPolicy;

namespace Sidio.Http.Security.AspNetCore;

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
        services.AddScoped<INonceService, NonceService>();
        return services;
    }
}