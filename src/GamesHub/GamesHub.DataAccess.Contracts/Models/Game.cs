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

        // [ForeignKey(nameof(AppReferenceId))]
        // [InverseProperty(nameof(Game))]
        // public GameAppReference AppReference { get; set; }
        // public GameAppReference AppReferenceId { get; set; }
        public double Rating { get; set; }

        public string SteamAppId { get; set; }
    }

    // public class GameAppReference
    // {
    // [InverseProperty("AppReference")]
    // public Game Game { get; set; }
    // [Key]
    // public Guid Id { get; set; }
    // public string SteamAppId { get; set; }
    // }
}