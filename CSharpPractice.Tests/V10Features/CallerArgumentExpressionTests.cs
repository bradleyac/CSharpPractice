using System.Linq.Expressions;

namespace CSharpPractice.Tests.V10Features;

public class CallerArgumentExpressionTests
{
    [Fact]
    public void MethodUsingCallerArgumentExpression_ReturnsExpressionText()
    {
        Assert.Equal("this.Equals(null)", CallerArgumentExpression.ReturnExpression(this.Equals(null)));
        Assert.Equal("15 == 5 + 10", CallerArgumentExpression.ReturnExpression(15 == 5 + 10));
    }
}