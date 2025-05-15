namespace CSharpPractice.V10Features.InterpolatedStringHandler;

public class ExclamationAppendingLogger(ILogWriter logWriter = null) : Logger(logWriter)
{
    public void LogMessage(LogLevel level, ExclamationAppendingHandler formatter)
    {
        if (EnabledLevel < level)
        {
            return;
        }

        LogWriter.WriteLogMessage(formatter.GetFormattedText());
    }
}
