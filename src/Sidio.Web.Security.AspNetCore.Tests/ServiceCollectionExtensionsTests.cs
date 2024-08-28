using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Sidio.Web.Security.AspNetCore.ContentSecurityPolicy;
using Sidio.Web.Security.AspNetCore.Html;
using Sidio.Web.Security.Cryptography;

namespace Sidio.Web.Security.AspNetCore.Tests;

public sealed class ServiceCollectionExtensionsTests
{
    [Fact]
    public void AddContentSecurityPolicy_AddsContentSecurityPolicy()
    {
        // arrange
        var services = new ServiceCollection();

        // act
        services.AddContentSecurityPolicy();

        // assert
        var serviceProvider = services.BuildServiceProvider();
        var contentSecurityPolicy = serviceProvider.GetService<INonceService>();
        contentSecurityPolicy.Should().NotBeNull();
    }

    [Fact]
    public void AddSubresourceIntegrity_WithoutOptions_AddsSubresourceIntegrity()
    {
        // arrange
        var services = new ServiceCollection();
        services.AddDistributedMemoryCache();

        // act
        services.AddSubresourceIntegrity();

        // assert
        var serviceProvider = services.BuildServiceProvider();
        var subresourceIntegrityHashService = serviceProvider.GetService<ISubresourceIntegrityHashService>();
        subresourceIntegrityHashService.Should().NotBeNull();
    }

    [Fact]
    public void AddSubresourceIntegrity_WithOptions_AddsSubresourceIntegrity()
    {
        // arrange
        var services = new ServiceCollection();
        services.AddDistributedMemoryCache();

        // act
        services.AddSubresourceIntegrity(options => options.Algorithm = SubresourceHashAlgorithm.SHA512);

        // assert
        var serviceProvider = services.BuildServiceProvider();
        var subresourceIntegrityHashService = serviceProvider.GetService<ISubresourceIntegrityHashService>();
        subresourceIntegrityHashService.Should().NotBeNull();

        var options = serviceProvider.GetService<IOptions<SubresourceIntegrityOptions>>();
        options.Should().NotBeNull();
        options!.Value.Algorithm.Should().Be(SubresourceHashAlgorithm.SHA512);
    }

    [Fact]
    public void ConfigureTagHelpers_AddsTagHelpers()
    {
        // arrange
        var services = new ServiceCollection();

        // act
        services.ConfigureTagHelpers(options => options.AutoApplyNonce = true);

        // assert
        var serviceProvider = services.BuildServiceProvider();
        var options = serviceProvider.GetService<IOptions<TagHelperOptions>>();
        options.Should().NotBeNull();
        options!.Value.AutoApplyNonce.Should().BeTrue();
    }
}