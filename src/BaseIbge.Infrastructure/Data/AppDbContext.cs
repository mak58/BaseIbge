using BaseIbge.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseIbge.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Ibge> Ibge {get; set;}

    // public AppDbContext()
    // { }
    public AppDbContext(DbContextOptions options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Ibge>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Ibge>()
            .ToTable("Ibge");
    }
}
