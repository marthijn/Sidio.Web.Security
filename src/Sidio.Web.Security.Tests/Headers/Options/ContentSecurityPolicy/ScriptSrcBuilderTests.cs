using Sidio.Web.Security.Headers.Options.ContentSecurityPolicy;

namespace Sidio.Web.Security.Tests.Headers.Options.ContentSecurityPolicy;

public sealed class ScriptSrcBuilderTests : NonceAndHashSrcBuilderTests<ScriptSrcBuilder>
{
    [Fact]
    public void AllowStrictDynamic_DirectiveShouldExist()
    {
        // act
        var result = Builder.AllowStrictDynamic();

        // assert
        result.SourcesInternal.Should().OnlyContain(x => x == "'strict-dynamic'");
        result.Should().BeSameAs(Builder);
    }

    [Fact]
    public void AllowUnsafeEval_DirectiveShouldExist()
    {
        // act
        var result = Builder.AllowUnsafeEval();

        // assert
        result.SourcesInternal.Should().OnlyContain(x => x == "'unsafe-eval'");
        result.Should().BeSameAs(Builder);
    }

    [Fact]
    public void AllowUnsafeHashes_DirectiveShouldExist()
    {
        // act
        var result = Builder.AllowUnsafeHashes();

        // assert
        result.SourcesInternal.Should().OnlyContain(x => x == "'unsafe-hashes'");
        result.Should().BeSameAs(Builder);
    }

    [Fact]
    public void AllowInlineSpeculationRules_DirectiveShouldExist()
    {
        // act
        var result = Builder.AllowInlineSpeculationRules();

        // assert
        result.SourcesInternal.Should().OnlyContain(x => x == "'inline-speculation-rules'");
        result.Should().BeSameAs(Builder);
    }
}