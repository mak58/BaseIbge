using Microsoft.Extensions.Configuration;

namespace BaseIbge.Application.Shared;

public static class AppConfig
{
    public static IConfiguration  Configuration  { get; private set; }

    static AppConfig()
    {
        Configuration  = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
    }

    public static string GetValue(string key)
    {
        return Configuration[key];
    }
}

