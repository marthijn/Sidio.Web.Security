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
    /// Gets or sets the expiration time for the cache.
    /// Default is 90 days.
    /// </summary>
    public TimeSpan AbsoluteExpiration { get; set; } = TimeSpan.FromDays(90);

    /// <summary>
    /// Gets or sets a value indicating whether to cache the hash when the hash generation fails.
    /// Setting this to true prevents multiple requests to the same URL every time a hash is requested.
    /// </summary>
    public bool CacheWhenFailed { get; set; } = true;
}