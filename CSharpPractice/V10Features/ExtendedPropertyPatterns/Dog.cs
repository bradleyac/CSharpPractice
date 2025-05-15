namespace CSharpPractice.V10Features.ExtendedPropertyPatterns;

public record Dog(string Name, bool Walkies) : Animal(Name);
