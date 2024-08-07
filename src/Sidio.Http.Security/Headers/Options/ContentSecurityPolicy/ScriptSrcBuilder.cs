namespace Sidio.Http.Security.Headers.Options.ContentSecurityPolicy;

public sealed class ScriptSrcBuilder : NonceSrcBuilder<ScriptSrcBuilder>
{
    /// <summary>
    /// Add the 'strict-dynamic' to the directive.
    /// </summary>
    /// <returns></returns>
    public ScriptSrcBuilder AllowScriptDynamic()
    {
        Sources.Add("'strict-dynamic'");
        return this;
    }

    /// <summary>
    /// Add the 'unsafe-eval' to the directive.
    /// </summary>
    /// <returns></returns>
    public ScriptSrcBuilder AllowUnsafeEval()
    {
        Sources.Add("'unsafe-eval'");
        return this;
    }

    /// <summary>
    /// Adds the 'unsafe-hashes' to the directive.
    /// </summary>
    /// <returns></returns>
    public ScriptSrcBuilder AllowUnsafeHashes()
    {
        Sources.Add("'unsafe-hashes'");
        return this;
    }

    /// <summary>
    /// Adds the 'inline-speculation-rules' to the directives which allows the inclusion
    /// of speculation rules in scripts.
    /// </summary>
    /// <returns></returns>
    public ScriptSrcBuilder AllowInlineSpeculationRules()
    {
        Sources.Add("'inline-speculation-rules'");
        return this;
    }
}