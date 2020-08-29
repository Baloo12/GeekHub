namespace GamesHub.Web.Models
{
    using System;

    public class TopGamesEntry
    {
        public int GlobalRank { get; set; }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Rate { get; set; }
    }
}