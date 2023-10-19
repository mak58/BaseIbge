using BaseIbge.Application.Interfaces;
using BaseIbge.Application.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BaseIbge.Application;

public static class ServiceExtensionsApp
{
    public static IServiceCollection AddServicesApp(
            this IServiceCollection services)
    {                        
        services.AddScoped<IPlacesApplication, PlacesApplication>();
        services.AddScoped<IUserApplication, UserApplication>();

        return services;
    }
}
