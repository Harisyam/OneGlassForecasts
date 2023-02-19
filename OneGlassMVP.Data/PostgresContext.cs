using Microsoft.EntityFrameworkCore;
using OneGlassForecasts.Models;

namespace OneGlassForecasts.Data
{
    public class PostgresContext : DbContext
    {
        public PostgresContext(DbContextOptions<PostgresContext> options) : base(options)
        {
        }

        public DbSet<Forecast> forecasts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("oneglass").Entity<Forecast>().HasNoKey();
        }
    }
}
