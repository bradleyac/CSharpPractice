using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace CSharpPractice.V10Features.CallerArgumentExpression;

public static class ExpressionStringifier
{
    public static string StringifyExpression(bool expression, [CallerArgumentExpression(nameof(expression))][AllowNull] string expressionText = null) => expressionText!;
}