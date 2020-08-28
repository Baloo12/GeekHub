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
        }

        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new GamesConfiguration());
        }
    }
}