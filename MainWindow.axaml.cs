using Avalonia.Controls;
using Avalonia.Interactivity;
using AnimalApp.Models;
using System.Collections.ObjectModel;

namespace AnimalApp;

public partial class MainWindow : Window
{
    private ObservableCollection<Animal> animals = new ObservableCollection<Animal>();
    private ObservableCollection<string> log = new ObservableCollection<string>();

    public MainWindow()
    {
        InitializeComponent();

        animals.Add(new Cat { Name = "Barsik", Age = 3 });
        animals.Add(new Dog { Name = "Muhtar", Age = 5 });
        animals.Add(new Bird { Name = "Kesha", Age = 1 });
        animals.Add(new Monkey { Name = "Biba", Age = 6 });
        animals.Add(new Raccoon { Name = "Rocket", Age = 2 });

        AnimalList!.ItemsSource = animals;
        ActionLog!.ItemsSource = log;

        AnimalList!.SelectionChanged += (s, e) =>
        {
            if (AnimalList!.SelectedItem is Animal a)
                AnimalDetails!.Text = a.Describe();
        };

        MakeSoundBtn!.Click += (_, _) =>
        {
            var selected = AnimalList!.SelectedItem as Animal;
            if (selected == null)
            {
                log.Add("No animal selected!");
                return;
            }

            if (AnimalList!.SelectedItem is Animal a)
                log.Add($"{a.Name} {a.MakeSound()}");

        };

        FeedBtn!.Click += (_, _) =>
        {
            var selected = AnimalList!.SelectedItem as Animal;
            if (selected == null)
            {
                log.Add("No animal selected!");
                return;
            }

            string input = FeedInput!.Text?.Trim() ?? "";
            if (input.Length == 0)
            {
                log.Add($"{selected.Name} was not fed. Please enter food!");
                return;
            }

            log.Add($"{selected.Name} ate {input}");
            FeedInput.Text = "";
        };

        RemoveAnimalBtn!.Click += (_, _) =>
        {
            var selected = AnimalList!.SelectedItem as Animal;
            if (selected == null)
            {
                log.Add("No animal selected!");
                return;
            }

            if (AnimalList!.SelectedItem is Animal a)
                animals.Remove(a);
        };
        CrazyActionBtn!.Click += (_, _) =>
        {
            var selected = AnimalList!.SelectedItem as Animal;
            if (selected == null)
            {
                log.Add("No animal selected!");
                return;
            }

            if (AnimalList!.SelectedItem is ICrazyAction crazyAnimal)
            {
                crazyAnimal.ActCrazy(log, animals);

                var a = AnimalList.SelectedItem as Animal;
                if (a != null)
                    AnimalDetails!.Text = a.Describe();
            }
        };

        AddAnimalBtn!.Click += async (_, _) =>
        {
            var win = new AddAnimalWindow();
            bool? result = await win.ShowDialog<bool?>(this); 
            if (result == true)
            {
                Animal? newAnimal = win.Type switch
                {
                    "Cat" => new Cat { Name = win.AnimalName!, Age = win.Age },
                    "Dog" => new Dog { Name = win.AnimalName!, Age = win.Age },
                    "Bird" => new Bird { Name = win.AnimalName!, Age = win.Age },
                    "Raccoon" => new Raccoon { Name = win.AnimalName!, Age = win.Age },
                    "Monkey" => new Monkey { Name = win.AnimalName!, Age = win.Age },
                    "Parrot" => new Parrot { Name = win.AnimalName!, Age = win.Age },
                    "Tiger" => new Tiger { Name = win.AnimalName!, Age = win.Age },
                    "Elephant" => new Elephant { Name = win.AnimalName!, Age = win.Age },
                    _ => null
                };
                if (newAnimal != null)
                    animals.Add(newAnimal);
            }
        };


    }
}
