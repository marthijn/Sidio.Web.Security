using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.Tests.Headers.Options;

public sealed class XXssProtectionHeaderOptionsTests
{
    private readonly Fixture _fixture = new ();

    [Fact]
    public void ToString_WithDefaultValues_ReturnsExpected()
    {
        // Arrange
        var options = new XXssProtectionHeaderOptions();

        // Act
        var result = options.ToString();

        // Assert
        result.Should().Be("1");
        result.Should().BeEquivalentTo(options.Value);
    }

    [Fact]
    public void ToString_HeaderDisabled_ReturnsExpected()
    {
        // Arrange
        var options = new XXssProtectionHeaderOptions
        {
            Enabled = false,
            Block = true,
        };

        // Act
        var result = options.ToString();

        // Assert
        result.Should().Be("0");
        result.Should().BeEquivalentTo(options.Value);
    }

    [Fact]
    public void ToString_WithModeBlock_ReturnsExpected()
    {
        // Arrange
        var options = new XXssProtectionHeaderOptions
        {
            Block = true,
            ReportUri = _fixture.Create<string>(),
        };

        // Act
        var result = options.ToString();

        // Assert
        result.Should().Be("1; mode=block");
        result.Should().BeEquivalentTo(options.Value);
    }

    [Fact]
    public void ToString_WithReportUri_ReturnsExpected()
    {
        // Arrange
        var options = new XXssProtectionHeaderOptions
        {
            ReportUri = _fixture.Create<string>(),
        };

        // Act
        var result = options.ToString();

        // Assert
        result.Should().Be($"1; report={options.ReportUri}");
        result.Should().BeEquivalentTo(options.Value);
    }
}