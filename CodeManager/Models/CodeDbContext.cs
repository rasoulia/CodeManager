using Microsoft.EntityFrameworkCore;

namespace CodeManager.Models
{
    public class CodeDbContext : DbContext
    {
        public DbSet<Code> Codes { get; set; }
        public CodeDbContext()
        {
            Database.MigrateAsync().Wait();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!Directory.Exists("Database"))
            {
                Directory.CreateDirectory("Database");
            }

            optionsBuilder.UseSqlite("Data Source=Database\\Code.db");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
