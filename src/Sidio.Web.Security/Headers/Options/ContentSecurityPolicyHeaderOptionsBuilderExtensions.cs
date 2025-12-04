using Sidio.Web.Security.Headers.Options.ContentSecurityPolicy;

namespace Sidio.Web.Security.Headers.Options;

/// <summary>
/// The content security policy header options builder extensions.
/// </summary>
public static class ContentSecurityPolicyHeaderOptionsBuilderExtensions
{
    /// <summary>
    /// Appends the browser link policy to the content security policy header options.
    /// See: <a href="https://learn.microsoft.com/en-us/aspnet/core/client-side/using-browserlink">MS Learn</a>.
    /// </summary>
    /// <remarks>Only use this function in development mode.</remarks>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="ContentSecurityPolicyHeaderOptionsBuilder"/>.</returns>
    public static ContentSecurityPolicyHeaderOptionsBuilder AppendBrowserLinkPolicy(
        this ContentSecurityPolicyHeaderOptionsBuilder builder)
    {
        const string HttpLocalhost = "http://localhost:*";
        const string HttpsLocalhost = "https://localhost:*";
        const string WsLocalhost = "ws://localhost:*";
        const string WssLocalhost = "wss://localhost:*";
        const string Space = " ";

        builder.Options.ConnectSrc ??= string.Empty;
        builder.Options.ScriptSrc ??= string.Empty;

        var defaultConnectSrcDirective = new List<string>();
        if (!builder.Options.ConnectSrc.Contains(SrcBuilder.UnsafeInline))
        {
            defaultConnectSrcDirective.Add(SrcBuilder.UnsafeInline);
        }

        if (!builder.Options.ConnectSrc.Contains(HttpLocalhost))
        {
            defaultConnectSrcDirective.Add(HttpLocalhost);
        }

        if (!builder.Options.ConnectSrc.Contains(HttpsLocalhost))
        {
            defaultConnectSrcDirective.Add(HttpsLocalhost);
        }

        if (!builder.Options.ConnectSrc.Contains(WsLocalhost))
        {
            defaultConnectSrcDirective.Add(WsLocalhost);
        }

        if (!builder.Options.ConnectSrc.Contains(WssLocalhost))
        {
            defaultConnectSrcDirective.Add(WssLocalhost);
        }

        builder.Options.ConnectSrc += Space + string.Join(Space, defaultConnectSrcDirective);
        builder.Options.ConnectSrc = builder.Options.ConnectSrc.Trim();

        var scriptSrcDirectives = new List<string>();
        if (!builder.Options.ScriptSrc.Contains(SrcBuilder.UnsafeInline))
        {
            scriptSrcDirectives.Add(SrcBuilder.UnsafeInline);
        }

        if (!builder.Options.ScriptSrc.Contains(HttpLocalhost))
        {
            scriptSrcDirectives.Add(HttpLocalhost);
        }

        if (!builder.Options.ScriptSrc.Contains(HttpsLocalhost))
        {
            scriptSrcDirectives.Add(HttpsLocalhost);
        }

        builder.Options.ScriptSrc += Space + string.Join(Space, scriptSrcDirectives);
        builder.Options.ScriptSrc = builder.Options.ScriptSrc.Trim();

        return builder;
    }
}