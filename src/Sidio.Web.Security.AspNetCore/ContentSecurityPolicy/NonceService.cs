using Microsoft.AspNetCore.Http;
using Sidio.Web.Security.Headers.Cryptography;

namespace Sidio.Web.Security.AspNetCore.ContentSecurityPolicy;

public sealed class NonceService : INonceService
{
    private const string Key = $"{nameof(NonceService)}:Nonce";

    private readonly IHttpContextAccessor _httpContextAccessor;

    public NonceService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    private HttpContext HttpContext => _httpContextAccessor.HttpContext ?? throw new InvalidOperationException("HttpContext is null");

    public Nonce StoreNewNonce(bool overwrite = false)
    {
        if (HttpContext.Items[Key] is Nonce currentNonce && !overwrite)
        {
            throw new InvalidOperationException("Nonce is already stored in the current request.");
        }

        var nonce = Nonce.Create();
        HttpContext.Items[Key] = nonce;
        return nonce;
    }

    public Nonce? GetNonce() => HttpContext.Items[Key] is not Nonce nonce ? null : nonce;

    public Nonce GetOrCreateNonce() => GetNonce() ?? StoreNewNonce();
}