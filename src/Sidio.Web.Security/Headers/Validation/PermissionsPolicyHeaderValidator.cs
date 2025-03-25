using System.Text.RegularExpressions;
using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Headers.Options.PermissionsPolicy;

namespace Sidio.Web.Security.Headers.Validation;

/// <summary>
/// The Permissions-Policy header validator.
/// </summary>
public sealed class PermissionsPolicyHeaderValidator : IHeaderValidator<PermissionsPolicyHeaderOptions>
{
    /// <inheritdoc />
    public HeaderValidationResult Validate(string? headerValue, out PermissionsPolicyHeaderOptions? options)
    {
        if (headerValue.IsNullOrWhiteSpace(out var validations))
        {
            options = null;
            return new HeaderValidationResult(validations);
        }

        options = new PermissionsPolicyHeaderOptions();

        var headerValueLower = headerValue.ToLowerInvariant();
        ParseHeaderValue(headerValueLower, ref options);

        var result = Validate(options);
        if (!result.IsValid)
        {
            options = null;
        }

        return result;
    }

    /// <inheritdoc />
    public HeaderValidationResult Validate(PermissionsPolicyHeaderOptions options)
    {
        var validationResult = new List<HeaderValidation>();
        return new HeaderValidationResult(validationResult);
    }

    private static void ParseHeaderValue(string headerValue, ref PermissionsPolicyHeaderOptions options)
    {
        options.Accelerometer = GetDirectiveValue(Directives.Accelerometer, headerValue);
        options.AmbientLightSensor = GetDirectiveValue(Directives.AmbientLightSensor, headerValue);
        options.AttributionReporting = GetDirectiveValue(Directives.AttributionReporting, headerValue);
        options.Autoplay = GetDirectiveValue(Directives.Autoplay, headerValue);
        options.Bluetooth = GetDirectiveValue(Directives.Bluetooth, headerValue);
        options.BrowsingTopics = GetDirectiveValue(Directives.BrowsingTopics, headerValue);
        options.Camera = GetDirectiveValue(Directives.Camera, headerValue);
        options.ComputePressure = GetDirectiveValue(Directives.ComputePressure, headerValue);
        options.CrossOriginIsolated = GetDirectiveValue(Directives.CrossOriginIsolated, headerValue);
        options.DisplayCapture = GetDirectiveValue(Directives.DisplayCapture, headerValue);
        options.DocumentDomain = GetDirectiveValue(Directives.DocumentDomain, headerValue);
        options.EncryptedMedia = GetDirectiveValue(Directives.EncryptedMedia, headerValue);
        options.Fullscreen = GetDirectiveValue(Directives.Fullscreen, headerValue);
        options.Gamepad = GetDirectiveValue(Directives.Gamepad, headerValue);
        options.Geolocation = GetDirectiveValue(Directives.Geolocation, headerValue);
        options.Gyroscope = GetDirectiveValue(Directives.Gyroscope, headerValue);
        options.Hid = GetDirectiveValue(Directives.Hid, headerValue);
        options.IdentityCredentialsGet = GetDirectiveValue(Directives.IdentityCredentialsGet, headerValue);
        options.IdleDetection = GetDirectiveValue(Directives.IdleDetection, headerValue);
        options.LocalFonts = GetDirectiveValue(Directives.LocalFonts, headerValue);
        options.Magnetometer = GetDirectiveValue(Directives.Magnetometer, headerValue);
        options.Microphone = GetDirectiveValue(Directives.Microphone, headerValue);
        options.Midi = GetDirectiveValue(Directives.Midi, headerValue);
        options.OptCredentials = GetDirectiveValue(Directives.OptCredentials, headerValue);
        options.Payment = GetDirectiveValue(Directives.Payment, headerValue);
        options.PictureInPicture = GetDirectiveValue(Directives.PictureInPicture, headerValue);
        options.PublicKeyCredentialsCreate = GetDirectiveValue(Directives.PublicKeyCredentialsCreate, headerValue);
        options.PublicKeyCredentialsGet = GetDirectiveValue(Directives.PublicKeyCredentialsGet, headerValue);
        options.ScreenWakeLock = GetDirectiveValue(Directives.ScreenWakeLock, headerValue);
        options.Serial = GetDirectiveValue(Directives.Serial, headerValue);
        options.SpeakerSelection = GetDirectiveValue(Directives.SpeakerSelection, headerValue);
        options.StorageAccess = GetDirectiveValue(Directives.StorageAccess, headerValue);
        options.Usb = GetDirectiveValue(Directives.Usb, headerValue);
        options.WebShare = GetDirectiveValue(Directives.WebShare, headerValue);
        options.WindowManagement = GetDirectiveValue(Directives.WindowManagement, headerValue);
        options.XrSpatialTracking = GetDirectiveValue(Directives.XrSpatialTracking, headerValue);
    }

#if NET7_0_OR_GREATER
    private static string? GetDirectiveValue([System.Diagnostics.CodeAnalysis.ConstantExpected] string directive, string headerValue)
#else
    private static string? GetDirectiveValue(string directive, string headerValue)
#endif
    {
        var regex = new Regex($@"{directive}=(\*|\(.*?\))");
        var match = regex.Match(headerValue);
        if (match.Success)
        {
            return match.Groups[1].Value.Trim();
        }

        return null;
    }
}