using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.Tests.Headers.Options;

public sealed class PermissionsPolicyHeaderOptionsBuilderTests
{
    [Fact]
    public void Build_AddAccelerometer_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddAccelerometer(x => x.AllowAll()).Build();

        // Assert
        result.Accelerometer.Should().NotBeNullOrEmpty();
    }
}