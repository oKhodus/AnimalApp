namespace AnimalApp.Models;

using System.Collections.ObjectModel;
using System;


public class Tiger : Animal, ICrazyAction
{
    public override string MakeSound() => "Roar!";
    public void ActCrazy(ObservableCollection<string> log, ObservableCollection<Animal>? animals)
    {
        if (animals != null && animals.Count > 1)
        {
            var rand = new Random();
            var victim = animals[rand.Next(animals.Count)];
            if (victim != this) log.Add($"{Name} scared {victim.Name}!");
        }
    }
}