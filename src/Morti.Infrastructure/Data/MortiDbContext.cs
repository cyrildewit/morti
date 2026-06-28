using Microsoft.EntityFrameworkCore;

namespace Morti.Infrastructure.Data;

public class MortiDbContext(DbContextOptions<MortiDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MortiDbContext).Assembly);
    }
}
