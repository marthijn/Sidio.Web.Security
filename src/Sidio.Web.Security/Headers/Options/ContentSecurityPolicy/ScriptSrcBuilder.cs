namespace Sidio.Web.Security.Headers.Options.ContentSecurityPolicy;

/// <summary>
/// The builder for the Content Security Policy directive 'script-src'.
/// </summary>
public sealed class ScriptSrcBuilder : NonceSrcBuilder<ScriptSrcBuilder>
{
    /// <summary>
    /// Add the 'strict-dynamic' to the directive.
    /// </summary>
    /// <returns>The <see cref="ScriptSrcBuilder"/>.</returns>
    public ScriptSrcBuilder AllowStrictDynamic()
    {
        Sources.Add("'strict-dynamic'");
        return this;
    }

    /// <summary>
    /// Add the 'unsafe-eval' to the directive.
    /// </summary>
    /// <returns>The <see cref="ScriptSrcBuilder"/>.</returns>
    public ScriptSrcBuilder AllowUnsafeEval()
    {
        Sources.Add("'unsafe-eval'");
        return this;
    }

    /// <summary>
    /// Adds the 'unsafe-hashes' to the directive.
    /// </summary>
    /// <returns>The <see cref="ScriptSrcBuilder"/>.</returns>
    public ScriptSrcBuilder AllowUnsafeHashes()
    {
        Sources.Add("'unsafe-hashes'");
        return this;
    }

    /// <summary>
    /// Adds the 'inline-speculation-rules' to the directives which allows the inclusion
    /// of speculation rules in scripts.
    /// </summary>
    /// <returns>The <see cref="ScriptSrcBuilder"/>.</returns>
    public ScriptSrcBuilder AllowInlineSpeculationRules()
    {
        Sources.Add("'inline-speculation-rules'");
        return this;
    }
}