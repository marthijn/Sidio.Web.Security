using System.Diagnostics.CodeAnalysis;

namespace Sidio.Web.Security.Cryptography;

/// <summary>
/// The result of a Subresource Integrity hash generation.
/// </summary>
public sealed record SubresourceIntegrityHash
{
    internal SubresourceIntegrityHash(bool success, string? hash = null)
    {
        Success = success;
        Hash = hash;

        if (success && hash is null)
        {
            throw new ArgumentNullException(nameof(hash));
        }
    }

    /// <summary>
    /// Gets a value indicating whether the hash was successfully generated.
    /// </summary>
#if NET5_0_OR_GREATER
    [MemberNotNullWhen(true, nameof(Hash))]
#endif
    public bool Success { get; }

    /// <summary>
    /// Gets the hash value.
    /// </summary>
    public string? Hash { get; }
}