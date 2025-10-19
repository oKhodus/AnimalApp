namespace AnimalApp.Models;
using System.Collections.ObjectModel;
using System;
public class Dog : Animal, ICrazyAction
{
    public override string MakeSound() => "Woof!";

    public void ActCrazy(ObservableCollection<string> log, ObservableCollection<Animal>? allAnimals = null)
    {
        log.Add($"{Name} barks 5 times: Woof! Woof! Woof! Woof! Woof!");
    }

}
