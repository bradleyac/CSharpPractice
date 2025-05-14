using System.ComponentModel;

namespace CSharpPractice.Tests.V10Features;

public class ExtendedPropertyPatternsTests
{
    [Fact]
    public void PatternMatching_WithTypeHierarchy_CanUseNestedPropertiesFromMatchedSubtype()
    {
        Cat uintah = new("Uintah", WantsScritches: false);
        Cat tux = new("Tuktoyaktuk", WantsScritches: true);
        Dog dog = new("Dog", Walkies: false);
        Dog dog2 = new("Dog2", Walkies: true);

        Animal[] animals = [uintah, tux, dog, dog2];

        foreach (var animal in animals)
        {
            testAnimal(animal);
        }

        void testAnimal(Animal animal)
        {
            if (animal is Cat { Name.Length: 11, WantsScritches: true })
            {
                Assert.Equal("Tuktoyaktuk", animal.Name);
            }
            else if (animal is Cat { Name.Length: 6 } uintah)
            {
                Assert.False(uintah.WantsScritches);
            }
            else if (animal is Dog { Walkies: false })
            {
                Assert.Equal("Dog", animal.Name);
            }
            else if (animal is Dog { Walkies: true })
            {
                Assert.Equal("Dog2", animal.Name);
            }
            else
            {
                Assert.Fail("Invalid animal!");
            }
        }
    }
}