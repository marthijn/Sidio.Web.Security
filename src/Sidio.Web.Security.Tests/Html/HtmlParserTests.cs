using Sidio.Web.Security.Html;

namespace Sidio.Web.Security.Tests.Html;

public sealed class HtmlParserTests
{
    [Fact]
    public void ExtractScriptTags_WhenHtmlContainsSingleScriptTags_ReturnsScriptTags()
    {
        // arrange
        const string Html = "<html><head><script src=\"https://example.com/script.js\" nonce=\"P9jNv6Gyc8Syof-tqo9CqnFKQCEfl8D_QmEIQpZntE0\" integrity=\"sha256-Fb0zP4jE3JHqu&#x2B;IBB9YktLcSjI1Zc6J2b6gTjB0LpoM=\" crossorigin=\"anonymous\"></script></head></html>";

        // act
        var result = HtmlParser.ExtractScriptTags(Html).ToList();

        // assert
        result.Should().HaveCount(1);
        result[0].Src.Should().Be("https://example.com/script.js");
        result[0].Nonce.Should().Be("P9jNv6Gyc8Syof-tqo9CqnFKQCEfl8D_QmEIQpZntE0");
        result[0].Integrity.Should().Be("sha256-Fb0zP4jE3JHqu&#x2B;IBB9YktLcSjI1Zc6J2b6gTjB0LpoM=");
        result[0].CrossOrigin.Should().Be("anonymous");
    }

    [Fact]
    public void ExtractScriptTags_WhenHtmlContainsMulipleScriptTags_ReturnsScriptTags()
    {
        // arrange
        const string Html = "<html><head><script src=\"https://example.com/script.js\" nonce=\"P9jNv6Gyc8Syof-tqo9CqnFKQCEfl8D_QmEIQpZntE0\" integrity=\"sha256-Fb0zP4jE3JHqu&#x2B;IBB9YktLcSjI1Zc6J2b6gTjB0LpoM=\" crossorigin=\"anonymous\"></script><script></script></head></html>";

        // act
        var result = HtmlParser.ExtractScriptTags(Html).ToList();

        // assert
        result.Should().HaveCount(2);
    }

    [Theory]
    [InlineData("<script></script>", null, null, null, null, null)]
    [InlineData("<script>alert(1);</script>", null, null, null, null, "alert(1);")]
    [InlineData("<script src=\"a\"></script>", "a", null, null, null, null)]
    [InlineData("<script nonce=\"a\"></script>", null,"a",  null, null, null)]
    [InlineData("<script integrity=\"a\"></script>", null, null,"a", null, null)]
    [InlineData("<script crossorigin=\"a\"></script>", null, null, null, "a", null)]
    [InlineData("<script crossorigin=\"d\" integrity=\"c\" nonce=\"b\" src=\"a\"></script>", "a", "b", "c", "d", null)]
    [InlineData("<script  crossorigin=\"d\"   integrity=\"c\"    nonce=\"b\"    src=\"a\"  ></script>", "a", "b", "c", "d", null)]
    public void ExtractScriptTags_TestCases_ReturnsScriptTags(
        string input,
        string? src,
        string? nonce,
        string? integrity,
        string? crossOrigin,
        string? content)
    {
        // act
        var result = HtmlParser.ExtractScriptTags(input).ToList();

        // assert
        result.Should().HaveCount(1);
        result[0].Src.Should().Be(src);
        result[0].Nonce.Should().Be(nonce);
        result[0].Integrity.Should().Be(integrity);
        result[0].CrossOrigin.Should().Be(crossOrigin);
        result[0].Content.Should().Be(content);
    }
}