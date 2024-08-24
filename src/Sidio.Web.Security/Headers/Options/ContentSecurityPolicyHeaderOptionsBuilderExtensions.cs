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
        const string Space = " ";

        builder.Options.DefaultSrc ??= string.Empty;
        builder.Options.ScriptSrc ??= string.Empty;

        var defaultSrcDirectives = new List<string>();
        if (!builder.Options.DefaultSrc.Contains(SrcBuilder.UnsafeInline))
        {
            defaultSrcDirectives.Add(SrcBuilder.UnsafeInline);
        }

        if (!builder.Options.DefaultSrc.Contains(HttpLocalhost))
        {
            defaultSrcDirectives.Add(HttpLocalhost);
        }

        if (!builder.Options.DefaultSrc.Contains(HttpsLocalhost))
        {
            defaultSrcDirectives.Add(HttpsLocalhost);
        }

        if (!builder.Options.DefaultSrc.Contains(WsLocalhost))
        {
            defaultSrcDirectives.Add(WsLocalhost);
        }

        builder.Options.DefaultSrc += Space + string.Join(Space, defaultSrcDirectives);
        builder.Options.DefaultSrc = builder.Options.DefaultSrc.Trim();

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