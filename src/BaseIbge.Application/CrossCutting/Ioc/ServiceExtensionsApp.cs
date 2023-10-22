using System.Text;
using BaseIbge.Application.Interfaces;
using BaseIbge.Application.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BaseIbge.Application;

public static class ServiceExtensionsApp
{
    public static IServiceCollection AddServicesApp(
            this IServiceCollection services,
            IConfiguration configuration)
    {                        
        services.AddScoped<IPlacesApplication, PlacesApplication>();
        services.AddScoped<IUserApplication, UserApplication>();
        services.AddScoped<ILoginApplication, LoginApplication>();

        services.AddAuthorization();
        services.AddAuthentication(x => 
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;    
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateActor = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["JwtTokensSettings:Issuer"],
                ValidAudience = configuration["JwtTokensSettings:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtTokensSettings:SecretKey"]))
            };

        });

        return services;
    }
}
