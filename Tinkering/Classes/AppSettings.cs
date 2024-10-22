using Microsoft.Extensions.Configuration;
using Tinkering.Classes.Configuration;
using Tinkering.Models;

namespace Tinkering.Classes;
public class AppSettings
{
    private static readonly IConfigurationRoot Configuration = Build();
    public static Logging GetLogOptions() => InitOptions<Logging>("LogOptions");
    public static Role Role() => InitOptions<Role>("Role");
    public static CentralSettings Settings() => InitOptions<CentralSettings>("CentralSettings");
    public static IConfigurationRoot Build() => ApplicationConfiguration.ConfigurationRoot();
    public static T InitOptions<T>(string section) where T : new()
        => Configuration.GetSection(section).Get<T>();
}
