using Sidio.Web.Security.Headers.Options.ContentSecurityPolicy;

namespace Sidio.Web.Security.Tests.Headers.Options.ContentSecurityPolicy;

public abstract class SrcBuilderBaseTests<T>
    where T : SrcBuilderBase<T>, new()
{
    private readonly Fixture _fixture = new();

    protected readonly T Builder;

    protected SrcBuilderBaseTests()
    {
        Builder = new T();
    }

    [Fact]
    public void AllowSelf_DirectiveShouldExist()
    {
        // act
        var result = Builder.AllowSelf();

        // assert
        result.SourcesInternal.Should().ContainSingle("'self'");
        result.Should().BeSameAs(Builder);
    }

    [Fact]
    public void AllowAll_DirectiveShouldExist()
    {
        // act
        var result = Builder.AllowAll();

        // assert
        result.SourcesInternal.Should().ContainSingle("*");
        result.Should().BeSameAs(Builder);
    }

    [Fact]
    public void AllowUrl_DirectiveShouldExist()
    {
        // arrange
        var url = _fixture.Create<string>();

        // act
        var result = Builder.AllowUrl(url);

        // assert
        result.SourcesInternal.Should().ContainSingle(url);
        result.Should().BeSameAs(Builder);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void AllowUrl_GivenEmptyUrl_ShouldThrowException(string? url)
    {
        // act
        var action = () => Builder.AllowUrl(url!);

        // assert
        action.Should().ThrowExactly<ArgumentException>();
    }

    [Fact]
    public void AllowNone_DirectiveShouldExist()
    {
        // act
        var result = Builder.AllowNone();

        // assert
        result.SourcesInternal.Should().ContainSingle("'none'");
        result.Should().BeSameAs(Builder);
    }

    [Fact]
    public void AllowData_DirectiveShouldExist()
    {
        // act
        var result = Builder.AllowData();

        // assert
        result.SourcesInternal.Should().ContainSingle("data:");
        result.Should().BeSameAs(Builder);
    }

    [Fact]
    public void AllowUnsafeInline_DirectiveShouldExist()
    {
        // act
        var result = Builder.AllowUnsafeInline();

        // assert
        result.SourcesInternal.Should().ContainSingle("'unsafe-inline'");
        result.Should().BeSameAs(Builder);
    }

    [Fact]
    public void AllowHttp_DirectiveShouldExist()
    {
        // act
        var result = Builder.AllowHttp();

        // assert
        result.SourcesInternal.Should().ContainSingle("http:");
        result.Should().BeSameAs(Builder);
    }

    [Fact]
    public void AllowHttps_DirectiveShouldExist()
    {
        // act
        var result = Builder.AllowHttps();

        // assert
        result.SourcesInternal.Should().ContainSingle("https:");
        result.Should().BeSameAs(Builder);
    }

    [Fact]
    public void AllowMediaStream_DirectiveShouldExist()
    {
        // act
        var result = Builder.AllowMediaStream();

        // assert
        result.SourcesInternal.Should().ContainSingle("mediastream:");
        result.Should().BeSameAs(Builder);
    }

    [Fact]
    public void AllowBlob_DirectiveShouldExist()
    {
        // act
        var result = Builder.AllowBlob();

        // assert
        result.SourcesInternal.Should().ContainSingle("blob:");
        result.Should().BeSameAs(Builder);
    }

    [Fact]
    public void AllowFileSystem_DirectiveShouldExist()
    {
        // act
        var result = Builder.AllowFileSystem();

        // assert
        result.SourcesInternal.Should().ContainSingle("filesystem:");
        result.Should().BeSameAs(Builder);
    }

    [Fact]
    public void ShouldReportSample_DirectiveShouldExist()
    {
        // act
        var result = Builder.ShouldReportSample();

        // assert
        result.SourcesInternal.Should().ContainSingle("'report-sample'");
        result.Should().BeSameAs(Builder);
    }

    [Fact]
    public void AllowDuplicates_DirectiveShouldExist()
    {
        // act
        var result = Builder.AllowDuplicates();

        // assert
        result.SourcesInternal.Should().ContainSingle("'allow-duplicates'");
        result.Should().BeSameAs(Builder);
    }

    [Fact]
    public void ToString_ShouldReturnCorrectValue()
    {
        // arrange
        var url = _fixture.Create<string>();
        Builder.AllowSelf().AllowAll().AllowUrl(url).AllowData().ShouldReportSample();

        // act
        var result = Builder.ToString();

        // assert
        result.Should().Be($"'self' * {url} data: 'report-sample'");
    }
}