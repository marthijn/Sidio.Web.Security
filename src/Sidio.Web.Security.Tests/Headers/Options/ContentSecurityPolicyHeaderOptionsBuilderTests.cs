using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Headers.Options.ContentSecurityPolicy;

namespace Sidio.Web.Security.Tests.Headers.Options;

public sealed class ContentSecurityPolicyHeaderOptionsBuilderTests
{
    private readonly Fixture _fixture = new();

    [Fact]
    public void AddDefaultSrc_AllowSelf_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();

        // act
        var result = builder.AddDefaultSrc(x => x.AllowSelf()).Build();

        // assert
        result.DefaultSrc.Should().Be("'self'");
    }

    [Fact]
    public void AddDefaultSrc_AllowAll_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();

        // act
        var result = builder.AddDefaultSrc(x => x.AllowAll()).Build();

        // assert
        result.DefaultSrc.Should().Be("*");
    }

    [Fact]
    public void AddDefaultSrc_AllowUrl_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();
        var url = _fixture.Create<string>();

        // act
        var result = builder.AddDefaultSrc(x => x.AllowUrl(url)).Build();

        // assert
        result.DefaultSrc.Should().Be($"{url}");
    }

    [Fact]
    public void AddDefaultSrc_AllowUrl_Multiple_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();
        var url1 = _fixture.Create<string>();
        var url2 = _fixture.Create<string>();
        var url3 = _fixture.Create<string>();

        // act
        var result = builder.AddDefaultSrc(x => x.AllowUrl(url1).AllowUrl(url2).AllowUrl(url3)).Build();

        // assert
        result.DefaultSrc.Should().Be($"{url1} {url2} {url3}");
    }

    [Fact]
    public void AddDefaultSrc_AllowSelfFormUrl_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();
        var url = _fixture.Create<string>();

        // act
        var result = builder.AddDefaultSrc(x => x.AllowSelf().AllowUrl(url)).Build();

        // assert
        result.DefaultSrc.Should().Be($"'self' {url}");
    }

    [Fact]
    public void AddScriptSrc_AllowSelfAllowStrictDynamic_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();

        // act
        var result = builder.AddScriptSrc(x => x.AllowSelf().AllowStrictDynamic()).Build();

        // assert
        result.ScriptSrc.Should().Be("'self' 'strict-dynamic'");
    }

    [Fact]
    public void AddScriptSrcAttr_AllowSelfAllowStrictDynamic_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();

        // act
        var result = builder.AddScriptSrcAttr(x => x.AllowSelf().AllowStrictDynamic()).Build();

        // assert
        result.ScriptSrcAttr.Should().Be("'self' 'strict-dynamic'");
    }

    [Fact]
    public void AddScriptSrcElem_AllowSelfAllowStrictDynamic_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();

        // act
        var result = builder.AddScriptSrcElem(x => x.AllowSelf().AllowStrictDynamic()).Build();

        // assert
        result.ScriptSrcElem.Should().Be("'self' 'strict-dynamic'");
    }

    [Fact]
    public void AddStyleSrc_AllowAllAllowSelf_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();

        // act
        var result = builder.AddStyleSrc(x => x.AllowAll().AllowSelf()).Build();

        // assert
        result.StyleSrc.Should().Be("* 'self'");
    }

    [Fact]
    public void AddStyleSrcAttr_AllowAllAllowSelf_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();

        // act
        var result = builder.AddStyleSrcAttr(x => x.AllowAll().AllowSelf()).Build();

        // assert
        result.StyleSrcAttr.Should().Be("* 'self'");
    }

    [Fact]
    public void AddStyleSrcElem_AllowAllAllowSelf_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();

        // act
        var result = builder.AddStyleSrcElem(x => x.AllowAll().AllowSelf()).Build();

        // assert
        result.StyleSrcElem.Should().Be("* 'self'");
    }

    [Fact]
    public void AddImgSrc_AllowNone_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();

        // act
        var result = builder.AddImgSrc(x => x.AllowNone()).Build();

        // assert
        result.ImgSrc.Should().Be("'none'");
    }

    [Fact]
    public void AddConnectSrc_AllowNone_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();

        // act
        var result = builder.AddConnectSrc(x => x.AllowNone()).Build();

        // assert
        result.ConnectSrc.Should().Be("'none'");
    }

    [Fact]
    public void AddFontSrc_AllowNone_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();

        // act
        var result = builder.AddFontSrc(x => x.AllowNone()).Build();

        // assert
        result.FontSrc.Should().Be("'none'");
    }

    [Fact]
    public void AddObjectSrc_AllowNone_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();

        // act
        var result = builder.AddObjectSrc(x => x.AllowNone()).Build();

        // assert
        result.ObjectSrc.Should().Be("'none'");
    }

    [Fact]
    public void AddMediaSrc_AllowNone_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();

        // act
        var result = builder.AddMediaSrc(x => x.AllowNone()).Build();

        // assert
        result.MediaSrc.Should().Be("'none'");
    }

    [Fact]
    public void AddFrameSrc_AllowNone_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();

        // act
        var result = builder.AddFrameSrc(x => x.AllowNone()).Build();

        // assert
        result.FrameSrc.Should().Be("'none'");
    }

    [Fact]
    public void AddChildSrc_AllowNone_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();

        // act
        var result = builder.AddChildSrc(x => x.AllowNone()).Build();

        // assert
        result.ChildSrc.Should().Be("'none'");
    }

    [Fact]
    public void AddFormAction_AllowNone_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();

        // act
        var result = builder.AddFormAction(x => x.AllowNone()).Build();

        // assert
        result.FormAction.Should().Be("'none'");
    }

    [Fact]
    public void AddBaseUri_AllowNone_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();

        // act
        var result = builder.AddBaseUri(x => x.AllowNone()).Build();

        // assert
        result.BaseUri.Should().Be("'none'");
    }

    [Fact]
    public void AddWorkerSrc_AllowNone_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();

        // act
        var result = builder.AddWorkerSrc(x => x.AllowNone()).Build();

        // assert
        result.WorkerSrc.Should().Be("'none'");
    }

    [Fact]
    public void AddManifestSrc_AllowNone_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();

        // act
        var result = builder.AddManifestSrc(x => x.AllowNone()).Build();

        // assert
        result.ManifestSrc.Should().Be("'none'");
    }

    [Fact]
    [Obsolete("Directive is obsolete")]
    public void AddPrefetchSrc_AllowNone_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();

        // act
        var result = builder.AddPrefetchSrc(x => x.AllowNone()).Build();

        // assert
        result.PrefetchSrc.Should().Be("'none'");
    }

    [Fact]
    public void AddFencedFrameSrc_AllowNone_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();

        // act
        var result = builder.AddFencedFrameSrc(x => x.AllowNone()).Build();

        // assert
        result.FencedFrameSrc.Should().Be("'none'");
    }

    [Theory]
    [InlineData(Sandbox.None, "")]
    [InlineData(Sandbox.AllowDownloads, "allow-downloads")]
    public void AddSandbox_GivenValue_DirectiveShouldExist(Sandbox sandbox, string expected)
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();

        // act
        var result = builder.AddSandbox(sandbox).Build();

        // assert
        result.Sandbox.Should().Be(expected);
    }

    [Fact]
    [Obsolete("Directive is obsolete")]
    public void AddReportUri_WithoutUrl_ThrowException()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();

        // act
        var action = () => builder.AddReportUri().Build();

        // assert
        action.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [Obsolete("Directive is obsolete")]
    public void AddReportUri_WithUrl_DirectiveShouldExist(int numberOfUrls)
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();
        var urls = _fixture.CreateMany<string>(numberOfUrls).ToArray();

        // act
        var result = builder.AddReportUri(urls).Build();

        // assert
        result.ReportUri.Should().ContainAll(urls);
    }

    [Fact]
    public void SetFrameAncestors_WithoutSource_ThrowException()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();

        // act
        var action = () => builder.SetFrameAncestors().Build();

        // assert
        action.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void SetFrameAncestors_WithUrl_DirectiveShouldExist(int numberOfSources)
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();
        var sources = _fixture.CreateMany<string>(numberOfSources).ToArray();

        // act
        var result = builder.SetFrameAncestors(sources).Build();

        // assert
        result.FrameAncestors.Should().ContainAll(sources);
    }

    [Fact]
    public void AddReportTo_WithoutGroupName_ThrowException()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();

        // act
        var action = () => builder.AddReportTo(null!).Build();

        // assert
        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void AddReportTo_WithGroupName_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();
        var groupName = _fixture.Create<string>();

        // act
        var result = builder.AddReportTo(groupName).Build();

        // assert
        result.ReportTo.Should().Be(groupName);
    }

    [Fact]
    public void RequireTrustedTypesForScript_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();

        // act
        var result = builder.RequireTrustedTypesForScript().Build();

        // assert
        result.RequireTrustedTypesFor.Should().Be("'script'");
    }

    [Theory]
    [InlineData(false, null, "")]
    [InlineData(true, null, "'allow-duplicates'")]
    [InlineData(true, "policy", "policy 'allow-duplicates'")]
    [InlineData(false, "policy", "policy")]
    public void AddTrustedTypes_GivenValue_DirectiveShouldExist(bool allowDuplicates, string? policyName, string expected)
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();

        // act
        var result = builder.AddTrustedTypes(allowDuplicates, policyName!).Build();

        // assert
        result.TrustedTypes.Should().Be(expected);
    }

    [Fact]
    public void AddTrustedTypes_GivenMuliplePolicies_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();
        var policies = _fixture.CreateMany<string>().ToArray();

        // act
        var result = builder.AddTrustedTypes(policyNames: policies).Build();

        // assert
        result.TrustedTypes.Should().ContainAll(policies);
    }

    [Fact]
    public void UpgradeInsecureRequests_DirectiveShouldExist()
    {
        // arrange
        var builder = new ContentSecurityPolicyHeaderOptionsBuilder();

        // act
        var result = builder.UpgradeInsecureRequests().Build();

        // assert
        result.UpgradeInsecureRequests.Should().BeTrue();
    }
}