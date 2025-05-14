namespace CSharpPractice.V10Features;

public record Animal(string Name);
public record Dog(string Name, bool Walkies) : Animal(Name);
public record Cat(string Name, bool WantsScritches) : Animal(Name);