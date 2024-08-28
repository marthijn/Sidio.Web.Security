namespace Sidio.Web.Security.Cryptography;

/// <summary>
/// The service to generate Subresource Integrity hashes.
/// </summary>
public interface ISubresourceIntegrityHashService
{
    /// <summary>
    /// Gets the hash of the content from the URL using the specified algorithm.
    /// </summary>
    /// <param name="uri">The URL.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="SubresourceIntegrityHash"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the uri is null.</exception>
    Task<SubresourceIntegrityHash> GetIntegrityHashFromUrlAsync(
        Uri uri,
        CancellationToken cancellationToken = default);
}