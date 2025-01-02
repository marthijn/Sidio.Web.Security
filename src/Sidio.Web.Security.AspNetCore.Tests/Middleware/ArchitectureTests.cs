using ArchUnitNET.Domain;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using Sidio.Web.Security.AspNetCore.Middleware;

using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace Sidio.Web.Security.AspNetCore.Tests.Middleware;

public sealed class ArchitectureTests
{
    private static readonly Architecture Architecture =
        new ArchLoader().LoadAssemblies(typeof(ContentSecurityPolicyMiddleware).Assembly).Build();

    private readonly IObjectProvider<Class> _middlewareClasses =
        Classes().That().ResideInNamespace("Sidio.Web.Security.AspNetCore.Middleware").And()
            .HaveNameEndingWith("Middleware");

    [Fact]
    public void MiddlewareShouldBeInternal()
    {
        // act
        var isInternal = Classes().That().Are(_middlewareClasses).Should().BeInternal();

        // assert
        isInternal.Check(Architecture);
    }
}