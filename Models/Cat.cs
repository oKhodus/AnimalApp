namespace AnimalApp.Models;
using System.Collections.ObjectModel;
using System;

public class Cat : Animal, ICrazyAction
{
    public override string MakeSound() => "Meow!";

    public void ActCrazy(ObservableCollection<string> log, ObservableCollection<Animal>? allAnimals = null)
    {
        log.Add($"{Name} stole cheese from the kitchen!");
    }

}
