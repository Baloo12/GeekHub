namespace GamesHub.Web.Models
{
    using System;

    public class TopGamesEntry
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int OverallRank { get; set; }

        public double Rating { get; set; }
    }
}