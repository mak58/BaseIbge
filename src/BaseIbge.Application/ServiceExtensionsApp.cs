using BaseIbge.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BaseIbge.Application;

public static class ServiceExtensionsApp
{
    public static IServiceCollection AddServicesApp(
            this IServiceCollection services,
            IConfiguration configuration)
    {                        
        services.AddScoped<IPlacesApplication, PlacesApplication>();

        return services;
    }
}
