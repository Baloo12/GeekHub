namespace GamesHub.DataAccess.EntityFramework
{
    using GamesHub.DataAccess.Contracts.Models;
    using GamesHub.DataAccess.EntityFramework.Configurations;

    using Microsoft.EntityFrameworkCore;

    public class GamesHubContext : DbContext
    {
        public GamesHubContext(DbContextOptions contextOptions)
            : base(contextOptions)
        {
            // Database.EnsureDeleted();
            // Database.EnsureCreated();
        }

        public GamesHubContext()
        {
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<Rank> Ranks { get; set; }
    }
}