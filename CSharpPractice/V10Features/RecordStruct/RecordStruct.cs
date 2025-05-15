namespace CSharpPractice.V10Features;

public record struct PersonStruct(string FirstName, string LastName);
public record struct PersonStructV2(string FirstName, string LastName);
public record PersonClass(string FirstName, string LastName);
public record PersonClassV2(string FirstName, string LastName) : PersonClass(FirstName, LastName);