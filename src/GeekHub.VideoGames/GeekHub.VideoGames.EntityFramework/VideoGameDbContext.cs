using GeekHub.VideoGames.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeekHub.VideoGames.EntityFramework
{
    public class VideoGameDbContext: DbContext
    {
        public VideoGameDbContext(DbContextOptions contextOptions)
            : base(contextOptions)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public VideoGameDbContext()
        {
        }

        public DbSet<VideoGame> VideoGames { get; set; }
    }
}