namespace AnimalApp.Models;

using System.Collections.ObjectModel;
using System;

public class Parrot : Animal, ICrazyAction
{
    public override string MakeSound() => "Squawk!";
    public void ActCrazy(ObservableCollection<string> log, ObservableCollection<Animal>? animals)
    {
        if (animals != null && animals.Count > 0)
        {
            var last = animals[^1];
            log.Add($"{Name} mimics {last.Name}: {last.MakeSound()}");
        }
        else log.Add($"{Name} tried to mimic, but no animals around!");
    }
}