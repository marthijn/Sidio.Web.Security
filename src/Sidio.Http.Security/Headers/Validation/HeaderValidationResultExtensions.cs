using Sidio.Http.Security.Headers.Options;

namespace Sidio.Http.Security.Headers.Validation;

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