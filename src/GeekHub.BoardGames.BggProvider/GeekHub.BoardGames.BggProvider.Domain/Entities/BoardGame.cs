namespace GeekHub.BoardGames.BggProvider.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BoardGame
    {
        [Required]
        public int BggId { get; set; }

        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int PlayersMax { get; set; }

        public int PlayersMin { get; set; }

        public int YearPublished { get; set; }
    }
}
