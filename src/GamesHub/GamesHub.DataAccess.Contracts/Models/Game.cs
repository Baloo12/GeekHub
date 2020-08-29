namespace GamesHub.DataAccess.Contracts.Models
{
    using System;

    public class Game
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Rank Rank { get; set; }

        public Guid RankId { get; set; }

        public double Rating { get; set; }
    }
}