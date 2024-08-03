using Sidio.Http.Security.Headers.Options;
using Sidio.Http.Security.Headers.Validation;

namespace Sidio.Http.Security.Headers;

public abstract class ValidatableHttpHeader<TOptions> : HttpHeader
where TOptions : class, IHttpHeaderOptions, new()
{
    protected ValidatableHttpHeader(string? value) : base(value)
    {
    }

    protected abstract IHeaderValidator<TOptions> Validator { get; }

    public override HeaderValidationResult Validate() => Validator.Validate(Value, out _);
}