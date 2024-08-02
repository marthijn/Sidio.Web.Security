namespace Sidio.Http.Security.Headers;

public sealed record HeaderValidationResult
{
    internal HeaderValidationResult(IEnumerable<HeaderValidation> validations)
    {
        ValidationResults = validations.ToList();
        HasWarnings = ValidationResults.Any(v => v.SeverityLevel == HeaderValidationSeverityLevel.Warning);
        HasErrors = ValidationResults.Any(v => v.SeverityLevel == HeaderValidationSeverityLevel.Error);
    }

    public IReadOnlyCollection<HeaderValidation> ValidationResults { get; }

    public IEnumerable<HeaderValidation> Warnings =>
        ValidationResults.Where(v => v.SeverityLevel == HeaderValidationSeverityLevel.Warning);

    public IEnumerable<HeaderValidation> Errors =>
        ValidationResults.Where(v => v.SeverityLevel == HeaderValidationSeverityLevel.Error);

    public bool HasWarnings { get; }

    public bool HasErrors { get; }

    public bool IsValid => !HasErrors;
}