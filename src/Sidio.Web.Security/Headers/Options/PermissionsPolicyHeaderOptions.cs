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

    /// <inheritdoc />
    public string Value => ToString();

    /// <inheritdoc />
    public override string ToString()
    {
        const string Separator = "=";
        var policies = new List<string>();

        policies.AddIfNotNull(Directives.Accelerometer, Accelerometer, Separator);

        return string.Join(", ", policies);
    }
}