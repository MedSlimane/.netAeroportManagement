using AM.ApplicationDomain.Domains;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructure;


public class AMContext : DbContext
{
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Plane> Planes { get; set; }
    public DbSet<Passenger> Passengers { get; set; }
    public DbSet<Staff> Staffs { get; set; }
    public DbSet<Traveller> Travellers { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString =
                "Server=localhost,1433;" +
                "Database=AppDb;" +
                "User Id=sa;" +
                "Password=Adminadmin@123!;" +
                "TrustServerCertificate=True;" +
                "Encrypt=False;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Apply configuration classes
        modelBuilder.ApplyConfiguration(new PlaneConfiguration());
        modelBuilder.ApplyConfiguration(new FlightConfiguration());
        
        //TPH
        modelBuilder.Entity<Passenger>()
            .HasDiscriminator<int>("PassengerType")
            .HasValue<Passenger>(0)
            .HasValue<Traveller>(1)
            .HasValue<Staff>(2);
        // TPT
        // modelBuilder.Entity<Traveller>().ToTable("Travellers");
        // modelBuilder.Entity<Staff>().ToTable("Staffs");
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
        
        // Configure all DateTime properties to use 'date' type instead of default 'datetime2'
        configurationBuilder.Properties<DateTime>()
            .HaveColumnType("date");
    }
}