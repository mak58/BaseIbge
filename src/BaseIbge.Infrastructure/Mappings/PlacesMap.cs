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
    }
    
}
