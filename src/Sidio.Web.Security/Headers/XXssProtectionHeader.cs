using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Headers.Validation;

namespace Sidio.Web.Security.Headers;

public sealed class XXssProtectionHeader : ValidatableHttpHeader<XXssProtectionHeaderOptions>
{
    /// <summary>
    /// The name of the header.
    /// </summary>
    public const string HeaderName = "X-XSS-Protection";

    public XXssProtectionHeader(string? value) : base(value)
    {
    }

    public override string Name => HeaderName;

    protected override IHeaderValidator<XXssProtectionHeaderOptions> Validator => new XXssProtectionHeaderValidator();
}