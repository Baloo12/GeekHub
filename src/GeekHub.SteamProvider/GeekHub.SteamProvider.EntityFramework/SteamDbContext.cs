using GeekHub.SteamProvider.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeekHub.SteamProvider.EntityFramework
{
    public class SteamDbContext : DbContext
    {
        public SteamDbContext(DbContextOptions contextOptions)
            : base(contextOptions)
        {
            // Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public SteamDbContext()
        {
        }

        public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}