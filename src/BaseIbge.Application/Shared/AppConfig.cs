using Microsoft.Extensions.Configuration;

namespace BaseIbge.Application.Shared;
public static class AppConfig
{
    public static string GetConfiguration(string configurationKey)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        
        var key = configuration[configurationKey]; 
        return key;                
    }
}


