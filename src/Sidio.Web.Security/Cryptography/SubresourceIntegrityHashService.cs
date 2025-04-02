using System.Security.Cryptography;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Sidio.Web.Security.Cryptography;

/// <summary>
/// The service to generate subresource integrity hashes.
/// </summary>
public sealed class SubresourceIntegrityHashService : ISubresourceIntegrityHashService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HybridCache? _hybridCache;
    private readonly IOptions<SubresourceIntegrityOptions> _options;
    private readonly ILogger<SubresourceIntegrityHashService> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="SubresourceIntegrityHashService"/> class.
    /// </summary>
    /// <param name="httpClientFactory">The HTTP client factory.</param>
    /// <param name="hybridCache">The hybrid cache.</param>
    /// <param name="options">The options.</param>
    /// <param name="logger">The logger.</param>
    public SubresourceIntegrityHashService(
        IHttpClientFactory httpClientFactory,
        IOptions<SubresourceIntegrityOptions> options,
        HybridCache hybridCache,
        ILogger<SubresourceIntegrityHashService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _hybridCache = hybridCache;
        _options = options;
        _logger = logger;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SubresourceIntegrityHashService"/> class.
    /// </summary>
    /// <param name="httpClientFactory">The HTTP client factory.</param>
    /// <param name="options">The options.</param>
    /// <param name="logger">The logger.</param>
    public SubresourceIntegrityHashService(
        IHttpClientFactory httpClientFactory,
        IOptions<SubresourceIntegrityOptions> options,
        ILogger<SubresourceIntegrityHashService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _options = options;
        _logger = logger;

        if (_hybridCache == null)
        {
            if (!options.Value.CacheDisabled)
            {
                throw new InvalidOperationException(
                    "An instance of HybridCache is not configured, but caching of subresource integrity hashes is enabled. Please configure HybridCache or disable caching.");
            }

            _logger.LogInformation("An instance of HybridCache is not configured, caching of subresource integrity hashes is disabled");
        }
    }

    /// <inheritdoc />
    public async Task<SubresourceIntegrityHash> GetIntegrityHashFromUrlAsync(
        Uri uri,
        CancellationToken cancellationToken = default)
    {
        if (uri == null)
        {
            throw new ArgumentNullException(nameof(uri));
        }

        if (_hybridCache == null)
        {
            var h = await GetHashAsync(uri, cancellationToken).ConfigureAwait(false);
            return string.IsNullOrEmpty(h)
                ? new SubresourceIntegrityHash(false)
                : new SubresourceIntegrityHash(true, h);
        }

        var cacheKey = CacheKey(_options.Value.Algorithm, uri.AbsoluteUri);

        var data = await _hybridCache.GetOrCreateAsync(
            cacheKey,
            async ct =>
            {
                _logger.LogTrace("The integrity hash for `{Uri}` was not found in the cache and will be created", uri);
                return await GetHashAsync(uri, ct).ConfigureAwait(false);
            },
            new HybridCacheEntryOptions
            {
                LocalCacheExpiration = _options.Value.LocalCacheExpiration,
                Expiration = _options.Value.CacheExpiration,
            },
            cancellationToken: cancellationToken);

        if (string.IsNullOrWhiteSpace(data))
        {
            if (!_options.Value.CacheWhenFailed)
            {
                _logger.LogWarning(
                    "The integrity hash for `{Uri}` was not generated",
                    uri);
                await _hybridCache.RemoveAsync(cacheKey, cancellationToken);
            }
            else
            {
                _logger.LogWarning(
                    "The integrity hash for `{Uri}` was not generated, an empty string is stored in the cache",
                    uri);
            }

            return new SubresourceIntegrityHash(false);
        }

        return new SubresourceIntegrityHash(true, data);
    }

    private static string CacheKey(SubresourceHashAlgorithm algorithm, string url) => $"SRI:{algorithm}:{url}";

    private static string GetHash(Stream stream, SubresourceHashAlgorithm algorithm)
    {
        using var hashAlgorithm = CreateHashAlgorithm(algorithm);
        var hash = hashAlgorithm.ComputeHash(stream);
        return GetHashPrefix(algorithm) + Convert.ToBase64String(hash);
    }

    private static HashAlgorithm CreateHashAlgorithm(SubresourceHashAlgorithm algorithm)
    {
        return algorithm switch
        {
            SubresourceHashAlgorithm.SHA256 => SHA256.Create(),
            SubresourceHashAlgorithm.SHA384 => SHA384.Create(),
            SubresourceHashAlgorithm.SHA512 => SHA512.Create(),
            _ => throw new ArgumentOutOfRangeException(nameof(algorithm), algorithm, null)
        };
    }

    private static string GetHashPrefix(SubresourceHashAlgorithm algorithm)
    {
        return algorithm switch
        {
            SubresourceHashAlgorithm.SHA256 => SubresourceHashAlgorithmPrefix.Sha256,
            SubresourceHashAlgorithm.SHA384 => SubresourceHashAlgorithmPrefix.Sha384,
            SubresourceHashAlgorithm.SHA512 => SubresourceHashAlgorithmPrefix.Sha512,
            _ => throw new ArgumentOutOfRangeException(nameof(algorithm), algorithm, null)
        };
    }

    private async Task<string?> GetHashAsync(Uri uri, CancellationToken cancellationToken)
    {
        using var httpClient = _httpClientFactory.CreateClient();

        try
        {
#if NET5_0_OR_GREATER
            await using var stream = await httpClient.GetStreamAsync(uri, cancellationToken).ConfigureAwait(false);
            return GetHash(stream, _options.Value.Algorithm);
#else
            using var stream = await httpClient.GetStreamAsync(uri).ConfigureAwait(false);
            return GetHash(stream, _options.Value.Algorithm);
#endif
        }
        catch (HttpRequestException ex)
        {
            _logger.LogWarning(ex, "Failed to get the content from: {Uri}", uri);
            return null;
        }
    }
}