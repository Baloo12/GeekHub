using System;
using System.Collections.Generic;
using GeekHub.SteamProvider.Domain.Entities;

namespace GeekHub.SteamProvider.Domain.Models.External
{
    public class SteamVideoGameDto
    {
        public string SteamId { get; set; }
        
        public string Description { get; set; }

        public List<Developer> Developers { get; set; }
        
        public List<Genre> Genres { get; set; }

        public string Image { get; set; }

        public bool IsFree { get; set; }

        public string Name { get; set; }

        public List<Platform> Platforms { get; set; }
        
        public List<Publisher> Publishers { get; set; }

        public string ReleaseDate { get; set; }

        public int RequiredAge { get; set; }

        public string Type { get; set; }

        public string Website { get; set; }
        
        public DateTime ModifiedAt { get; set; }
    }
}