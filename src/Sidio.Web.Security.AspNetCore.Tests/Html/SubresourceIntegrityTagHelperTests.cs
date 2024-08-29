using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Sidio.Web.Security.AspNetCore.Html;
using Sidio.Web.Security.Cryptography;

namespace Sidio.Web.Security.AspNetCore.Tests.Html;

public sealed class SubresourceIntegrityTagHelperTests
{
    private readonly Fixture _fixture = new();

    [Fact]
    public async Task ProcessAsync_WhenIntegrityAttributeExists_DoesNotAddIntegrityAttribute()
    {
        // arrange
        var tagHelper = CreateTagHelper(out _, out _, new TagHelperOptions { AutoApplySubresourceIntegrity = true });
        var context = CreateTagHelperContext("script", [new("integrity", "sha256-abc")]);
        var output = CreateTagHelperOutput();

        // act
        await tagHelper.ProcessAsync(context, output);

        // assert
        output.Attributes.Should().NotContain(x => x.Name == "integrity");
        output.Attributes.Should().NotContain(x => x.Name == "crossorigin");
    }

    [Fact]
    public async Task ProcessAsync_WhenAutoApplyIsFalseAndAddSubresourceIntegrityIsFalse_DoesNotAddIntegrityAttribute()
    {
        // arrange
        var tagHelper = CreateTagHelper(out _, out _);
        var context = CreateTagHelperContext("script");
        var output = CreateTagHelperOutput();

        // act
        await tagHelper.ProcessAsync(context, output);

        // assert
        output.Attributes.Should().NotContain(x => x.Name == "integrity");
        output.Attributes.Should().NotContain(x => x.Name == "crossorigin");
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public async Task ProcessAsync_WhenUrlIsEmpty_DoesNotAddIntegrityAttribute(string? url)
    {
        // arrange
        var tagHelper = CreateTagHelper(out _, out _, new TagHelperOptions { AutoApplySubresourceIntegrity = true });
        var context = CreateTagHelperContext("script", [new("src", url)]);
        var output = CreateTagHelperOutput();

        // act
        await tagHelper.ProcessAsync(context, output);

        // assert
        output.Attributes.Should().NotContain(x => x.Name == "integrity");
        output.Attributes.Should().NotContain(x => x.Name == "crossorigin");
    }

    [Theory]
    [InlineData("/script.js")]
    [InlineData("script.js")]
    public async Task ProcessAsync_WhenUrlIsRelative_DoesNotAddIntegrityAttribute(string? url)
    {
        // arrange
        var tagHelper = CreateTagHelper(out _, out _, new TagHelperOptions { AutoApplySubresourceIntegrity = true });
        var context = CreateTagHelperContext("script", [new("src", url)]);
        var output = CreateTagHelperOutput();

        // act
        await tagHelper.ProcessAsync(context, output);

        // assert
        output.Attributes.Should().NotContain(x => x.Name == "integrity");
        output.Attributes.Should().NotContain(x => x.Name == "crossorigin");
    }

    [Theory]
    [InlineData("script", "src")]
    [InlineData("link", "href")]
    public async Task ProcessAsync_WhenIntegrityAttributeDoesNotExist_AddsIntegrityAttribute(string tagName, string attributeName)
    {
        // arrange
        const string Url = "https://example.com/script.js";
        var hash = _fixture.Create<string>();
        var tagHelper = CreateTagHelper(out var hashService, out _, new TagHelperOptions { AutoApplySubresourceIntegrity = true });
        var context = CreateTagHelperContext(tagName, [new(attributeName, Url)]);
        var output = CreateTagHelperOutput();

        hashService.Setup(x => x.GetIntegrityHashFromUrlAsync(new Uri(Url), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new SubresourceIntegrityHash(true, hash));

        // act
        await tagHelper.ProcessAsync(context, output);

        // assert
        output.Attributes.Should().Contain(x => x.Name == "integrity").Which.Value.Should().Be(hash);
        output.Attributes.Should().Contain(x => x.Name == "crossorigin").Which.Value.Should().Be("anonymous");
    }

    [Theory]
    [InlineData("script", "src")]
    [InlineData("link", "href")]
    public async Task ProcessAsync_WhenIntegrityAttributeDoesNotExistAndAutoApplyIsFalse_AddsIntegrityAttribute(string tagName, string attributeName)
    {
        // arrange
        const string Url = "https://example.com/script.js";
        var hash = _fixture.Create<string>();
        var tagHelper = CreateTagHelper(out var hashService, out _, addSubresourceIntegrity: true);
        var context = CreateTagHelperContext(tagName, [new(attributeName, Url)]);
        var output = CreateTagHelperOutput();

        hashService.Setup(x => x.GetIntegrityHashFromUrlAsync(new Uri(Url), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new SubresourceIntegrityHash(true, hash));

        // act
        await tagHelper.ProcessAsync(context, output);

        // assert
        output.Attributes.Should().Contain(x => x.Name == "integrity").Which.Value.Should().Be(hash);
        output.Attributes.Should().Contain(x => x.Name == "crossorigin").Which.Value.Should().Be("anonymous");
    }

    [Theory]
    [InlineData("http")]
    [InlineData("https")]
    public async Task ProcessAsync_WhenIntegrityAttributeDoesNotExistAndUrlHasNoScheme_AddsIntegrityAttribute(string scheme)
    {
        // arrange
        const string Url = "//example.com/script.js";
        var hash = _fixture.Create<string>();
        var tagHelper = CreateTagHelper(
            out var hashService,
            out var viewContext,
            new TagHelperOptions {AutoApplySubresourceIntegrity = true});
        viewContext.HttpContext.Request.Scheme = scheme;
        var context = CreateTagHelperContext("script", [new("src", Url)]);
        var output = CreateTagHelperOutput();

        hashService.Setup(x => x.GetIntegrityHashFromUrlAsync(new Uri(scheme + ":" + Url), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new SubresourceIntegrityHash(true, hash));

        // act
        await tagHelper.ProcessAsync(context, output);

        // assert
        output.Attributes.Should().Contain(x => x.Name == "integrity").Which.Value.Should().Be(hash);
        output.Attributes.Should().Contain(x => x.Name == "crossorigin").Which.Value.Should().Be("anonymous");
    }

    private static SubresourceIntegrityTagHelper CreateTagHelper(
        out Mock<ISubresourceIntegrityHashService> hashService,
        out TestViewContext viewContext,
        TagHelperOptions? options = null,
        bool addSubresourceIntegrity = false)
    {
        hashService = new Mock<ISubresourceIntegrityHashService>();
        viewContext = new TestViewContext();

        return new SubresourceIntegrityTagHelper(
            hashService.Object,
            Options.Create(options ?? new TagHelperOptions()),
            NullLogger<SubresourceIntegrityTagHelper>.Instance)
        {
            ViewContext = viewContext,
            AddSubresourceIntegrity = addSubresourceIntegrity,
        };
    }

    private static TagHelperContext CreateTagHelperContext(string tagName, TagHelperAttributeList? attributes = null)
    {
        return new TagHelperContext(
            tagName,
            attributes ?? [],
            new Dictionary<object, object>(),
            Guid.NewGuid().ToString("N"));
    }

    private static TagHelperOutput CreateTagHelperOutput()
    {
        return new TagHelperOutput(
            "script",
            new TagHelperAttributeList(),
            (_, _) =>
            {
                var tagHelperContent = new DefaultTagHelperContent();
                return Task.FromResult<TagHelperContent>(tagHelperContent);
            });
    }

    private sealed class TestViewContext : ViewContext
    {
        public TestViewContext(string scheme = "https")
        {
            HttpContext = new DefaultHttpContext
            {
                Request = { Scheme = scheme, Host = new HostString("example.com") },
            };
        }
    }
}