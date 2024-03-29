﻿namespace GamesHub.DataAccess.EntityFramework
{
    using GamesHub.DataAccess.Contracts.Models;

    using Microsoft.EntityFrameworkCore;

    public class GamesHubContext : DbContext
    {
        public GamesHubContext(DbContextOptions contextOptions)
            : base(contextOptions)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public GamesHubContext()
        {
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<Rank> Ranks { get; set; }

        public DbSet<Developer> Developers { get; set; }

        public DbSet<GameDeveloper> GameDevelopers { get; set; }
    }
}