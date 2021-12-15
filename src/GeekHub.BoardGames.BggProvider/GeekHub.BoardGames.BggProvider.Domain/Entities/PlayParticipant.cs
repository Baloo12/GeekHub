namespace GeekHub.BoardGames.BggProvider.Domain.Entities
{
    public class PlayParticipant
    {
        public string Color { get; set; }

        public bool IsNew { get; set; }

        public string Name { get; set; }

        public int Score { get; set; }

        public string StartPosition { get; set; }

        public bool Win { get; set; }
    }
}
