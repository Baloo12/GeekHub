using GamesHub.DataAccess.EntityFramework.Configurations;

namespace GamesHub.DataAccess.EntityFramework
{
    using GamesHub.DataAccess.Contracts.Models;

    using Microsoft.EntityFrameworkCore;

    public class GamesHubContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new GamesConfiguration());
        }
    }
}