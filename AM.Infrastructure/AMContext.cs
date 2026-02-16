using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructure;

public class AMContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }
}