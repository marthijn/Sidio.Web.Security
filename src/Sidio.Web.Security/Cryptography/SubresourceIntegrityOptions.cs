namespace Sidio.Web.Security.Cryptography;

/// <summary>
/// The options for the Subresource Integrity hash service.
/// </summary>
public sealed class SubresourceIntegrityOptions
{
    /// <summary>
    /// Gets or sets the algorithm used to hash the subresource.
    /// </summary>
    public SubresourceHashAlgorithm Algorithm { get; set; } = SubresourceHashAlgorithm.SHA256;

    /// <summary>
    /// Gets or sets the local cache expiration.
    /// Default is 5 minutes.
    /// </summary>
    public TimeSpan LocalCacheExpiration { get; set; } = TimeSpan.FromMinutes(5);

    /// <summary>
    /// Gets or sets the cache expiration.
    /// Default is 90 days.
    /// </summary>
    public TimeSpan CacheExpiration { get; set; } = TimeSpan.FromDays(90);

    /// <summary>
    /// Gets or sets a value indicating whether to cache the hash when the hash generation fails.
    /// Setting this to true prevents multiple requests to the same URL every time a hash is requested.
    /// </summary>
    public bool CacheWhenFailed { get; set; } = true;
}