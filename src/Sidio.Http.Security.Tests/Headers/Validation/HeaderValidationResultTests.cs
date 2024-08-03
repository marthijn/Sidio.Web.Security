﻿using Sidio.Http.Security.Headers.Validation;

namespace Sidio.Http.Security.Tests.Headers.Validation;

public sealed class HeaderValidationResultTests
{
    private readonly Fixture _fixture = new();

    [Fact]
    public void Construct_ShouldHaveWarningsAndErrors()
    {
        // arrange
        var validations = _fixture.CreateMany<HeaderValidation>(20).ToList();
        var warnings = validations.Where(v => v.SeverityLevel == HeaderValidationSeverityLevel.Warning).ToList();
        var errors = validations.Where(v => v.SeverityLevel == HeaderValidationSeverityLevel.Error).ToList();
        var hasWarnings = warnings.Any();
        var hasErrors = errors.Any();

        // act
        var headerValidationResult = new HeaderValidationResult(validations);

        // assert
        headerValidationResult.ValidationResults.Should().NotBeEmpty();
        headerValidationResult.ValidationResults.Should().BeEquivalentTo(validations);

        headerValidationResult.Warnings.Should().BeEquivalentTo(warnings);
        headerValidationResult.Errors.Should().BeEquivalentTo(errors);

        headerValidationResult.HasErrors.Should().Be(hasErrors);
        headerValidationResult.HasWarnings.Should().Be(hasWarnings);

        headerValidationResult.IsValid.Should().Be(!hasErrors);
    }
}