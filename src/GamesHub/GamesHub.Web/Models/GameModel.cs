namespace GamesHub.Web.Models
{
    using System.Collections.Generic;

    public class GameModel
    {
        public GameModel(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public bool IsFree { get; set; }

        public string ReleaseDate { get; set; }

        public int RequiredAge { get; set; }

        public string Type { get; set; }

        public string Website { get; set; }

        public List<DeveloperModel> Developers { get; set; }
    }
}