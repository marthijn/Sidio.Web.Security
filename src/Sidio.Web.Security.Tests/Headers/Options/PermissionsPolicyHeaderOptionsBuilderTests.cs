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

    [Fact]
    public void Build_AddAmbientLightSensor_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddAmbientLightSensor(x => x.AllowAll()).Build();

        // Assert
        result.AmbientLightSensor.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddAttributionReporting_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddAttributionReporting(x => x.AllowAll()).Build();

        // Assert
        result.AttributionReporting.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddAutoplay_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddAutoplay(x => x.AllowAll()).Build();

        // Assert
        result.Autoplay.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddBluetooth_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddBluetooth(x => x.AllowAll()).Build();

        // Assert
        result.Bluetooth.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddBrowsingTopics_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddBrowsingTopics(x => x.AllowAll()).Build();

        // Assert
        result.BrowsingTopics.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddCamera_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddCamera(x => x.AllowAll()).Build();

        // Assert
        result.Camera.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddComputePressure_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddComputePressure(x => x.AllowAll()).Build();

        // Assert
        result.ComputePressure.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddCrossOriginIsolated_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddCrossOriginIsolated(x => x.AllowAll()).Build();

        // Assert
        result.CrossOriginIsolated.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddDisplayCapture_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddDisplayCapture(x => x.AllowAll()).Build();

        // Assert
        result.DisplayCapture.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddDocumentDomain_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddDocumentDomain(x => x.AllowAll()).Build();

        // Assert
        result.DocumentDomain.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddEncryptedMedia_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddEncryptedMedia(x => x.AllowAll()).Build();

        // Assert
        result.EncryptedMedia.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddFullscreen_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddFullscreen(x => x.AllowAll()).Build();

        // Assert
        result.Fullscreen.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddGamepad_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddGamepad(x => x.AllowAll()).Build();

        // Assert
        result.Gamepad.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddGeolocation_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddGeolocation(x => x.AllowAll()).Build();

        // Assert
        result.Geolocation.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddGyroscope_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddGyroscope(x => x.AllowAll()).Build();

        // Assert
        result.Gyroscope.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddHid_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddHid(x => x.AllowAll()).Build();

        // Assert
        result.Hid.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddIdentityCredentialsGet_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddIdentityCredentialsGet(x => x.AllowAll()).Build();

        // Assert
        result.IdentityCredentialsGet.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddIdleDetection_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddIdleDetection(x => x.AllowAll()).Build();

        // Assert
        result.IdleDetection.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddLocalFonts_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddLocalFonts(x => x.AllowAll()).Build();

        // Assert
        result.LocalFonts.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddMagnetometer_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddMagnetometer(x => x.AllowAll()).Build();

        // Assert
        result.Magnetometer.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddMicrophone_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddMicrophone(x => x.AllowAll()).Build();

        // Assert
        result.Microphone.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddMidi_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddMidi(x => x.AllowAll()).Build();

        // Assert
        result.Midi.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddOptCredentials_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddOptCredentials(x => x.AllowAll()).Build();

        // Assert
        result.OptCredentials.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddPayment_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddPayment(x => x.AllowAll()).Build();

        // Assert
        result.Payment.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddPictureInPicture_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddPictureInPicture(x => x.AllowAll()).Build();

        // Assert
        result.PictureInPicture.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddPublicKeyCredentialsCreate_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddPublicKeyCredentialsCreate(x => x.AllowAll()).Build();

        // Assert
        result.PublicKeyCredentialsCreate.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddPublicKeyCredentialsGet_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddPublicKeyCredentialsGet(x => x.AllowAll()).Build();

        // Assert
        result.PublicKeyCredentialsGet.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddScreenWakeLock_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddScreenWakeLock(x => x.AllowAll()).Build();

        // Assert
        result.ScreenWakeLock.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddSerial_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddSerial(x => x.AllowAll()).Build();

        // Assert
        result.Serial.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddSpeakerSelection_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddSpeakerSelection(x => x.AllowAll()).Build();

        // Assert
        result.SpeakerSelection.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddStorageAccess_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddStorageAccess(x => x.AllowAll()).Build();

        // Assert
        result.StorageAccess.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddUsb_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddUsb(x => x.AllowAll()).Build();

        // Assert
        result.Usb.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddWebShare_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddWebShare(x => x.AllowAll()).Build();

        // Assert
        result.WebShare.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddWindowManagement_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddWindowManagement(x => x.AllowAll()).Build();

        // Assert
        result.WindowManagement.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Build_AddXrSpatialTracking_ReturnsOptions()
    {
        // Arrange
        var builder = new PermissionsPolicyHeaderOptionsBuilder();

        // Act
        var result = builder.AddXrSpatialTracking(x => x.AllowAll()).Build();

        // Assert
        result.XrSpatialTracking.Should().NotBeNullOrEmpty();
    }
}