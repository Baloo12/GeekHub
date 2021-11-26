namespace GeekHub.BoardGames.BggProvider.Web.Models
{
    public class BoardGameModel
    {
        public string Name { get; set; }
        
        public int BggId { get; set; }
        
        public int PlayersMax { get; set; }

        public int PlayersMin { get; set; }

        public int YearPublished { get; set; }
    }
}
