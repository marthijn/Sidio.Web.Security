using Microsoft.AspNetCore.Http;
using Sidio.Web.Security.Headers.Cryptography;

namespace Sidio.Web.Security.AspNetCore.ContentSecurityPolicy;

/// <summary>
/// The Nonce Service creates a new nonce and stores the value in the HTTP context.
/// </summary>
public sealed class NonceService : INonceService
{
    private const string Key = $"{nameof(NonceService)}:Nonce";

    private readonly IHttpContextAccessor _httpContextAccessor;

    /// <summary>
    /// Creates a new instance of <see cref="NonceService"/>.
    /// </summary>
    /// <param name="httpContextAccessor">The HTTP Context Accessor.</param>
    public NonceService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    private HttpContext HttpContext =>
        _httpContextAccessor.HttpContext ?? throw new InvalidOperationException("HttpContext is null");

    /// <inheritdoc />
    public Nonce StoreNewNonce(bool overwrite = false)
    {
        if (HttpContext.Items[Key] is Nonce _ && !overwrite)
        {
            throw new InvalidOperationException("Nonce is already stored in the current request.");
        }

        var nonce = Nonce.Create();
        HttpContext.Items[Key] = nonce;
        return nonce;
    }

    /// <inheritdoc />
    public Nonce? GetNonce() => HttpContext.Items[Key] is not Nonce nonce ? null : nonce;

    /// <inheritdoc />
    public Nonce GetOrCreateNonce() => GetNonce() ?? StoreNewNonce();
}