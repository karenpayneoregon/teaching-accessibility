using Microsoft.Extensions.Configuration;
using Tinkering.Classes.Configuration;
using Tinkering.Models;


namespace Tinkering.Classes;
public class AppSettings
{

    public static Logging GetLogOptions()
    {
        Build();
        return InitOptions<Logging>("LogOptions");
    }

    public static Role Role()
    {
        Build();
        return InitOptions<Role>("Role");
    }

    public static FormSettings Settings()
    {
        Build();
        return InitOptions<FormSettings>("FormSettings");
    }
    private static IConfigurationRoot Build() => ApplicationConfiguration.ConfigurationRoot();

    public static T InitOptions<T>(string section) where T : new()
        => ApplicationConfiguration.ConfigurationRoot().GetSection(section).Get<T>();
}