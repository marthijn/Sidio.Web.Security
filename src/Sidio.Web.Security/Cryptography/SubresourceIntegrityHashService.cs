using System.Security.Cryptography;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Sidio.Web.Security.Cryptography;

/// <summary>
/// The service to generate subresource integrity hashes.
/// </summary>
public sealed class SubresourceIntegrityHashService : ISubresourceIntegrityHashService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IDistributedCache _distributedCache;
    private readonly IOptions<SubresourceIntegrityOptions> _options;
    private readonly ILogger<SubresourceIntegrityHashService> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="SubresourceIntegrityHashService"/> class.
    /// </summary>
    /// <param name="httpClientFactory">The HTTP client factory.</param>
    /// <param name="distributedCache">The distributed cache.</param>
    /// <param name="options">The options.</param>
    /// <param name="logger">The logger.</param>
    public SubresourceIntegrityHashService(
        IHttpClientFactory httpClientFactory,
        IDistributedCache distributedCache,
        IOptions<SubresourceIntegrityOptions> options,
        ILogger<SubresourceIntegrityHashService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _distributedCache = distributedCache;
        _options = options;
        _logger = logger;
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

        var cacheKey = CacheKey(_options.Value.Algorithm, uri.AbsoluteUri);
        var cachedData = await _distributedCache.GetStringAsync(cacheKey, cancellationToken).ConfigureAwait(false);

        // return the cached data
        if (cachedData != null)
        {
            _logger.LogTrace("The integrity hash for `{Uri}` was found in the cache", uri);

            // returns a failed hash (stored as empty string)
            return cachedData.Equals(string.Empty)
                ? new SubresourceIntegrityHash(false)
                : new SubresourceIntegrityHash(true, cachedData);
        }

        var hash = await GetHashAsync(uri, cancellationToken).ConfigureAwait(false);

        // store empty string when integrity fails to prevent multiple requests
        if (hash != null || _options.Value.CacheWhenFailed)
        {
            if (hash == null && _options.Value.CacheWhenFailed)
            {
                _logger.LogWarning("The integrity hash for `{Uri}` was not generated, an empty string is ", uri);
            }

            _logger.LogTrace("The integrity hash for `{Uri}` will be stored in the cache", uri);

            await _distributedCache.SetStringAsync(cacheKey, hash ?? string.Empty, CacheOptions, cancellationToken)
                .ConfigureAwait(false);
        }

        return string.IsNullOrEmpty(hash)
            ? new SubresourceIntegrityHash(false)
            : new SubresourceIntegrityHash(true, hash);
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

    private DistributedCacheEntryOptions CacheOptions => new()
    {
        AbsoluteExpirationRelativeToNow = _options.Value.AbsoluteExpiration,
    };

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