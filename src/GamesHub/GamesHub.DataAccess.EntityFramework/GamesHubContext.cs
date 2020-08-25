namespace GamesHub.DataAccess.EntityFramework
{
    using GamesHub.DataAccess.Contracts.Models;

    using Microsoft.EntityFrameworkCore;

    public class GamesHubContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost\\sqlexpress;Database=GamesHub;Trusted_Connection=True;");
        }
    }
}