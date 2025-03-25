using System.Diagnostics;
using Sidio.Web.Security.Headers.Options.PermissionsPolicy;

namespace Sidio.Web.Security.Headers.Options;

/// <summary>
/// The Permissions-Policy header options.
/// </summary>
[DebuggerDisplay("{Value}")]
public sealed class PermissionsPolicyHeaderOptions : IHttpHeaderOptions
{
    /// <summary>
    /// Controls whether the current document is allowed to gather information about the acceleration
    /// of the device through the Accelerometer interface.
    /// </summary>
    public string? Accelerometer { get; set; }

    /// <summary>
    /// Controls whether the current document is allowed to gather information about the amount of light
    /// in the environment around the device through the AmbientLightSensor interface.
    /// </summary>
    public string? AmbientLightSensor { get; set; }

    /// <summary>
    /// Controls whether the current document is allowed to use the Attribution Reporting API.
    /// </summary>
    public string? AttributionReporting { get; set; }

    /// <summary>
    /// Controls whether the current document is allowed to autoplay media requested through the
    /// HTMLMediaElement interface.
    /// </summary>
    public string? Autoplay { get; set; }

    /// <summary>
    /// Controls whether the use of the Web Bluetooth API is allowed.
    /// </summary>
    public string? Bluetooth { get; set; }

    /// <summary>
    /// Controls access to the Topics API.
    /// </summary>
    public string? BrowsingTopics { get; set; }

    /// <summary>
    /// Controls whether the current document is allowed to use video input devices.
    /// </summary>
    public string? Camera { get; set; }

    /// <summary>
    /// Controls access to the Compute Pressure API.
    /// </summary>
    public string? ComputePressure { get; set; }

    /// <summary>
    /// Controls whether the current document can be treated as cross-origin isolated.
    /// </summary>
    public string? CrossOriginIsolated { get; set; }

    public string? DisplayCapture { get; set; }

    public string? DocumentDomain { get; set; }

    public string? EncryptedMedia { get; set; }

    public string? Fullscreen { get; set; }

    public string? Gamepad { get; set; }

    public string? Geolocation { get; set; }

    public string? Gyroscope { get; set; }

    public string? Hid { get; set; }

    public string? IdentityCredentialsGet { get; set; }

    public string? IdleDetection { get; set; }

    public string? LocalFonts { get; set; }

    public string? Magnetometer { get; set; }

    public string? Microphone { get; set; }

    public string? Midi { get; set; }

    public string? OptCredentials { get; set; }

    public string? Payment { get; set; }

    public string? PictureInPicture { get; set; }

    public string? PublicKeyCredentialsCreate { get; set; }

    public string? PublicKeyCredentialsGet { get; set; }

    public string? ScreenWakeLock { get; set; }

    public string? Serial { get; set; }

    public string? SpeakerSelection { get; set; }

    public string? StorageAccess { get; set; }

    public string? Usb { get; set; }

    public string? WebShare { get; set; }

    public string? WindowManagement { get; set; }

    public string? XrSpatialTracking { get; set; }

    /// <inheritdoc />
    public string Value => ToString();

    /// <inheritdoc />
    public override string ToString()
    {
        const string Separator = "=";
        var policies = new List<string>();

        policies
            .AddIfNotNull(Directives.Accelerometer, Accelerometer, Separator)
            .AddIfNotNull(Directives.AmbientLightSensor, AmbientLightSensor, Separator)
            .AddIfNotNull(Directives.AttributionReporting, AttributionReporting, Separator)
            .AddIfNotNull(Directives.Autoplay, Autoplay, Separator)
            .AddIfNotNull(Directives.Bluetooth, Bluetooth, Separator)
            .AddIfNotNull(Directives.BrowsingTopics, BrowsingTopics, Separator)
            .AddIfNotNull(Directives.Camera, Camera, Separator)
            .AddIfNotNull(Directives.ComputePressure, ComputePressure, Separator)
            .AddIfNotNull(Directives.CrossOriginIsolated, CrossOriginIsolated, Separator)
            .AddIfNotNull(Directives.DisplayCapture, DisplayCapture, Separator)
            .AddIfNotNull(Directives.DocumentDomain, DocumentDomain, Separator)
            .AddIfNotNull(Directives.EncryptedMedia, EncryptedMedia, Separator)
            .AddIfNotNull(Directives.Fullscreen, Fullscreen, Separator)
            .AddIfNotNull(Directives.Gamepad, Gamepad, Separator)
            .AddIfNotNull(Directives.Geolocation, Geolocation, Separator)
            .AddIfNotNull(Directives.Gyroscope, Gyroscope, Separator)
            .AddIfNotNull(Directives.Hid, Hid, Separator)
            .AddIfNotNull(Directives.IdentityCredentialsGet, IdentityCredentialsGet, Separator)
            .AddIfNotNull(Directives.IdleDetection, IdleDetection, Separator)
            .AddIfNotNull(Directives.LocalFonts, LocalFonts, Separator)
            .AddIfNotNull(Directives.Magnetometer, Magnetometer, Separator)
            .AddIfNotNull(Directives.Microphone, Microphone, Separator)
            .AddIfNotNull(Directives.Midi, Midi, Separator)
            .AddIfNotNull(Directives.OptCredentials, OptCredentials, Separator)
            .AddIfNotNull(Directives.Payment, Payment, Separator)
            .AddIfNotNull(Directives.PictureInPicture, PictureInPicture, Separator)
            .AddIfNotNull(Directives.PublicKeyCredentialsCreate, PublicKeyCredentialsCreate, Separator)
            .AddIfNotNull(Directives.PublicKeyCredentialsGet, PublicKeyCredentialsGet, Separator)
            .AddIfNotNull(Directives.ScreenWakeLock, ScreenWakeLock, Separator)
            .AddIfNotNull(Directives.Serial, Serial, Separator)
            .AddIfNotNull(Directives.SpeakerSelection, SpeakerSelection, Separator)
            .AddIfNotNull(Directives.StorageAccess, StorageAccess, Separator)
            .AddIfNotNull(Directives.Usb, Usb, Separator)
            .AddIfNotNull(Directives.WebShare, WebShare, Separator)
            .AddIfNotNull(Directives.WindowManagement, WindowManagement, Separator)
            .AddIfNotNull(Directives.XrSpatialTracking, XrSpatialTracking, Separator);

        return string.Join(", ", policies);
    }
}