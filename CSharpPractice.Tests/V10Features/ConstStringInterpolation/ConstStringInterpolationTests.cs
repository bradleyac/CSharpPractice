using CSharpPractice.V10Features.ConstStringInterpolation;

namespace CSharpPractice.Tests.V10Features.ConstStringInterpolation;

public class ConstStringInterpolationTests
{
    [Theory]
    [InlineData(StringConstants.UintahName, "Uintah Bradley")]
    [InlineData(StringConstants.TuxName, "Tuktoyaktuk Bradley")]
    [InlineData(StringConstants.BooName, "Boo Bradley")]
    public void InterpolatedStrings_WhenConst_CanBeUsedStatically(string name, string expected)
    {
        Assert.Equal(name, expected);
    }
}