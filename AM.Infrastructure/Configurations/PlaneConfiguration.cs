using AM.ApplicationDomain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Configurations;

public class PlaneConfiguration : IEntityTypeConfiguration<Plane>
{
    public void Configure(EntityTypeBuilder<Plane> builder)
    {
        // PlaneId is the primary key
        builder.HasKey(p => p.PlaneId);
        
        // Set table name to "MyPlanes"
        builder.ToTable("MyPlanes");
        
        // Set column name for Capacity to "PlaneCapacity"
        builder.Property(p => p.Capacity)
            .HasColumnName("PlaneCapacity");
    }
}

