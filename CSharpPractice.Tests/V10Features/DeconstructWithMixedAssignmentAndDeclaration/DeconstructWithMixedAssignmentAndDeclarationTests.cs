using CSharpPractice.V10Features.DeconstructWithMixedAssignmentAndDeclaration;

namespace CSharpPractice.Tests.V10Features.DeconstructWithMixedAssignmentAndDeclaration;

public class DeconstructWithMixedAssignmentAndDeclarationTests
{
    [Fact]
    public void Deconstructor_CanBeUsedWithAssignment()
    {
        var product = new Product("Copper Cable (Spool)", "A spool of copper cable, 500 FT", 100.00m);

        string name = "Fred";
        string desc = "Nice";
        decimal price = 0.0m;

        (name, desc, price) = product;

        Assert.Equal(name, product.Name);
        Assert.Equal(desc, product.Description);
        Assert.Equal(price, product.Price);
    }

    [Fact]
    public void Deconstructor_CanBeUsedWithDeclaration()
    {
        var product = new Product("Copper Cable (Spool)", "A spool of copper cable, 500 FT", 100.00m);

        var (name, desc, price) = product;
        (var name2, var desc2, var price2) = product;
        (string name3, string desc3, decimal price3) = product;

        Assert.Equal(name, name2);
        Assert.Equal(desc, desc2);
        Assert.Equal(price, price2);
        Assert.Equal(name2, name3);
        Assert.Equal(desc2, desc3);
        Assert.Equal(price2, price3);
    }

    [Fact]
    public void Deconstructor_CanBeUsedWithAssignmentAndDeclaration()
    {
        var product = new Product("Copper Cable (Spool)", "A spool of copper cable, 500 FT", 100.00m);

        string name = "Fred";
        decimal price = 0.0m;

        (name, string desc, price) = product;

        Assert.Equal(name, product.Name);
        Assert.Equal(desc, product.Description);
        Assert.Equal(price, product.Price);
    }
}