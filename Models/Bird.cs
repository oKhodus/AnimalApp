namespace AnimalApp.Models;

using System.Collections.ObjectModel;

using System;
public class Bird : Animal, IFlyable, ICrazyAction
{
    public bool IsFlying { get; private set; } = false;

    public override string MakeSound() => "CHIRP!!!";

    public void Fly() => IsFlying = !IsFlying;

    public void ActCrazy(ObservableCollection<string> log, ObservableCollection<Animal>? allAnimals = null)
    {
        Fly();
        log.Add($"{Name} {(IsFlying ? "is flying" : "landed")} and chirps: {MakeSound()}");
    }

}
