namespace CSharpPractice.V10Features.InterpolatedStringHandler;

public abstract class Logger(ILogWriter logWriter = null)
{
    protected ILogWriter LogWriter { get; set; } = logWriter;

    public LogLevel EnabledLevel { get; init; } = LogLevel.Error;

    public void LogMessage(LogLevel level, string msg)
    {
        if (EnabledLevel < level)
        {
            return;
        }

        LogWriter.WriteLogMessage(msg);
    }
}
