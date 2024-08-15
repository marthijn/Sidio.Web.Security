using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Headers.Validation;

namespace Sidio.Web.Security.Headers;

/// <summary>
/// The header that specifies the reporting groups that the user agent should send reports to.
/// </summary>
public sealed class ReportToHeader : ValidatableHttpHeader<ReportToHeaderOptions>
{
    /// <summary>
    /// The name of the header.
    /// </summary>
    public const string HeaderName = "Report-To";

    /// <summary>
    /// Initializes a new instance of the <see cref="ReportToHeader"/> class.
    /// </summary>
    /// <param name="value">The header value.</param>
    public ReportToHeader(string? value) : base(value)
    {
    }

    /// <inheritdoc />
    public override string Name => HeaderName;

    /// <inheritdoc />
    protected override IHeaderValidator<ReportToHeaderOptions> Validator => new ReportToHeaderValidation();
}