using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using Tinkering.Classes;
using Tinkering.Classes.Configuration;

// ReSharper disable once CheckNamespace
namespace Tinkering;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = AppSettings.Settings().Title;
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
    private static async Task Setup()
    {
        var services = ApplicationConfiguration.ConfigureServices();
        await using var serviceProvider = services.BuildServiceProvider();
        serviceProvider.GetService<SetupServices>()!.GetConnectionStrings();
    }
}
