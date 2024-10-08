
using Tinkering.Classes;

namespace Tinkering;
internal partial class Program
{
    static async Task Main(string[] args)
    {
        await Setup();
        AnsiConsole.MarkupLine($"[{Color.Aqua}]GetLogOptions().Use[/]: {AppSettings.GetLogOptions().Use}");
        AnsiConsole.MarkupLine($"[{Color.Aqua}]AppSettings.GetLogOptions().Destination[/]: {AppSettings.GetLogOptions().Destination}");
        ExitPrompt();
    }
}