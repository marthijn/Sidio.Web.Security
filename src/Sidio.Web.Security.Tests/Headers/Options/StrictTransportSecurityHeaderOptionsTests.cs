using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.Tests.Headers.Options;

public sealed class StrictTransportSecurityHeaderOptionsTests
{
    private const string TwoYears = "63072000";

    [Fact]
    public void ToString_IncludeSubDomainsIsTrueAndPreloadIsTrue_ReturnsValue()
    {
        // arrange
        var options = new StrictTransportSecurityHeaderOptions
        {
            IncludeSubDomains = true,
            Preload = true,
            MaxAge = 1
        };

        // act
        var result = options.ToString();

        // assert
        result.Should().Be("max-age=1; includeSubDomains; preload");
        result.Should().BeEquivalentTo(options.Value);
    }

    [Fact]
    public void ToString_IncludeSubDomainsIsFalseAndPreloadIsFalse_ReturnsValue()
    {
        // arrange
        var options = new StrictTransportSecurityHeaderOptions
        {
            IncludeSubDomains = false,
            Preload = false
        };

        // act
        var result = options.ToString();

        // assert
        result.Should().Be($"max-age={TwoYears}");
        result.Should().BeEquivalentTo(options.Value);
    }

    [Fact]
    public void ToString_IncludeSubDomainsIsTrueAndPreloadIsFalse_ReturnsValue()
    {
        // arrange
        var options = new StrictTransportSecurityHeaderOptions
        {
            IncludeSubDomains = true,
            Preload = false
        };

        // act
        var result = options.ToString();

        // assert
        result.Should().Be($"max-age={TwoYears}; includeSubDomains");
        result.Should().BeEquivalentTo(options.Value);
    }

    [Fact]
    public void ToString_IncludeSubDomainsIsFalseAndPreloadIsTrue_ReturnsValue()
    {
        // arrange
        var options = new StrictTransportSecurityHeaderOptions
        {
            IncludeSubDomains = false,
            Preload = true
        };

        // act
        var result = options.ToString();

        // assert
        result.Should().Be($"max-age={TwoYears}; preload");
        result.Should().BeEquivalentTo(options.Value);
    }
}