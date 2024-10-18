
using Tinkering.Classes;

namespace Tinkering;
internal partial class Program
{
    static async Task Main(string[] args)
    {
        await Setup();
        AppSettingExample();
        ExitPrompt();
    }

    private static void Parenthesized<T>(T value)
    {
        if (value is not (float or double)) return;
        Console.WriteLine(value);
    }

    private static void AppSettingExample()
    {
        AnsiConsole.MarkupLine($"[{Color.Aqua}]GetLogOptions().Use[/]: {AppSettings.GetLogOptions().Use}");
        AnsiConsole.MarkupLine($"[{Color.Aqua}]AppSettings.GetLogOptions().Destination[/]: {AppSettings.GetLogOptions().Destination}");
    }
}