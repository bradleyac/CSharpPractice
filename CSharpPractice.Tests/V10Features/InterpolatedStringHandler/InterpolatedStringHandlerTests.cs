using CSharpPractice.V10Features.InterpolatedStringHandler;

namespace CSharpPractice.Tests.V10Features.InterpolatedStringHandler;

public class InterpolatedStringHandlerTests
{
    private Mock<ILogWriter> _logWriter;

    public InterpolatedStringHandlerTests()
    {
        _logWriter = GetMockLogWriter();
    }

    [Fact]
    public void LogMessage_EnabledLogLevelLessThanMessageLevel_DoesNotCallGetFormattedText()
    {
        var logger = new ExceptionThrowingLogger()
        {
            EnabledLevel = LogLevel.Off
        };

        // Does not throw, because it doesn't call GetFormattedText
        logger.LogMessage(LogLevel.Critical, $"{logger.GetHashCode()}");
    }

    [Fact]
    public void LogMessage_EnabledLogLevelGreaterThanMessageLevel_CallsGetFormattedText()
    {
        var logger = new ExceptionThrowingLogger()
        {
            EnabledLevel = LogLevel.Trace
        };

        var ex = Assert.Throws<InvalidOperationException>(() => logger.LogMessage(LogLevel.Critical, $"{logger.GetHashCode()}"));
        Assert.Equal(logger.GetHashCode().ToString(), ex.Message);
    }

    [Fact]
    public void LogMessage_EnabledLogLevelGreaterThanMessageLevel_LogsProperlyFormattedText()
    {
        var logger = new ExclamationAppendingLogger(_logWriter.Object)
        {
            EnabledLevel = LogLevel.Trace,
        };

        logger.LogMessage(LogLevel.Critical, $"{logger.GetHashCode()}");

        _logWriter.Verify(lw => lw.WriteLogMessage(logger.GetHashCode().ToString() + "!"), Times.Once());
    }

    [Fact]
    public void LogMessage_EnabledLogLevelLessThanMessageLevel_LogsNothing()
    {
        var logger = new ExclamationAppendingLogger(_logWriter.Object)
        {
            EnabledLevel = LogLevel.Off,
        };

        logger.LogMessage(LogLevel.Critical, $"{logger.GetHashCode()}");

        _logWriter.Verify(lw => lw.WriteLogMessage(It.IsAny<string>()), Times.Never());
    }

    private Mock<ILogWriter> GetMockLogWriter()
    {
        var mockLogWriter = new Mock<ILogWriter>();
        mockLogWriter.Setup(mlw => mlw.WriteLogMessage(It.IsAny<string>()));
        return mockLogWriter;
    }
}