namespace AnimalApp.Models;

using System.Collections.ObjectModel;

public interface ICrazyAction
{
    void ActCrazy(ObservableCollection<string> log, ObservableCollection<Animal>? allAnimals = null);
}
