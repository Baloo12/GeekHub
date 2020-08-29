namespace GamesHub.DataAccess.Contracts.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Game
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        [ForeignKey(nameof(RankId))]
        [InverseProperty(nameof(Game))]
        public Rank Rank { get; set; }

        public Guid RankId { get; set; }

        public double Rating { get; set; }
    }
}