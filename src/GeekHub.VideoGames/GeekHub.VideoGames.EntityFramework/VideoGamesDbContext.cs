using GeekHub.VideoGames.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeekHub.VideoGames.EntityFramework
{
    public class VideoGamesDbContext: DbContext
    {
        public VideoGamesDbContext(DbContextOptions contextOptions)
            : base(contextOptions)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public VideoGamesDbContext()
        {
        }

        public DbSet<VideoGame> VideoGames { get; set; }
    }
}