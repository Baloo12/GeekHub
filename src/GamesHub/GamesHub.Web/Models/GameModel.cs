namespace GamesHub.Web.Models
{
    public class GameModel
    {
        public GameModel(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}