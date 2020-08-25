namespace GamesHub.DataAccess.EntityFramework
{
    using GamesHub.DataAccess.EntityFramework.Entities;

    using Microsoft.EntityFrameworkCore;

    public class GamesHubContext : DbContext
    {
        public DbSet<GameEntity> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost\\sqlexpress;Database=GamesHub;Trusted_Connection=True;");
        }
    }
}