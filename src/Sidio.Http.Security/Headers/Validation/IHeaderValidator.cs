using Sidio.Http.Security.Headers.Options;

namespace Sidio.Http.Security.Headers.Validation;

/// <summary>
/// The header validator interface.
/// </summary>
/// <typeparam name="TOptions"></typeparam>
public interface IHeaderValidator<TOptions>
where TOptions : class, IHttpHeaderOptions, new()
{
    /// <summary>
    /// Validates the header value.
    /// </summary>
    /// <param name="headerValue">The header value.</param>
    /// <param name="options">The options as result of the validation.</param>
    /// <returns>The <see cref="HeaderValidationResult"/>.</returns>
    HeaderValidationResult Validate(string? headerValue, out TOptions? options);

    /// <summary>
    /// Validates the header options.
    /// </summary>
    /// <param name="options">The options.</param>
    /// <returns>The <see cref="HeaderValidationResult"/>.</returns>
    HeaderValidationResult Validate(TOptions options);
}