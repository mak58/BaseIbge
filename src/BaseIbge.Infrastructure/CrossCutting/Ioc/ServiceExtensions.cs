using BaseIbge.Domain.Interfaces;
using BaseIbge.Infrastructure.Data;
using BaseIbge.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BaseIbge.Infrastructure.CrossCutting.Ioc;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(
            this IServiceCollection services,
            IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("Database")));

        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}
