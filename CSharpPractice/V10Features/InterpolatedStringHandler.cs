using System.Runtime.CompilerServices;
using System.Text;

namespace CSharpPractice.V10Features;

[InterpolatedStringHandler]
public struct ExclamationAppendingHandler
{
    private Lazy<StringBuilder> _builder;

    public ExclamationAppendingHandler(int literalLength, int formattedCount)
    {
        _builder = new Lazy<StringBuilder>(() => new StringBuilder(literalLength));
    }

    public void AppendLiteral(string s)
    {
        _builder.Value.Append(s);
    }

    public void AppendFormatted<T>(T t)
    {
        _builder.Value.Append(t?.ToString());
    }

    public string GetFormattedText()
    {
        _builder.Value.Append("!");
        return _builder.Value.ToString();
    }
}

[InterpolatedStringHandler]
public struct ExceptionThrowingHandler
{
    private Lazy<StringBuilder> _builder;

    public ExceptionThrowingHandler(int literalLength, int formattedCount)
    {
        _builder = new Lazy<StringBuilder>(() => new StringBuilder(literalLength));
    }

    public void AppendLiteral(string s)
    {
        _builder.Value.Append(s);
    }

    public void AppendFormatted<T>(T t)
    {
        _builder.Value.Append(t?.ToString());
    }

    public string GetFormattedText()
    {
        throw new InvalidOperationException(_builder.Value.ToString());
    }
}

public enum LogLevel
{
    Off,
    Critical,
    Error,
    Warning,
    Information,
    Trace
}

public interface ILogWriter
{
    void WriteLogMessage(string logMessage);
}

public class LogWriter : ILogWriter
{
    public void WriteLogMessage(string logMessage)
    {
        Console.WriteLine(logMessage);
    }
}

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