using AM.ApplicationDomain.Domains;
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
                "Password=admin;" +
                "TrustServerCertificate=True;" +
                "Encrypt=False;";

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}