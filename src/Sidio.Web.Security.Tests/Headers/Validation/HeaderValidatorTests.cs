﻿using Sidio.Web.Security.Headers.Options;
using Sidio.Web.Security.Headers.Validation;

namespace Sidio.Web.Security.Tests.Headers.Validation;

public abstract class HeaderValidatorTests<TOptions>
    where TOptions : class, IHttpHeaderOptions, new()
{
    protected abstract IHeaderValidator<TOptions> Validator { get; }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Validate_WithNullValue_ReturnsInvalid(string? value)
    {
        // act
        var result = Validator.Validate(value, out var options);

        // assert
        result.IsValid.Should().BeFalse();
        options.Should().BeNull();
    }
}