using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Sidio.Web.Security.AspNetCore.ContentSecurityPolicy;
using Sidio.Web.Security.AspNetCore.Html;
using Sidio.Web.Security.Headers.Cryptography;

namespace Sidio.Web.Security.AspNetCore.Tests.Html;

public sealed class NonceTagHelperTests
{
    private readonly Fixture _fixture = new();

    [Fact]
    public void Process_AddNonceIsFalse_DoesNotSetNonceAttribute()
    {
        // arrange
        var nonceService = new Mock<INonceService>();
        var tagHelper = new NonceTagHelper(nonceService.Object, NullLogger<NonceTagHelper>.Instance)
        {
            AddNonce = false
        };

        var context = new TagHelperContext(
            new TagHelperAttributeList(),
            new Dictionary<object, object>(),
            Guid.NewGuid().ToString("N"));
        var output = new TagHelperOutput(
            "script",
            new TagHelperAttributeList(),
            (_, _) =>
            {
                var tagHelperContent = new DefaultTagHelperContent();
                return Task.FromResult<TagHelperContent>(tagHelperContent);
            });

        // act
        tagHelper.Process(context, output);

        // assert
        output.Attributes.Should().BeEmpty();
    }

    [Fact]
    public void Process_AddNonceIsTrueAndNonceIsNull_LogsWarning()
    {
        // arrange
        var nonceService = new Mock<INonceService>();
        var logger = new Mock<ILogger<NonceTagHelper>>();
        var tagHelper = new NonceTagHelper(nonceService.Object, logger.Object)
        {
            AddNonce = true
        };

        var context = new TagHelperContext(
            new TagHelperAttributeList(),
            new Dictionary<object, object>(),
            Guid.NewGuid().ToString("N"));
        var output = new TagHelperOutput(
            "script",
            new TagHelperAttributeList(),
            (_, _) =>
            {
                var tagHelperContent = new DefaultTagHelperContent();
                return Task.FromResult<TagHelperContent>(tagHelperContent);
            });

        nonceService.Setup(x => x.GetNonce()).Returns((Nonce?) null);

        // act
        tagHelper.Process(context, output);

        // assert
        logger.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception>(),
                ((Func<It.IsAnyType, Exception, string>) It.IsAny<object>())!),
            Times.Once);
    }

    [Fact]
    public void Process_AddNonceIsTrueAndNonceIsNotNull_SetsNonceAttribute()
    {
        // arrange
        var nonceService = new Mock<INonceService>();
        var tagHelper = new NonceTagHelper(nonceService.Object, NullLogger<NonceTagHelper>.Instance)
        {
            AddNonce = true
        };

        var context = new TagHelperContext(
            new TagHelperAttributeList(),
            new Dictionary<object, object>(),
            Guid.NewGuid().ToString("N"));
        var output = new TagHelperOutput(
            "script",
            new TagHelperAttributeList(),
            (_, _) =>
            {
                var tagHelperContent = new DefaultTagHelperContent();
                return Task.FromResult<TagHelperContent>(tagHelperContent);
            });

        var nonce = new Nonce(_fixture.Create<string>());
        nonceService.Setup(x => x.GetNonce()).Returns(nonce);

        // act
        tagHelper.Process(context, output);

        // assert
        output.Attributes.Should().ContainSingle(x => x.Name == "nonce" && x.Value.ToString() == nonce.Value);
    }
}