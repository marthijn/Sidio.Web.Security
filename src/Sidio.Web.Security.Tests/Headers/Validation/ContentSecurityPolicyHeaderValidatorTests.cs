using System.Collections;
using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Headers.Options.ContentSecurityPolicy;
using Sidio.Web.Security.Headers.Validation;

namespace Sidio.Web.Security.Tests.Headers.Validation;

public sealed class ContentSecurityPolicyHeaderValidatorTests : HeaderValidatorTests<ContentSecurityPolicyHeaderOptions>
{
#if NET6_0_OR_GREATER
    private readonly Random _random = Random.Shared;
#else
    private readonly Random _random = new();
#endif

    private readonly Fixture _fixture = new();

    protected override IHeaderValidator<ContentSecurityPolicyHeaderOptions> Validator =>
        new ContentSecurityPolicyHeaderValidator();

    [Theory]
    [ClassData(typeof(DirectiveDataGenerator))]
    public void Validate_GivenSrcDirective_ShouldReturnValidOptionsValue(string propertyName, string directive, string? expectedValue)
    {
        // act
        var result = Validator.Validate(directive, out var options);

        // assert
        result.IsValid.Should().BeTrue();
        options.Should().NotBeNull();

        var propertyValue = options!.GetType().GetProperty(propertyName)!.GetValue(options, null);
        propertyValue.Should().Be(expectedValue);
    }

    [Theory]
    [InlineData(
        nameof(ContentSecurityPolicyHeaderOptions.ReportUri),
        "report-uri https://example.com",
        "https://example.com")]
    [InlineData(
        nameof(ContentSecurityPolicyHeaderOptions.PrefetchSrc),
        "prefetch-src https://example.com",
        "https://example.com")]
    [InlineData(
        nameof(ContentSecurityPolicyHeaderOptions.NavigateTo),
        "navigate-to https://example.com",
        "https://example.com")]
    [InlineData(
        nameof(ContentSecurityPolicyHeaderOptions.UpgradeInsecureRequests),
        "upgrade-insecure-requests",
        true)]
    [InlineData(
        nameof(ContentSecurityPolicyHeaderOptions.BlockAllMixedContent),
        "block-all-mixed-content",
        true)]
    public void Validate_DeprecatedOrUnOfficialDirectives_ShouldReturnWarning(
        string propertyName,
        string directive,
        object expectedValue)
    {
        // act
        var result = Validator.Validate(directive, out var options);

        // assert
        result.IsValid.Should().BeTrue();
        result.HasWarnings.Should().BeTrue();
        options.Should().NotBeNull();

        var propertyValue = options!.GetType().GetProperty(propertyName)!.GetValue(options, null);
        propertyValue.Should().Be(expectedValue);
    }

    [Fact]
    public void Validate_GivenValidSandboxValue_ShouldReturnValidOptionsValue()
    {
        // act
        var randomSandboxValue = ContentSecurityPolicyHeaderValidator.AllowedSandboxTokens[_random.Next(
            0,
            ContentSecurityPolicyHeaderValidator.AllowedSandboxTokens.Length)];
        var result = Validator.Validate($"sandbox {randomSandboxValue}", out var options);

        // assert
        result.IsValid.Should().BeTrue();
        options.Should().NotBeNull();
        options!.Sandbox.Should().BeEquivalentTo(randomSandboxValue);
    }

    [Fact]
    public void Validate_GivenInvalidSandboxValue_OptionsShouldBeNull()
    {
        // act
        var result = Validator.Validate($"sandbox {_fixture.Create<string>()}", out var options);

        // assert
        result.IsValid.Should().BeFalse();
        options.Should().BeNull();
    }

    [Fact]
    public void Validate_GivenValidReportToValue_ShouldReturnValidOptionsValue()
    {
        // act
        var reportTo = _fixture.Create<string>();
        var result = Validator.Validate($"report-to {reportTo}", out var options);

        // assert
        result.IsValid.Should().BeTrue();
        options.Should().NotBeNull();
        options!.ReportTo.Should().BeEquivalentTo(reportTo);
    }

    [Fact]
    public void Validate_GivenInvalidReportToValue_OptionsShouldBeNull()
    {
        // act
        var result = Validator.Validate("report-to https://example.com", out var options);

        // assert
        result.IsValid.Should().BeFalse();
        options.Should().BeNull();
    }

    [Fact]
    public void Validate_GivenValidPluginTypesValue_ShouldReturnValidOptionsValue()
    {
        // act
        const string MimeType = "application/pdf";
        var result = Validator.Validate($"plugin-types {MimeType}", out var options);

        // assert
        result.IsValid.Should().BeTrue();
        options.Should().NotBeNull();
        options!.PluginTypes.Should().BeEquivalentTo(MimeType);
    }

    [Fact]
    public void Validate_GivenInvalidPluginTypesValue_OptionsShouldBeNull()
    {
        // act
        var result = Validator.Validate("plugin-types https://example.com", out var options);

        // assert
        result.IsValid.Should().BeFalse();
        options.Should().BeNull();
    }


    private sealed class DirectiveDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object?[]> _data = new();

        public DirectiveDataGenerator()
        {
            AddDirective(nameof(ContentSecurityPolicyHeaderOptions.DefaultSrc), Directives.DefaultSrc);
            AddDirective(nameof(ContentSecurityPolicyHeaderOptions.ScriptSrc), Directives.ScriptSrc);
            AddDirective(nameof(ContentSecurityPolicyHeaderOptions.ImgSrc), Directives.ImgSrc);
            AddDirective(nameof(ContentSecurityPolicyHeaderOptions.ConnectSrc), Directives.ConnectSrc);
            AddDirective(nameof(ContentSecurityPolicyHeaderOptions.FontSrc), Directives.FontSrc);
            AddDirective(nameof(ContentSecurityPolicyHeaderOptions.ObjectSrc), Directives.ObjectSrc);
            AddDirective(nameof(ContentSecurityPolicyHeaderOptions.MediaSrc), Directives.MediaSrc);
            AddDirective(nameof(ContentSecurityPolicyHeaderOptions.FrameSrc), Directives.FrameSrc);
            AddDirective(nameof(ContentSecurityPolicyHeaderOptions.ChildSrc), Directives.ChildSrc);
            AddDirective(nameof(ContentSecurityPolicyHeaderOptions.WorkerSrc), Directives.WorkerSrc);
            AddDirective(nameof(ContentSecurityPolicyHeaderOptions.ManifestSrc), Directives.ManifestSrc);
            AddDirective(nameof(ContentSecurityPolicyHeaderOptions.PrefetchSrc), Directives.PrefetchSrc);
            AddDirective(nameof(ContentSecurityPolicyHeaderOptions.FormAction), Directives.FormAction);
            AddDirective(nameof(ContentSecurityPolicyHeaderOptions.FrameAncestors), Directives.FrameAncestors);
            AddDirective(nameof(ContentSecurityPolicyHeaderOptions.BaseUri), Directives.BaseUri);
            AddDirective(nameof(ContentSecurityPolicyHeaderOptions.FencedFrameSrc), Directives.FencedFrameSrc);
        }

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void AddDirective(string propertyName, string directive)
        {
            _data.AddRange([
                [propertyName, $"{directive}", null],
                [propertyName, $"{directive} 'self'", "'self'"],
                [propertyName, $"{directive} 'self';", "'self'"],
                [propertyName, $"{directive} 'self' 'unsafe-inline'", "'self' 'unsafe-inline'"],
                [propertyName, $"{directive} 'self' cdn1.example.com cdn2.example-website.nl", "'self' cdn1.example.com cdn2.example-website.nl"],
                [propertyName, $"{directive} *", "*"],
                [propertyName, $"{directive} data: blob:", "data: blob:"],
            ]);
        }
    }
}