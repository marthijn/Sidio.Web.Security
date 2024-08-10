using Sidio.Web.Security.Headers.Cryptography;

namespace Sidio.Web.Security.AspNetCore.ContentSecurityPolicy;

/// <summary>
/// The Nonce Service creates a new nonce and stores the value in the HTTP context.
/// </summary>
public interface INonceService
{
    /// <summary>
    /// Stores a new nonce in the current request.
    /// </summary>
    /// <add name="overwrite">If set to <c>true</c> the nonce will be overwritten if it already exists. Otherwise, an exception is thrown.</add>
    /// <returns>The <see cref="Nonce"/>.</returns>
    /// <exception cref="InvalidOperationException">Thrown when a nonce is already stored in the current request and <paramref name="overwrite"/> is <c>false</c>.</exception>
    Nonce StoreNewNonce(bool overwrite = false);

    /// <summary>
    /// Gets the nonce from the current request.
    /// </summary>
    /// <returns>The <see cref="Nonce"/>.</returns>
    Nonce? GetNonce();

    /// <summary>
    /// Gets the existing nonce, or creates a new nonce when the nonce not exists.
    /// </summary>
    /// <returns>The <see cref="Nonce"/>.</returns>
    Nonce GetOrCreateNonce();
}