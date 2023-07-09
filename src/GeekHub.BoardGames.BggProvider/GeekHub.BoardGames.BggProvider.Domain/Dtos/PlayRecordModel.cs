namespace GeekHub.BoardGames.BggProvider.Domain.Dtos
{
    using System;

    public class PlayRecordModel
    {
        public int BggId { get; set; }

        public string Comments { get; set; }

        public DateTime? Date { get; set; }

        public PlayRecordGameModel Game { get; set; }

        public string Location { get; set; }
    }

    public class PlayRecordGameModel
    {
        public int BggId { get; set; }

        //public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
