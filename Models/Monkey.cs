using System;
using System.Collections.ObjectModel;

namespace AnimalApp.Models;

public class Monkey : Animal, ICrazyAction
{
    public override string MakeSound() => "Ooh ooh aah aah!";

    public void ActCrazy(ObservableCollection<string> log, ObservableCollection<Animal>? allAnimals = null)
    {
        if (allAnimals!.Count < 2)
        {
            log.Add($"{Name} wanted to swap names, but not enough animals!");
            return;
        }

        var rnd = new Random();
        int i = rnd.Next(allAnimals.Count);
        int j;
        do { j = rnd.Next(allAnimals.Count); } while (i == j);


        log.Add($"{Name} swapped names of {allAnimals[i].Name} and {allAnimals[j].Name}!");
        string temp = allAnimals[i]!.Name!;
        allAnimals[i].Name = allAnimals[j].Name;
        allAnimals[j].Name = temp;

        
    }


}
