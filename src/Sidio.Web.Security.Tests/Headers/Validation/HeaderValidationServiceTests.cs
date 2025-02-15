using Microsoft.Extensions.Logging;
using Moq;
using Sidio.Web.Security.Headers.Validation;

namespace Sidio.Web.Security.Tests.Headers.Validation;

public sealed class HeaderValidationServiceTests
{
    private static readonly string[] HeaderValue1 = ["1"];
    private static readonly string[] HeaderValueTest = ["TEST"];
    private static readonly string[] HeaderValueDeny = ["DENY"];

    [Fact]
    public void Validate_SuppressWarningsAndDoNotValidateRecommendedHeaders_ExpectsLogging()
    {
        // arrange
        var options = new HeaderValidationOptions
        {
            SuppressWarnings = true,
            ValidateRecommendedHeadersArePresent = false
        };
        var logger = new Mock<ILogger<HeaderValidationService>>();

        var httpHeaders = new Dictionary<string, IEnumerable<string?>>
        {
            { "X-Frame-Options", HeaderValueDeny },
            { "X-XSS-Protection", HeaderValue1 }
        };

        var validator = new HeaderValidationService(
            Microsoft.Extensions.Options.Options.Create(options),
            logger.Object);

        // act
        validator.Validate(httpHeaders);

        // assert
        logger.VerifyLog(LogLevel.Debug, 0);
        logger.VerifyLog(LogLevel.Information, 0);
        logger.VerifyLog(LogLevel.Warning, 0);
        logger.VerifyLog(LogLevel.Error, 0);
    }

    [Fact]
    public void Validate_DoNotSuppressWarningsAndDoNotValidateRecommendedHeaders_WithDeprecatedHeader_ExpectsLogging()
    {
        // arrange
        var options = new HeaderValidationOptions
        {
            SuppressWarnings = false,
            ValidateRecommendedHeadersArePresent = false
        };
        var logger = new Mock<ILogger<HeaderValidationService>>();

        var httpHeaders = new Dictionary<string, IEnumerable<string?>>
        {
            { "X-XSS-Protection", HeaderValue1 }
        };

        var validator = new HeaderValidationService(
            Microsoft.Extensions.Options.Options.Create(options),
            logger.Object);

        // act
        validator.Validate(httpHeaders);

        // assert
        logger.VerifyLog(LogLevel.Debug, 0);
        logger.VerifyLog(LogLevel.Information, 0);
        logger.VerifyLog(LogLevel.Warning, 1);
        logger.VerifyLog(LogLevel.Error, 0);
    }

    [Theory]
    [InlineData(true, 4)]
    [InlineData(false, 0)]
    public void Validate_SuppressWarningsAndValidateRecommendedHeaders_WithoutRecommendedHeaders_ExpectsLogging(bool validateRecommendedHeaders, int expectedWarnings)
    {
        // arrange
        var options = new HeaderValidationOptions
        {
            SuppressWarnings = true,
            ValidateRecommendedHeadersArePresent = validateRecommendedHeaders
        };
        var logger = new Mock<ILogger<HeaderValidationService>>();

        var httpHeaders = new Dictionary<string, IEnumerable<string?>>
        {
            { "X-XSS-Protection", HeaderValue1 }
        };

        var validator = new HeaderValidationService(
            Microsoft.Extensions.Options.Options.Create(options),
            logger.Object);

        // act
        validator.Validate(httpHeaders);

        // assert
        logger.VerifyLog(LogLevel.Debug, 0);
        logger.VerifyLog(LogLevel.Information, 0);
        logger.VerifyLog(LogLevel.Warning, expectedWarnings);
        logger.VerifyLog(LogLevel.Error, 0);
    }

    [Fact]
    public void Validate_DoNotSuppressWarningsAndDoNotValidateRecommendedHeaders_WithNonValidatableHeader_ExpectsLogging()
    {
        // arrange
        var options = new HeaderValidationOptions
        {
            SuppressWarnings = false,
            ValidateRecommendedHeadersArePresent = false
        };
        var logger = new Mock<ILogger<HeaderValidationService>>();

        var httpHeaders = new Dictionary<string, IEnumerable<string?>>
        {
            { "test", HeaderValue1 }
        };

        var validator = new HeaderValidationService(
            Microsoft.Extensions.Options.Options.Create(options),
            logger.Object);

        // act
        validator.Validate(httpHeaders);

        // assert
        logger.VerifyLog(LogLevel.Debug, 1);
        logger.VerifyLog(LogLevel.Information, 0);
        logger.VerifyLog(LogLevel.Warning, 0);
        logger.VerifyLog(LogLevel.Error, 0);
    }

    [Fact]
    public void Validate_DoNotSuppressWarningsAndDoNotValidateRecommendedHeaders_WithFaultyHeader_ExpectsLogging()
    {
        // arrange
        var options = new HeaderValidationOptions
        {
            SuppressWarnings = false,
            ValidateRecommendedHeadersArePresent = false
        };
        var logger = new Mock<ILogger<HeaderValidationService>>();

        var httpHeaders = new Dictionary<string, IEnumerable<string?>>
        {
            { "x-frame-options", HeaderValueTest }
        };

        var validator = new HeaderValidationService(
            Microsoft.Extensions.Options.Options.Create(options),
            logger.Object);

        // act
        validator.Validate(httpHeaders);

        // assert
        logger.VerifyLog(LogLevel.Debug, 0);
        logger.VerifyLog(LogLevel.Information, 0);
        logger.VerifyLog(LogLevel.Warning, 0);
        logger.VerifyLog(LogLevel.Error, 1);
    }
}