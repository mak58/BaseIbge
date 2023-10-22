using Asp.Versioning;
using BaseIbge.Domain.Interfaces;
using BaseIbge.Infrastructure.Data;
using BaseIbge.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace BaseIbge.Infrastructure.CrossCutting.Ioc;

public static class ServiceExtensionsInfra
{
    public static IServiceCollection AddServicesInfra(
            this IServiceCollection services,
            IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("Database")));

        services.AddIdentity<IdentityUser, IdentityRole>(options => 
        {
            options.Password.RequireDigit = false;
            options.Password.RequireUppercase = false;
        })
        .AddEntityFrameworkStores<AppDbContext>();        

        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));        
        services.AddScoped<IPlaceRepository, PlaceRepository>();

        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
            options.ApiVersionReader = new HeaderApiVersionReader("Api-Version");
        });
        services.AddEndpointsApiExplorer();        
        
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo 
            { Title = "Base Ibge API", 
                Version = "v1" ,
                    Description = "This Api returns the Ibge Id, city name and State from Brazil! \n It's possible input new data, update and remove."});
        });
    
        return services;
    }
}