using System.Linq.Expressions;
using CSharpPractice.V10Features.CallerArgumentExpression;

namespace CSharpPractice.Tests.V10Features.CallerArgumentExpression;

public class CallerArgumentExpressionTests
{
    [Fact]
    public void MethodUsingCallerArgumentExpression_ReturnsExpressionText()
    {
        Assert.Equal("this.Equals(null)", ExpressionStringifier.StringifyExpression(this.Equals(null)));
        Assert.Equal("15 == 5 + 10", ExpressionStringifier.StringifyExpression(15 == 5 + 10));
    }
}