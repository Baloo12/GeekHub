using System.Collections.Generic;

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

        public string Description { get; set; }

        public string Image { get; set; }

        public bool IsFree { get; set; }

        public string ReleaseDate { get; set; }

        public int RequiredAge { get; set; }

        public string Type { get; set; }

        public string Website { get; set; }

        [InverseProperty(nameof(Game))]
        public ICollection<GameDeveloper> GameDevelopers { get; set; }
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