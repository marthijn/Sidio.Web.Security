using Microsoft.Extensions.DependencyInjection;
using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Headers.Validation;

namespace Sidio.Web.Security.AspNetCore.Tests;

public sealed class ApplicationBuilderExtensionsTests
{
    private readonly Fixture _fixture = new();

    [Fact]
    public void UseHeaderValidation_WithDefaultOptions_ReturnsApplicationBuilder()
    {
        // arrange
        var options = _fixture.Create<HeaderValidationOptions>();
        var applicationBuilder = CreateApplicationBuilder();

        // act
        var result = applicationBuilder.UseHeaderValidation(options);

        // assert
        result.Should().BeSameAs(applicationBuilder);
        applicationBuilder.Middleware.Should().ContainSingle();
    }

    [Fact]
    public void UseXFrameOptions_WithDefaultOptions_ReturnsApplicationBuilder()
    {
        // arrange
        var options = _fixture.Create<XFrameOptionsHeaderOptions>();
        var applicationBuilder = CreateApplicationBuilder();

        // act
        var result = applicationBuilder.UseXFrameOptions(options);

        // assert
        result.Should().BeSameAs(applicationBuilder);
        applicationBuilder.Middleware.Should().ContainSingle();
    }

    [Fact]
    public void UseXContentTypeOptions_ReturnsApplicationBuilder()
    {
        // arrange
        var applicationBuilder = CreateApplicationBuilder();

        // act
        var result = applicationBuilder.UseXContentTypeOptions();

        // assert
        result.Should().BeSameAs(applicationBuilder);
        applicationBuilder.Middleware.Should().ContainSingle();
    }

    [Fact]
    public void UseStrictTransportSecurity_WithDefaultOptions_ReturnsApplicationBuilder()
    {
        // arrange
        var options = _fixture.Create<StrictTransportSecurityHeaderOptions>();
        var applicationBuilder = CreateApplicationBuilder();

        // act
        var result = applicationBuilder.UseStrictTransportSecurity(options);

        // assert
        result.Should().BeSameAs(applicationBuilder);
        applicationBuilder.Middleware.Should().ContainSingle();
    }

    [Fact]
    public void UseContentSecurityPolicy_WithDefaultOptions_ReturnsApplicationBuilder()
    {
        // arrange
        var applicationBuilder = CreateApplicationBuilder();

        // act
        var result = applicationBuilder.UseContentSecurityPolicy(
            (_, _) =>
            {
            });

        // assert
        result.Should().BeSameAs(applicationBuilder);
        applicationBuilder.Middleware.Should().ContainSingle();
    }

    [Fact]
    public void UseReportTo_WithDefaultOptions_ReturnsApplicationBuilder()
    {
        // arrange
        var options = _fixture.Create<ReportToHeaderOptions>();
        var applicationBuilder = CreateApplicationBuilder();

        // act
        var result = applicationBuilder.UseReportTo(options);

        // assert
        result.Should().BeSameAs(applicationBuilder);
        applicationBuilder.Middleware.Should().ContainSingle();
    }

    [Fact]
    public void UseXXssProtection_WithDefaultOptions_ReturnsApplicationBuilder()
    {
        // arrange
        var options = _fixture.Create<XXssProtectionHeaderOptions>();
        var applicationBuilder = CreateApplicationBuilder();

        // act
        var result = applicationBuilder.UseXXssProtection(options);

        // assert
        result.Should().BeSameAs(applicationBuilder);
        applicationBuilder.Middleware.Should().ContainSingle();
    }

    [Fact]
    public void UseSecureCookiePolicy_ReturnsApplicationBuilder()
    {
        // arrange
        var applicationBuilder = CreateApplicationBuilder();

        // act
        var result = applicationBuilder.UseSecureCookiePolicy();

        // assert
        result.Should().BeSameAs(applicationBuilder);
        applicationBuilder.Middleware.Should().ContainSingle();
    }

    private static ApplicationBuilderSpy CreateApplicationBuilder()
    {
        var serviceCollection = new ServiceCollection();
        var serviceProvider = serviceCollection.BuildServiceProvider();
        return new ApplicationBuilderSpy(serviceProvider);
    }
}