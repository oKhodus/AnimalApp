using Avalonia.Controls;
using Avalonia.Interactivity;
using AnimalApp.Models;
using System.Collections.ObjectModel;
using System;
using Avalonia.Markup.Xaml;
using System.Text.RegularExpressions;


namespace AnimalApp;

public partial class AddAnimalWindow : Window
{
    public string? AnimalName { get; private set; }
    public int Age { get; private set; }
    public string? Type { get; private set; }

    public AddAnimalWindow()
    {
        InitializeComponent();

        var AddBtn = this.FindControl<Button>("AddBtn");
        var NameInput = this.FindControl<TextBox>("NameInput");
        var AgeInput = this.FindControl<TextBox>("AgeInput");
        var TypeSelect = this.FindControl<ComboBox>("TypeSelect");

        if (TypeSelect != null)
            TypeSelect.ItemsSource = new ObservableCollection<string> { "Cat", "Dog", "Bird", "Raccoon", "Monkey" };

        TypeSelect!.SelectedIndex = 0;

        AddBtn!.Click += (_, _) =>
        {
            string? name = NameInput!.Text?.Trim();
            if (string.IsNullOrWhiteSpace(name) || !Regex.IsMatch(name, @"^[A-Za-z]+$"))
            {
                ShowMessage("Please enter a valid name (letters only)!");
                return;
            }
            if (!int.TryParse(AgeInput!.Text, out int age) || age <= 0)
            {
                ShowMessage("Please enter a valid age!");
                return;
            }


            // if (!int.TryParse(AgeInput!.Text, out int age)) age = 1;
            AnimalName = name;
            Age = age;
            Type = TypeSelect.SelectedItem as string;
            Close(true);
        };
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private async void ShowMessage(string message)
    {
        var dlg = new Window
        {
            Title = "Error",
            Width = 250,
            Height = 120,
            Content = new TextBlock
            {
                Text = message,
                Margin = new Avalonia.Thickness(10),
                TextWrapping = Avalonia.Media.TextWrapping.Wrap
            }
        };

        await dlg.ShowDialog(this);
    }

}
