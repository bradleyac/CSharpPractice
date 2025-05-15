namespace CSharpPractice.V10Features.InterpolatedStringHandler;

public class LogWriter : ILogWriter
{
    public void WriteLogMessage(string logMessage)
    {
        Console.WriteLine(logMessage);
    }
}
