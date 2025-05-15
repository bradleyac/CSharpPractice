using System.Runtime.CompilerServices;
using System.Text;

namespace CSharpPractice.V10Features.InterpolatedStringHandler;

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
