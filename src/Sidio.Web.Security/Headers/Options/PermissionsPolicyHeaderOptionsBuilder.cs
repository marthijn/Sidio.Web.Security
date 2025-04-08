using Sidio.Web.Security.Headers.Options.PermissionsPolicy;

namespace Sidio.Web.Security.Headers.Options;

/// <summary>
/// The Permissions-Policy header options builder.
/// </summary>
public sealed class PermissionsPolicyHeaderOptionsBuilder
{
    private readonly PermissionsPolicyHeaderOptions _options = new();

    /// <summary>
    /// Add the accelerometer directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddAccelerometer(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.Accelerometer = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the ambient light sensor directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddAmbientLightSensor(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.AmbientLightSensor = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the attribution reporting directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddAttributionReporting(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.AttributionReporting = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the autoplay directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddAutoplay(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.Autoplay = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the bluetooth directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddBluetooth(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.Bluetooth = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the browsing topics directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddBrowsingTopics(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.BrowsingTopics = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the camera directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddCamera(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.Camera = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the compute pressure directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddComputePressure(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.ComputePressure = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the cross-origin isolated directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddCrossOriginIsolated(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.CrossOriginIsolated = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the display capture directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddDisplayCapture(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.DisplayCapture = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the document domain directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddDocumentDomain(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.DocumentDomain = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the encrypted media directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddEncryptedMedia(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.EncryptedMedia = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the fullscreen directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddFullscreen(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.Fullscreen = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the gamepad directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddGamepad(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.Gamepad = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the geolocation directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddGeolocation(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.Geolocation = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the gyroscope directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddGyroscope(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.Gyroscope = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the hid directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddHid(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.Hid = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the identity credentials get directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddIdentityCredentialsGet(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.IdentityCredentialsGet = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the idle detection directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddIdleDetection(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.IdleDetection = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the local fonts directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddLocalFonts(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.LocalFonts = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the magnetometer directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddMagnetometer(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.Magnetometer = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the microphone directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddMicrophone(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.Microphone = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the midi directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddMidi(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.Midi = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the opt credentials directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddOptCredentials(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.OptCredentials = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the payment directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddPayment(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.Payment = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the picture in picture directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddPictureInPicture(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.PictureInPicture = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the public key credentials create directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddPublicKeyCredentialsCreate(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.PublicKeyCredentialsCreate = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the public key credentials get directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddPublicKeyCredentialsGet(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.PublicKeyCredentialsGet = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the screen wake lock directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddScreenWakeLock(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.ScreenWakeLock = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the serial directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddSerial(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.Serial = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the speaker selection directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddSpeakerSelection(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.SpeakerSelection = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the storage access directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddStorageAccess(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.StorageAccess = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the USB directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddUsb(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.Usb = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the web share directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddWebShare(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.WebShare = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the window management directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddWindowManagement(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.WindowManagement = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Add the xr spatial tracking directive.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptionsBuilder"/> instance.</returns>
    public PermissionsPolicyHeaderOptionsBuilder AddXrSpatialTracking(
        Func<DirectiveValueBuilder, DirectiveValueBuilder> builder)
    {
        _options.XrSpatialTracking = builder(new DirectiveValueBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Build the <see cref="PermissionsPolicyHeaderOptions"/>.
    /// </summary>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptions"/>.</returns>
    internal PermissionsPolicyHeaderOptions Build() => _options;
}