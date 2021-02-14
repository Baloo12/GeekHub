namespace GamesHub.Web.Models
{
    using System;

    public class GameOverviewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }

        public string Image { get; set; }

        public bool IsFree { get; set; }

        public string ReleaseDate { get; set; }

        public int RequiredAge { get; set; }

        public string Type { get; set; }

        public string Website { get; set; }

        public int OverallRank { get; set; }

        public double Rating { get; set; }
    }
}