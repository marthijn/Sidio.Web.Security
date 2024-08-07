namespace Sidio.Web.Security.Headers.Validation;

/// <summary>
/// The result of the header validation.
/// </summary>
public sealed record HeaderValidationResult
{
    internal HeaderValidationResult(IEnumerable<HeaderValidation> validations)
    {
        ValidationResults = validations.ToList();
        HasWarnings = ValidationResults.Any(v => v.SeverityLevel == HeaderValidationSeverityLevel.Warning);
        HasErrors = ValidationResults.Any(v => v.SeverityLevel == HeaderValidationSeverityLevel.Error);
    }

    /// <summary>
    /// Gets the validation results.
    /// </summary>
    public IReadOnlyCollection<HeaderValidation> ValidationResults { get; }

    /// <summary>
    /// Gets the warnings.
    /// </summary>
    public IEnumerable<HeaderValidation> Warnings =>
        ValidationResults.Where(v => v.SeverityLevel == HeaderValidationSeverityLevel.Warning);

    /// <summary>
    /// Gets the errors.
    /// </summary>
    public IEnumerable<HeaderValidation> Errors =>
        ValidationResults.Where(v => v.SeverityLevel == HeaderValidationSeverityLevel.Error);

    /// <summary>
    /// Indicates whether the validation has warnings.
    /// </summary>
    public bool HasWarnings { get; }

    /// <summary>
    /// Indicates whether the validation has errors.
    /// </summary>
    public bool HasErrors { get; }

    /// <summary>
    /// Indicates whether the validation is valid.
    /// </summary>
    public bool IsValid => !HasErrors;
}