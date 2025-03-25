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
    public PermissionsPolicyHeaderOptionsBuilder AddAccelerometer(Func<DirectivesBuilder, DirectivesBuilder> builder)
    {
        _options.Accelerometer = builder(new DirectivesBuilder()).Build();
        return this;
    }

    /// <summary>
    /// Build the <see cref="PermissionsPolicyHeaderOptions"/>.
    /// </summary>
    /// <returns>The <see cref="PermissionsPolicyHeaderOptions"/>.</returns>
    public PermissionsPolicyHeaderOptions Build() => _options;
}