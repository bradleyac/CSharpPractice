namespace CSharpPractice.V10Features.ExtendedPropertyPatterns;

public record Cat(string Name, bool WantsScritches) : Animal(Name);