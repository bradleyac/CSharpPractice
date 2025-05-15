namespace CSharpPractice.Tests.V10Features.RecordStruct;

public class RecordStructTests
{
    [Fact]
    public void StructVsClass_Mutability_RecordStructPropertiesCanMutate()
    {
        PersonStruct person = new("Andrew", "Bradley");
        PersonStruct person2 = person;

        Assert.Equal(person, person2);

        person.FirstName = "Leanne";

        Assert.NotEqual(person, person2);
    }

    [Fact]
    public void StructVsClass_Mutability_RecordClassPropertiesCannotMutate()
    {
        PersonClass person = new("Andrew", "Bradley");
        PersonClass person2 = new("Andrew", "Bradley");

        Assert.Equal(person, person2);

        // Cannot do this:
        // person.FirstName = "Leanne";

        Assert.Equal(person, person2);
    }

    [Fact]
    public void StructVsClass_Equality_RecordClassAndStructWithSamePropertyValuesDoNotCompareEqual()
    {
        PersonStruct personStruct = new("Andrew", "Bradley");
        PersonClass personClass = new("Andrew", "Bradley");

        Assert.Equivalent(personStruct, personClass, strict: true);
        Assert.NotEqual<object>(personStruct, personClass);
    }

    [Fact]
    public void StructVsClass_Equality_TwoDifferentRecordStructsWithSamePropertyValuesDoNotCompareEqual()
    {
        PersonStruct personStruct = new("Andrew", "Bradley");
        PersonStructV2 personStructV2 = new("Andrew", "Bradley");

        Assert.Equivalent(personStruct, personStructV2, strict: true);
        Assert.NotEqual<object>(personStruct, personStructV2);
    }

    [Fact]
    public void StructVsClass_Equality_DerivedRecordClassesWithSamePropertyValuesDoNotCompareEqual()
    {
        PersonClass personClass = new("Andrew", "Bradley");
        PersonClassV2 personClassV2 = new("Andrew", "Bradley");

        Assert.Equivalent(personClass, personClassV2);
        Assert.NotEqual(personClass, personClassV2);
    }

    [Fact]
    public void StructVsClass_Equality_RecordClassesHaveValueEquality()
    {
        PersonClass personClass = new("Andrew", "Bradley");
        PersonClass personClass2 = new("Andrew", "Bradley");

        Assert.Equal(personClass, personClass2);
    }
}
