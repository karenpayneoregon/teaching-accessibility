using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using Serilog;
using Tinkering.Classes;
using Tinkering.Classes.Configuration;
using static System.DateTime;

// ReSharper disable once CheckNamespace
namespace Tinkering;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        SetupLogging.Development();
        Account account = new() { Id = 1, Username = "JohnDoe", AccountType = "Admin" };
        Log.Information("Login for {@User}", account);
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

public class SetupLogging
{
    public static void Development()
    {

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .Destructure.ByTransformingWhere<Account>(
                t => false,
                a => new { id = a.Id, a.Username, a.AccountType })
            .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", $"{Now.Year}-{Now.Month}-{Now.Day}", "Log.txt"),
                rollingInterval: RollingInterval.Infinite,
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
            .CreateLogger();
    }


}
public class Account
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string AccountType { get; set; }
}
