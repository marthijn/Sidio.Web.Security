namespace Sidio.Web.Security.Headers.Options.ContentSecurityPolicy;

/// <summary>
/// The nonce and hash builder for the Content Security Policy directive 'src'.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class NonceAndHashSrcBuilder<T> : SrcBuilderBase<T>
    where T : class, ISrcBuilder
{
    /// <summary>
    /// Add a static 'nonce' to the directive.
    /// </summary>
    /// <remarks>The nonce should be a secure random base64 string, and should not be reused.</remarks>
    /// <returns></returns>
    public T AddNonce(string nonce)
    {
        if (string.IsNullOrWhiteSpace(nonce))
        {
            throw new ArgumentException("The nonce should not be null or empty.", nameof(nonce));
        }

        Sources.Add($"'nonce-{nonce}'");
        return This;
    }

    /// <summary>
    /// Add the 'sha256' to the directive.
    /// </summary>
    /// <param name="sha256">The hash as base64.</param>
    /// <returns>The <see cref="NonceAndHashSrcBuilder{T}"/>.</returns>
    public T AddSha256(string sha256)
    {
        if (string.IsNullOrWhiteSpace(sha256))
        {
            throw new ArgumentException("The SHA hash should not be null or empty.", nameof(sha256));
        }

        Sources.Add($"'sha256-{sha256}'");
        return This;
    }

    /// <summary>
    /// Add the 'sha256' to the directive.
    /// </summary>
    /// <param name="sha384">The hash as base64.</param>
    /// <returns>The <see cref="NonceAndHashSrcBuilder{T}"/>.</returns>
    public T AddSha384(string sha384)
    {
        if (string.IsNullOrWhiteSpace(sha384))
        {
            throw new ArgumentException("The SHA hash should not be null or empty.", nameof(sha384));
        }

        Sources.Add($"'sha384-{sha384}'");
        return This;
    }

    /// <summary>
    /// Add the 'sha256' to the directive.
    /// </summary>
    /// <param name="sha512">The hash as base64.</param>
    /// <returns>The <see cref="NonceAndHashSrcBuilder{T}"/>.</returns>
    public T AddSha512(string sha512)
    {
        if (string.IsNullOrWhiteSpace(sha512))
        {
            throw new ArgumentException("The SHA hash should not be null or empty.", nameof(sha512));
        }

        Sources.Add($"'sha512-{sha512}'");
        return This;
    }
}