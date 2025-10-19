using System;
using System.Collections.ObjectModel;

namespace AnimalApp.Models;

public class Raccoon : Animal, ICrazyAction
{
    private static readonly string[] Items = { "shiny gadget", "coin", "watch", "bottle cap", "ring" };

    public override string MakeSound() => "Squeak!";

    public void ActCrazy(ObservableCollection<string> log, ObservableCollection<Animal>? allAnimals = null)
    {
        var rnd = new Random();
        string foundItem = Items[rnd.Next(Items.Length)];
        log.Add($"{Name} found a {foundItem}!");
    }
}
