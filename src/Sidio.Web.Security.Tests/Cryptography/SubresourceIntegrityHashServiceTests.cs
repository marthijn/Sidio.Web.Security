using System.Net;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using RichardSzalay.MockHttp;
using Sidio.Web.Security.Cryptography;

#if NET481
using System.Net.Http;
#endif

namespace Sidio.Web.Security.Tests.Cryptography;

public sealed class SubresourceIntegrityHashServiceTests
{
    [Fact]
    public async Task GetHashFromUrlAsync_WhenUrlIsInvalid_ThrowsHttpRequestException()
    {
        // arrange
        const string Url = "https://invalid.url";
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(Url).Respond(HttpStatusCode.NotFound);

        var service = CreateService(mockHttp, out _);

        // act
        var result = await service.GetIntegrityHashFromUrlAsync(new Uri(Url));

        // assert
        result.Success.Should().BeFalse();
        result.Hash.Should().BeNull();
    }

    [Theory]
    [InlineData(SubresourceHashAlgorithm.SHA256, "sha256-/JqT3SQfawRcv/BIHPThkBvs0OEvtFFmqPF/lYI/Cxo=")]
    [InlineData(
        SubresourceHashAlgorithm.SHA384,
        "sha384-1H217gwSVyLSIfaLxHbE7dRb3v4mYCKbpQvzx0cegeju1MVsGrX5xXxAvs/HgeFs")]
    [InlineData(
        SubresourceHashAlgorithm.SHA512,
        "sha512-v2CJ7UaYy4JwqLDIrZUI/4hqeoQieOmAZNXBeQyjo21dadnwR+8ZaIJVT8EE2iyI61OV8e6M8PP2/4hpQINQ/g==")]
    public async Task GetHashFromUrlAsync_WhenUrlIsValid_ReturnsHash(
        SubresourceHashAlgorithm algorithm,
        string expectedHash)
    {
        // arrange
        const string Url = "https://localhost/jquery-3.6.0.min.js";
        var expectedCacheKey = $"SRI:{algorithm}:{Url}";
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When(Url).Respond(
            HttpStatusCode.OK,
            "application/javascript",
            TestResources.GetFileContents("Sidio.Web.Security.Tests.Cryptography.Resources.example.js"));

        var service = CreateService(mockHttp, out var cache, new SubresourceIntegrityOptions
        {
            Algorithm = algorithm,
        });

        cache.KeyNotExists(expectedCacheKey);

        // act
        var result = await service.GetIntegrityHashFromUrlAsync(new Uri(Url));

        // assert
        result.Success.Should().BeTrue();
        result.Hash.Should().BeEquivalentTo(expectedHash);
        cache.KeyExists(expectedCacheKey);
    }

    [Fact]
    public async Task GetHashFromUrlAsync_WhenValueIsCached_ReturnCached()
    {
        // arrange
        const string Url = "https://localhost/jquery-3.6.0.min.js";
        const SubresourceHashAlgorithm Algorithm = SubresourceHashAlgorithm.SHA256;
        const string ExpectedCacheKey = $"SRI:SHA256:{Url}";
        const string ExpectedHash = "sha256-/JqT3SQfawRcv/BIHPThkBvs0OEvtFFmqPF/lYI/Cxo=";
        var mockHttp = new MockHttpMessageHandler();
        var service = CreateService(mockHttp, out var cache, new SubresourceIntegrityOptions
        {
            Algorithm = Algorithm,
        });

        await cache.SetAsync(ExpectedCacheKey, ExpectedHash);

        // act
        var result = await service.GetIntegrityHashFromUrlAsync(new Uri(Url));

        // assert
        result.Success.Should().BeTrue();
        result.Hash.Should().BeEquivalentTo(ExpectedHash);
    }

    [Fact]
    public async Task GetHashFromUrlAsync_WhenValueIsCachedAsEmptyString_ReturnCached()
    {
        // arrange
        const string Url = "https://localhost/jquery-3.6.0.min.js";
        const SubresourceHashAlgorithm Algorithm = SubresourceHashAlgorithm.SHA256;
        const string ExpectedCacheKey = $"SRI:SHA256:{Url}";
        var mockHttp = new MockHttpMessageHandler();
        var service = CreateService(mockHttp, out var cache, new SubresourceIntegrityOptions
        {
            Algorithm = Algorithm,
        });

        await cache.SetAsync(ExpectedCacheKey, string.Empty);

        // act
        var result = await service.GetIntegrityHashFromUrlAsync(new Uri(Url));

        // assert
        result.Success.Should().BeFalse();
        result.Hash.Should().BeNull();
    }

    private static SubresourceIntegrityHashService CreateService(
        MockHttpMessageHandler handler,
        out FakeHybridCache cache,
        SubresourceIntegrityOptions? options = null)
    {
        var client = new HttpClient(handler);
        var httpClientFactory = new Mock<IHttpClientFactory>();
        httpClientFactory.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(client);

        cache = new FakeHybridCache();

        return new SubresourceIntegrityHashService(
            httpClientFactory.Object,
            cache,
            Options.Create(options ?? new SubresourceIntegrityOptions()),
            NullLogger<SubresourceIntegrityHashService>.Instance);
    }
}