namespace CSharpPractice.V10Features.InterpolatedStringHandler;

public class ExceptionThrowingLogger(ILogWriter logWriter = null) : Logger(logWriter)
{
    public void LogMessage(LogLevel level, ExceptionThrowingHandler formatter)
    {
        if (EnabledLevel < level)
        {
            return;
        }

        LogWriter.WriteLogMessage(formatter.GetFormattedText());
    }
}