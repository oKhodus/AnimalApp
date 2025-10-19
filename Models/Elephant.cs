namespace AnimalApp.Models;

using System.Collections.ObjectModel;
using System;

public class Elephant : Animal, ICrazyAction
{
    public override string MakeSound() => "Trumpet!";
    public void ActCrazy(ObservableCollection<string> log, ObservableCollection<Animal>? animals)
    {
        log.Add($"{Name} stomped and shook the ground!");
    }
}