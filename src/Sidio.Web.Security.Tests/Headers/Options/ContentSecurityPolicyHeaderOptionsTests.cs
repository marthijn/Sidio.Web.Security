using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.Tests.Headers.Options;

public sealed class ContentSecurityPolicyHeaderOptionsTests
{
    private readonly Fixture _fixture = new();

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void ToString_ShouldReturnPolicy(bool includeBooleanProperties)
    {
        // arrange
        var options = _fixture.Build<ContentSecurityPolicyHeaderOptions>()
            .With(x => x.BlockAllMixedContent, includeBooleanProperties)
            .With(x => x.UpgradeInsecureRequests, includeBooleanProperties)
            .Create();

        // act
        var result = options.ToString();

        // assert
        result.Should().NotBeNullOrWhiteSpace();
        result.Should().BeEquivalentTo(options.Value);

        result.Should().Contain($"default-src {options.DefaultSrc}");
        result.Should().Contain($"script-src {options.ScriptSrc}");
        result.Should().Contain($"script-src-attr {options.ScriptSrcAttr}");
        result.Should().Contain($"script-src-elem {options.ScriptSrcElem}");
        result.Should().Contain($"style-src {options.StyleSrc}");
        result.Should().Contain($"style-src-attr {options.StyleSrcAttr}");
        result.Should().Contain($"style-src-elem {options.StyleSrcElem}");
        result.Should().Contain($"img-src {options.ImgSrc}");
        result.Should().Contain($"connect-src {options.ConnectSrc}");
        result.Should().Contain($"font-src {options.FontSrc}");
        result.Should().Contain($"object-src {options.ObjectSrc}");
        result.Should().Contain($"media-src {options.MediaSrc}");
        result.Should().Contain($"frame-src {options.FrameSrc}");
        result.Should().Contain($"child-src {options.ChildSrc}");
        result.Should().Contain($"worker-src {options.WorkerSrc}");
        result.Should().Contain($"form-action {options.FormAction}");
        result.Should().Contain($"frame-ancestors {options.FrameAncestors}");
        result.Should().Contain($"base-uri {options.BaseUri}");
        result.Should().Contain($"fenced-frame-src {options.FencedFrameSrc}");
        result.Should().Contain($"sandbox {options.Sandbox}");
        result.Should().Contain($"report-to {options.ReportTo}");
        result.Should().Contain($"require-trusted-types-for {options.RequireTrustedTypesFor}");
        result.Should().Contain($"trusted-types {options.TrustedTypes}");
        result.Should().Contain($"navigate-to {options.NavigateTo}");

#pragma warning disable CS0618 // Type or member is obsolete
        result.Should().Contain($"prefetch-src {options.PrefetchSrc}");
        result.Should().Contain($"report-uri {options.ReportUri}");
#pragma warning restore CS0618 // Type or member is obsolete

        if (includeBooleanProperties)
        {
            result.Should().Contain("upgrade-insecure-requests");
            result.Should().Contain("block-all-mixed-content");
        }
        else
        {
            result.Should().NotContain("upgrade-insecure-requests");
            result.Should().NotContain("block-all-mixed-content");
        }
    }
}