using Microsoft.Extensions.DependencyInjection;
using Sidio.Web.Security.Headers.Options.ContentSecurityPolicy;

namespace Sidio.Web.Security.AspNetCore.ContentSecurityPolicy;

/// <summary>
/// The extension methods for the <see cref="SrcBuilderBase{T}"/>.
/// </summary>
public static class SrcBuilderExtensions
{
    /// <summary>
    /// Add the 'nonce' stored in the HTTP context to the directive.
    /// </summary>
    /// <remarks>The nonce should be a secure random base64 string, and should not be reused.</remarks>
    /// <param name="scriptSrcBuilder"></param>
    /// <param name="serviceProvider"></param>
    /// <returns></returns>
    public static ScriptSrcBuilder AddNonce(this ScriptSrcBuilder scriptSrcBuilder, IServiceProvider serviceProvider)
    {
        ArgumentNullException.ThrowIfNull(scriptSrcBuilder);
        ArgumentNullException.ThrowIfNull(serviceProvider);
        var nonceService = serviceProvider.GetRequiredService<INonceService>();
        return scriptSrcBuilder.AddNonce(nonceService.GetOrCreateNonce().Value);
    }

    /// <summary>
    /// Add the 'nonce' stored in the HTTP context to the directive.
    /// </summary>
    /// <remarks>The nonce should be a secure random base64 string, and should not be reused.</remarks>
    /// <param name="styleSrcBuilder"></param>
    /// <param name="serviceProvider"></param>
    /// <returns></returns>
    public static StyleSrcBuilder AddNonce(this StyleSrcBuilder styleSrcBuilder, IServiceProvider serviceProvider)
    {
        ArgumentNullException.ThrowIfNull(styleSrcBuilder);
        ArgumentNullException.ThrowIfNull(serviceProvider);
        var nonceService = serviceProvider.GetRequiredService<INonceService>();
        return styleSrcBuilder.AddNonce(nonceService.GetOrCreateNonce().Value);
    }
}