namespace GamesHub.DataAccess.Contracts.Models
{
    using System;

    public class Rank
    {
        public Game Game { get; set; }

        public Guid GameId { get; set; }

        public Guid Id { get; set; }

        public int Overall { get; set; }
    }
}