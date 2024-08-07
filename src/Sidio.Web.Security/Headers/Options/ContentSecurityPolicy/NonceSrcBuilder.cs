namespace Sidio.Web.Security.Headers.Options.ContentSecurityPolicy;

public abstract class NonceSrcBuilder<T> : SrcBuilderBase<T>
    where T : class, ISrcBuilder
{
    /// <summary>
    /// Add the 'nonce' to the directive.
    /// The nonce should be a secure random base64 string, and should not be reused.
    /// </summary>
    /// <returns></returns>
    public NonceSrcBuilder<T> AddNonce(string nonce)
    {
        if (string.IsNullOrWhiteSpace(nonce))
        {
            throw new ArgumentException("The nonce should not be null or empty.", nameof(nonce));
        }

        Sources.Add($"nonce-{nonce}");
        return this;
    }

    /// <summary>
    /// Add the 'sha256' to the directive.
    /// </summary>
    /// <param name="sha256">The hash as base64.</param>
    /// <returns>The <see cref="NonceSrcBuilder{T}"/>.</returns>
    public NonceSrcBuilder<T> AddSha256(string sha256)
    {
        if (string.IsNullOrWhiteSpace(sha256))
        {
            throw new ArgumentException("The SHA hash should not be null or empty.", nameof(sha256));
        }

        Sources.Add($"'sha256-{sha256}'");
        return this;
    }

    /// <summary>
    /// Add the 'sha256' to the directive.
    /// </summary>
    /// <param name="sha384">The hash as base64.</param>
    /// <returns>The <see cref="NonceSrcBuilder{T}"/>.</returns>
    public NonceSrcBuilder<T> AddSha384(string sha384)
    {
        if (string.IsNullOrWhiteSpace(sha384))
        {
            throw new ArgumentException("The SHA hash should not be null or empty.", nameof(sha384));
        }

        Sources.Add($"'sha384-{sha384}'");
        return this;
    }

    /// <summary>
    /// Add the 'sha256' to the directive.
    /// </summary>
    /// <param name="sha512">The hash as base64.</param>
    /// <returns>The <see cref="NonceSrcBuilder{T}"/>.</returns>
    public NonceSrcBuilder<T> AddSha512(string sha512)
    {
        if (string.IsNullOrWhiteSpace(sha512))
        {
            throw new ArgumentException("The SHA hash should not be null or empty.", nameof(sha512));
        }

        Sources.Add($"'sha512-{sha512}'");
        return this;
    }
}