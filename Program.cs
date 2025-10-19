using Avalonia;
using System;

namespace AnimalApp;

class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}


// using AnimalApp.Models;
// using System;
// using System.Collections.Generic;

// var animals = new List<Animal>
// {
//     new Cat { Name="Muri", Age=3 },
//     new Dog { Name="Buddy", Age=5 },
//     new Bird { Name="Tweety", Age=1 }
// };

// foreach (var a in animals)
// {
//     Console.WriteLine(a.Describe());
//     Console.WriteLine(a.MakeSound());
//     if (a is ICrazyAction crazy) crazy.ActCrazy();
// }

