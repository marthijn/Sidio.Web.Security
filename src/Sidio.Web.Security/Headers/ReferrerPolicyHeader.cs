using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Headers.Validation;

namespace Sidio.Web.Security.Headers;

public sealed class ReferrerPolicyHeader : ValidatableHttpHeader<ReferrerPolicyHeaderOptions>
{
    public ReferrerPolicyHeader(string? value) : base(value)
    {
    }

    public override string Name { get; }
    protected override IHeaderValidator<ReferrerPolicyHeaderOptions> Validator { get; }
}