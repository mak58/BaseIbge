using BaseIbge.Infrastructure.Mappings;
using BasePlace.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BaseIbge.Infrastructure.Data;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Place> Places {get; set;}


    public AppDbContext(DbContextOptions options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);        

        modelBuilder.ApplyConfiguration(new PlacesMap());
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder.Properties<string>()
            .HaveMaxLength(80);
    }



}
