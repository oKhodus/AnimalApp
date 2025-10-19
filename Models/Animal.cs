namespace AnimalApp.Models;

public abstract class Animal
{
    public string? Name { get; set; }
    public int Age { get; set; }

    public virtual string Describe() => $"{Name}, age {Age}";

    public abstract string MakeSound();
}
