using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace CSharpPractice.V10Features;

public static class CallerArgumentExpression
{
    public static string ReturnExpression(bool expression, [CallerArgumentExpression(nameof(expression))][AllowNull] string expressionText = null) => expressionText!;
}