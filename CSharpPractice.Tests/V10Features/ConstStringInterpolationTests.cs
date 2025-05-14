namespace CSharpPractice.Tests.V10Features;

public class ConstStringInterpolationTests
{
    [Theory]
    [InlineData(ConstStringInterpolation.UintahName, "Uintah Bradley")]
    [InlineData(ConstStringInterpolation.TuxName, "Tuktoyaktuk Bradley")]
    [InlineData(ConstStringInterpolation.BooName, "Boo Bradley")]
    public void InterpolatedStrings_WhenConst_CanBeUsedStatically(string name, string expected)
    {
        Assert.Equal(name, expected);
    }
}