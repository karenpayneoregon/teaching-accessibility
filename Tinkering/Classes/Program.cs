using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using Serilog;
using Tinkering.Classes;
using Tinkering.Classes.Configuration;
using static System.DateTime;
using System.Data.SqlTypes;

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
    private static TimeZoneInfo _localTimeZone = TimeZoneInfo.Local;

    /// <summary>
    /// Displays the current local date and time, and checks if the current time is
    /// in daylight saving time.
    /// </summary>
    /// <returns>
    /// A tuple containing the formatted local date and time as a string,
    /// and a boolean indicating whether the current time is in daylight saving time.
    /// </returns>
    /// <remarks>
    /// ClearCachedData is called to ensure changes in the system time zone are reflected
    /// as the system caches the time zone information.
    /// </remarks>
    private static (string dateTime, bool isDaylightSaving) DisplayDateTimeWithDaylightSavingCheck()
    {
        // Reset the cached value from the system time zone.
        System.Globalization.CultureInfo.CurrentCulture.ClearCachedData();

        // Get current UTC time
        var utcNow = DateTimeOffset.UtcNow;

        // Calculate the local time by applying the local time zone offset, considering DST
        DateTimeOffset localTime = TimeZoneInfo.ConvertTime(utcNow, _localTimeZone);

        return (localTime.ToString("dddd, MMMM dd, yyyy h:mm:ss tt"), 
            _localTimeZone.IsDaylightSavingTime(localTime));
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
