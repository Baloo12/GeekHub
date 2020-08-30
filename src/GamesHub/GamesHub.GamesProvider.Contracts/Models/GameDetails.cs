using System.Collections.Generic;

namespace GamesHub.GamesProvider.Contracts.Models
{
    public class GameDetails
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string Website { get; set; }

        public bool IsFree { get; set; }

        public string Type { get; set; }

        public int RequiredAge { get; set; }

        public List<string> Publishers { get; set; }

        public List<string> Developers { get; set; }

        public List<string> Platforms { get; set; }

        public List<string> Genres { get; set; }

        public string ReleaseDate { get; set; }
    }
}
