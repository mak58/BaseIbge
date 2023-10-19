using BasePlace.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseIbge.Infrastructure.Mappings;

public class PlacesMap : IEntityTypeConfiguration<Place>
{
    /// <summary>
    /// Fluent API
    /// </summary>
    public void Configure(EntityTypeBuilder<Place> builder)
    {
        builder.HasKey(key => key.Id);

        builder.ToTable("Places");

        builder.Ignore("Notification");

        builder.Property(x => x.Id)
            .HasMaxLength(7);        
        
        builder.Property(x => x.State)
            .HasMaxLength(2);
        
        builder.Property(x => x.City)
            .HasMaxLength(80);
    }
    
}
