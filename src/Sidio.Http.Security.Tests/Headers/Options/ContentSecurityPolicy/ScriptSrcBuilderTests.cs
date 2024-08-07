using Sidio.Http.Security.Headers.Options.ContentSecurityPolicy;

namespace Sidio.Http.Security.Tests.Headers.Options.ContentSecurityPolicy;

public sealed class ScriptSrcBuilderTests : NonceSrcBuilderTests<ScriptSrcBuilder>
{
    [Fact]
    public void AllowScriptDynamic_DirectiveShouldExist()
    {
        // act
        var result = Builder.AllowScriptDynamic();

        // assert
        result.Sources.Should().ContainSingle("'script-dynamic'");
        result.Should().BeSameAs(Builder);
    }

    [Fact]
    public void AllowUnsafeEval_DirectiveShouldExist()
    {
        // act
        var result = Builder.AllowUnsafeEval();

        // assert
        result.Sources.Should().ContainSingle("'unsafe-eval'");
        result.Should().BeSameAs(Builder);
    }

    [Fact]
    public void AllowUnsafeHashes_DirectiveShouldExist()
    {
        // act
        var result = Builder.AllowUnsafeHashes();

        // assert
        result.Sources.Should().ContainSingle("'unsafe-hashes'");
        result.Should().BeSameAs(Builder);
    }

    [Fact]
    public void AllowInlineSpeculationRules_DirectiveShouldExist()
    {
        // act
        var result = Builder.AllowUnsafeHashes();

        // assert
        result.Sources.Should().ContainSingle("'inline-speculation-rules'");
        result.Should().BeSameAs(Builder);
    }
}