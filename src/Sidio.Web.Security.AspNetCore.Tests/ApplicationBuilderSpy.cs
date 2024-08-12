using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace Sidio.Web.Security.AspNetCore.Tests;

internal sealed class ApplicationBuilderSpy : IApplicationBuilder
{
    private readonly List<Func<RequestDelegate, RequestDelegate>> _middleware = new();

    public IServiceProvider ApplicationServices { get; set; }

    public IFeatureCollection ServerFeatures { get; }

    public IDictionary<string, object?> Properties { get; }

    public IReadOnlyList<Func<RequestDelegate, RequestDelegate>> Middleware => _middleware;

    public ApplicationBuilderSpy(IServiceProvider services)
    {
        ApplicationServices = services;
        ServerFeatures = new FeatureCollection();
        Properties = new Dictionary<string, object?>();
    }

    public IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware)
    {
        _middleware.Add(middleware);
        return this;
    }

    public IApplicationBuilder New()
    {
        throw new NotImplementedException();
    }

    public RequestDelegate Build()
    {
        throw new NotImplementedException();
    }
}