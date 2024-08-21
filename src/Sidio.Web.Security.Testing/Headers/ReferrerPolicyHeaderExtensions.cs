using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Testing.Headers.Exceptions;

namespace Sidio.Web.Security.Testing.Headers;

/// <summary>
/// The referrer policy header extensions.
/// </summary>
public static class ReferrerPolicyHeaderExtensions
{
    /// <summary>
    /// Asserts that the referrer policy header options contains the expected referrer policy.
    /// </summary>
    /// <param name="options">The options.</param>
    /// <param name="expectedReferrerPolicy">The expected policy.</param>
    /// <returns>The <see cref="ReferrerPolicyHeaderOptions"/>.</returns>
    /// <exception cref="DirectiveShouldHaveValueException">Thrown when the expected policy does not exist.</exception>
    public static ReferrerPolicyHeaderOptions ContainsPolicy(
        this ReferrerPolicyHeaderOptions options,
        ReferrerPolicy expectedReferrerPolicy)
    {
        if (!options.Policies.Contains(expectedReferrerPolicy))
        {
            throw new DirectiveShouldHaveValueException(nameof(options.Policies), expectedReferrerPolicy, options.Policies);
        }

        return options;
    }
}