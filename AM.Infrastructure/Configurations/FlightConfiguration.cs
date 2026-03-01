using AM.ApplicationDomain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Configurations;

public class FlightConfiguration : IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> builder)
    {
        // Configure the many-to-many relationship between Flight and Passenger
        builder.HasMany(f => f.Passengers)
            .WithMany(p => p.Flights)
            .UsingEntity(j => j.ToTable("Reservations"));
        
        // Configure the one-to-many relationship between Flight and Plane
        builder.HasOne(f => f.Plane)
            .WithMany(p => p.Flights)
            .HasForeignKey(f => f.PlaneId);
    }
}

