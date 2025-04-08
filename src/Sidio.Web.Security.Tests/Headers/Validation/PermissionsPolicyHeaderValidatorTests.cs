using System.Collections;
using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Headers.Options.PermissionsPolicy;
using Sidio.Web.Security.Headers.Validation;

namespace Sidio.Web.Security.Tests.Headers.Validation;

public sealed class PermissionsPolicyHeaderValidatorTests : HeaderValidatorTests<PermissionsPolicyHeaderOptions>
{
    private readonly Fixture _fixture = new();

    protected override IHeaderValidator<PermissionsPolicyHeaderOptions> Validator =>
        new PermissionsPolicyHeaderValidator();

    [Theory]
    [ClassData(typeof(DirectiveDataGenerator))]
    public void Validate_GivenDirective_ShouldReturnValidOptionsValue(string propertyName, string directive, string? expectedValue)
    {
        // act
        var result = Validator.Validate(directive, out var options);

        // assert
        result.IsValid.Should().BeTrue();
        options.Should().NotBeNull();

        var propertyValue = options!.GetType().GetProperty(propertyName)!.GetValue(options, null);
        propertyValue.Should().Be(expectedValue);
    }

    private sealed class DirectiveDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object?[]> _data = new();

        public DirectiveDataGenerator()
        {
            AddDirective(nameof(PermissionsPolicyHeaderOptions.Accelerometer), Directives.Accelerometer);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.AmbientLightSensor), Directives.AmbientLightSensor);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.AttributionReporting), Directives.AttributionReporting);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.Autoplay), Directives.Autoplay);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.Bluetooth), Directives.Bluetooth);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.BrowsingTopics), Directives.BrowsingTopics);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.Camera), Directives.Camera);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.ComputePressure), Directives.ComputePressure);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.CrossOriginIsolated), Directives.CrossOriginIsolated);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.DisplayCapture), Directives.DisplayCapture);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.DocumentDomain), Directives.DocumentDomain);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.EncryptedMedia), Directives.EncryptedMedia);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.Fullscreen), Directives.Fullscreen);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.Gamepad), Directives.Gamepad);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.Geolocation), Directives.Geolocation);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.Gyroscope), Directives.Gyroscope);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.Hid), Directives.Hid);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.IdentityCredentialsGet), Directives.IdentityCredentialsGet);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.IdleDetection), Directives.IdleDetection);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.LocalFonts), Directives.LocalFonts);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.Magnetometer), Directives.Magnetometer);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.Microphone), Directives.Microphone);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.Midi), Directives.Midi);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.OptCredentials), Directives.OptCredentials);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.Payment), Directives.Payment);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.PictureInPicture), Directives.PictureInPicture);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.PublicKeyCredentialsCreate), Directives.PublicKeyCredentialsCreate);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.PublicKeyCredentialsGet), Directives.PublicKeyCredentialsGet);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.ScreenWakeLock), Directives.ScreenWakeLock);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.Serial), Directives.Serial);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.SpeakerSelection), Directives.SpeakerSelection);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.StorageAccess), Directives.StorageAccess);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.Usb), Directives.Usb);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.WebShare), Directives.WebShare);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.WindowManagement), Directives.WindowManagement);
            AddDirective(nameof(PermissionsPolicyHeaderOptions.XrSpatialTracking), Directives.XrSpatialTracking);

            _data.Should().NotBeEmpty();
        }

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void AddDirective(string propertyName, string directive)
        {
            _data.AddRange([
                [propertyName, $"{directive}=*", "*"],
                [propertyName, $"{directive}=()", "()"],
                [propertyName, $"{directive}=(self)", "(self)"],
                [propertyName, $"{directive}=(self \"https://example.com\")", "(self \"https://example.com\")"],
                [propertyName, $"{directive}=(\"https://*.example.com\")", "(\"https://*.example.com\")"],
            ]);
        }
    }
}