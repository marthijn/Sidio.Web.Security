using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Headers.Validation;

namespace Sidio.Web.Security.Headers;

/// <summary>
/// The base class for HTTP headers that can be validated.
/// </summary>
/// <typeparam name="TOptions">The options type.</typeparam>
public abstract class ValidatableHttpHeader<TOptions> : HttpHeader
    where TOptions : class, IHttpHeaderOptions, new()
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ValidatableHttpHeader{TOptions}"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    protected ValidatableHttpHeader(string? value) : base(value)
    {
    }

    /// <summary>
    /// Gets the validator.
    /// </summary>
    protected abstract IHeaderValidator<TOptions> Validator { get; }

    /// <summary>
    /// Validates the header value.
    /// </summary>
    /// <param name="options"></param>
    /// <returns>A <see cref="HeaderValidationResult"/>.</returns>
    public HeaderValidationResult Validate(out TOptions? options) => Validator.Validate(Value, out options);

    /// <summary>
    /// Validates the header value.
    /// </summary>
    /// <returns>A <see cref="HeaderValidationResult"/>.</returns>
    public override HeaderValidationResult Validate() => Validate(out _);
}