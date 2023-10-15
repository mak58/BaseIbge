using BaseIbge.Infrastructure.Mappings;
using BasePlace.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseIbge.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Place> Places {get; set;}


    public AppDbContext(DbContextOptions options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfiguration(new PlacesMap());

}
