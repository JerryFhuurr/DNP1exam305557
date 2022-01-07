using Microsoft.EntityFrameworkCore;
using VolumeWebService.VolumeCalculator;

namespace VolumeWebService.Persistence
{
    public class ResultDbContext : DbContext
    {
        public DbSet<VolumeResult> Results { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // name of database
            optionsBuilder.UseSqlite("Data Source = Results.db");
        }
    }
}
