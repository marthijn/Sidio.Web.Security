using Microsoft.Extensions.Logging;
using Moq;

namespace Sidio.Web.Security.Tests;

internal static class LoggerMockExtensions
{
    public static void VerifyLog<T>(this Mock<ILogger<T>> logger, LogLevel logLevel, int expectedLogEntries)
    {
        logger.Verify(
            x => x.Log(
                logLevel,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()!),
            Times.Exactly(expectedLogEntries));
    }
}