using Sidio.Web.Security.Headers.Options;

namespace Sidio.Web.Security.Headers.Validation;

internal static class HeaderValidationResultExtensions
{
    public static HeaderValidationResult ClearOptionsWhenInvalid<TOptions>(this HeaderValidationResult result, ref TOptions? options)
    where TOptions : class, IHttpHeaderOptions
    {
        if (!result.IsValid)
        {
            options = default;
        }

        return result;
    }
}