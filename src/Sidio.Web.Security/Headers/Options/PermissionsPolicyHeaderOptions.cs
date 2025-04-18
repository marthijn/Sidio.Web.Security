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

    /// <summary>
    /// Controls whether or not the current document is permitted to use the getDisplayMedia() method to capture
    /// screen contents.
    /// </summary>
    public string? DisplayCapture { get; set; }

    /// <summary>
    /// Controls whether the current document is allowed to set document.domain.
    /// </summary>
    public string? DocumentDomain { get; set; }

    /// <summary>
    /// Controls whether the current document is allowed to use the Encrypted Media Extensions API (EME).
    /// </summary>
    public string? EncryptedMedia { get; set; }

    /// <summary>
    /// Controls whether the current document is allowed to use Element.requestFullscreen().
    /// </summary>
    public string? Fullscreen { get; set; }

    /// <summary>
    /// Controls whether the current document is allowed to use the Gamepad API.
    /// </summary>
    public string? Gamepad { get; set; }

    /// <summary>
    /// Controls whether the current document is allowed to use the Geolocation Interface.
    /// </summary>
    public string? Geolocation { get; set; }

    /// <summary>
    /// Controls whether the current document is allowed to gather information about the orientation of the
    /// device through the Gyroscope interface.
    /// </summary>
    public string? Gyroscope { get; set; }

    /// <summary>
    /// Controls whether the current document is allowed to use the WebHID API to connect to uncommon or
    /// exotic human interface devices such as alternative keyboards or gamepads.
    /// </summary>
    public string? Hid { get; set; }

    /// <summary>
    /// Controls whether the current document is allowed to use the Federated Credential Management API (FedCM),
    /// and more specifically the navigator.credentials.get() method with an identity option.
    /// </summary>
    public string? IdentityCredentialsGet { get; set; }

    /// <summary>
    /// Controls whether the current document is allowed to use the Idle Detection API to detect when users are
    /// interacting with their devices, for example to report "available"/"away" status in chat applications.
    /// </summary>
    public string? IdleDetection { get; set; }

    /// <summary>
    /// Controls whether the current document is allowed to gather data on the user's locally-installed fonts
    /// via the Window.queryLocalFonts() method.
    /// </summary>
    public string? LocalFonts { get; set; }

    /// <summary>
    /// Controls whether the current document is allowed to gather information about the orientation of the
    /// device through the Magnetometer interface.
    /// </summary>
    public string? Magnetometer { get; set; }

    /// <summary>
    /// Controls whether the current document is allowed to use audio input devices.
    /// </summary>
    public string? Microphone { get; set; }

    /// <summary>
    /// Controls whether the current document is allowed to use the Web MIDI API.
    /// </summary>
    public string? Midi { get; set; }

    /// <summary>
    /// Controls whether the current document is allowed to use the WebOTP API to request a one-time password (OTP)
    /// from a specially-formatted SMS message sent by the app's server.
    /// </summary>
    public string? OptCredentials { get; set; }

    /// <summary>
    /// Controls whether the current document is allowed to use the Payment Request API.
    /// </summary>
    public string? Payment { get; set; }

    /// <summary>
    /// Controls whether the current document is allowed to play a video in a Picture-in-Picture mode via
    /// the corresponding API.
    /// </summary>
    public string? PictureInPicture { get; set; }

    /// <summary>
    /// Controls whether the current document is allowed to use the Web Authentication API to create new
    /// asymmetric key credentials.
    /// </summary>
    public string? PublicKeyCredentialsCreate { get; set; }

    /// <summary>
    /// Controls whether the current document is allowed to use the Web Authentication API to retrieve already
    /// stored public-key credentials.
    /// </summary>
    public string? PublicKeyCredentialsGet { get; set; }

    /// <summary>
    /// Controls whether the current document is allowed to use Screen Wake Lock API to indicate that device
    /// should not turn off or dim the screen.
    /// </summary>
    public string? ScreenWakeLock { get; set; }

    /// <summary>
    /// Controls whether the current document is allowed to use the Web Serial API to communicate with serial devices,
    /// either directly connected via a serial port, or via USB or Bluetooth devices emulating a serial port.
    /// </summary>
    public string? Serial { get; set; }

    /// <summary>
    /// Controls whether the current document is allowed to use the Audio Output Devices API to list and select speakers.
    /// </summary>
    public string? SpeakerSelection { get; set; }

    /// <summary>
    /// Controls whether a document loaded in a third-party context
    /// is allowed to use the Storage Access API to request access to unpartitioned cookies.
    /// </summary>
    public string? StorageAccess { get; set; }

    /// <summary>
    /// Controls whether the current document is allowed to use the WebUSB API.
    /// </summary>
    public string? Usb { get; set; }

    /// <summary>
    /// Controls whether or not the current document is allowed to use the Navigator.share() of Web Share API to share text,
    /// links, images, and other content to arbitrary destinations of user's choice, e.g. mobile apps.
    /// </summary>
    public string? WebShare { get; set; }

    /// <summary>
    /// Controls whether or not the current document is allowed to use the Window Management API to manage windows on multiple displays.
    /// </summary>
    public string? WindowManagement { get; set; }

    /// <summary>
    /// Controls whether or not the current document is allowed to use the WebXR Device API to interact with a WebXR session.
    /// </summary>
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