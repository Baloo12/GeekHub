namespace GeekHub.VideoGames.Web.Models
{
    public class VideoGameModel
    {
        public VideoGameModel(string name)
        {
            Name = name;
        }
        
        public string Name { get; set; }
    }
}