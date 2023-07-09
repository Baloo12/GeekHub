namespace GeekHub.BoardGames.BggProvider.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PlayParticipant
    {
        public string Color { get; set; }

        public Guid Id { get; set; }

        public bool IsNew { get; set; }

        public string Name { get; set; }

        [ForeignKey(nameof(PlayRecordId))]
        public PlayRecord PlayRecord { get; set; }

        public Guid PlayRecordId { get; set; }

        public int Score { get; set; }

        public string StartPosition { get; set; }

        public bool Win { get; set; }
    }
}
