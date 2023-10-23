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
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

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
            
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme."
            });

            // Add a requirement for the Bearer token
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
            
        });
    
        return services;
    }
}