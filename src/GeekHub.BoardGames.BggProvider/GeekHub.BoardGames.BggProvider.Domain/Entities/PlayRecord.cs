namespace GeekHub.BoardGames.BggProvider.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PlayRecord
    {
        [Required]
        public int BggId { get; set; }

        public string Comments { get; set; }

        public DateTime? Date { get; set; }

        [ForeignKey(nameof(GameId))]
        public virtual BoardGame Game { get; set; }

        public Guid GameId { get; set; }

        [Key]
        [Required]
        public Guid Id { get; set; }

        // IDEA: Create Location entity
        public string Location { get; set; }

        public ICollection<PlayParticipant> Participants { get; set; }
    }
}
