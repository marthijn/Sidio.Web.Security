namespace Sidio.Web.Security.Cryptography;

/// <summary>
/// The algorithm used to hash the subresource.
/// </summary>
public enum SubresourceHashAlgorithm
{
    /// <summary>
    /// SHA-256 algorithm.
    /// </summary>
    SHA256,

    /// <summary>
    /// SHA-384 algorithm.
    /// </summary>
    SHA384,

    /// <summary>
    /// SHA-512 algorithm.
    /// </summary>
    SHA512
}