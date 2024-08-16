using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Testing.Exceptions;

namespace Sidio.Web.Security.Testing;

public static class ReferrerPolicyHeaderExtensions
{
    public static ReferrerPolicyHeaderOptions WithPolicy(
        this ReferrerPolicyHeaderOptions options,
        ReferrerPolicy expectedReferrerPolicy)
    {
        if (options.Policy != expectedReferrerPolicy)
        {
            throw new DirectiveShouldHaveValueException(nameof(options.Policy), expectedReferrerPolicy, options.Policy);
        }

        return options;
    }
}