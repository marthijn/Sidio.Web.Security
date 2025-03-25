using Sidio.Web.Security.Headers.Options.PermissionsPolicy;

namespace Sidio.Web.Security.Tests.Headers.Options.PermissionsPolicy;

public sealed class DirectiveValueBuilderTests
{
    [Fact]
    public void Build_NothingSpecified_ReturnsNull()
    {
        // Arrange
        var builder = new DirectiveValueBuilder();

        // Act
        var result = builder.Build();

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public void Build_AddSelf_ReturnsValue()
    {
        // Arrange
        var builder = new DirectiveValueBuilder();

        // Act
        var result = builder.AddSelf().Build();

        // Assert
        result.Should().Be("(self)");
    }

    [Fact]
    public void Build_AddOrigin_ReturnsValue()
    {
        // Arrange
        var builder = new DirectiveValueBuilder();
        const string Origin1 = "https://example.com";
        const string Origin2 = "https://*.example2.com";

        // Act
        var result = builder.AddOrigin(Origin1).AddOrigin(Origin2).Build();

        // Assert
        result.Should().Be($"({Origin1} {Origin2})");
    }

    [Fact]
    public void Build_AllowAll_ReturnsValue()
    {
        // Arrange
        var builder = new DirectiveValueBuilder();

        // Act
        var result = builder.AllowAll().Build();

        // Assert
        result.Should().Be("*");
    }

    [Fact]
    public void Build_AllowNone_ReturnsValue()
    {
        // Arrange
        var builder = new DirectiveValueBuilder();

        // Act
        var result = builder.AllowNone().Build();

        // Assert
        result.Should().Be("()");
    }
}