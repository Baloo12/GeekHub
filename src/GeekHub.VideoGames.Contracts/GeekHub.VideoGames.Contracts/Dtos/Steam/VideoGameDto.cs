using System;
using System.Collections.Generic;

namespace GeekHub.VideoGames.Contracts.Dtos.Steam
{
    public class VideoGameDto
    {
        public Guid Id { get; set; }
        
        public string ExternalId { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }
        
        public string Image { get; set; }

        public bool IsFree { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int RequiredAge { get; set; } // byte?

        public string Website { get; set; }

        public List<DeveloperDto> Developers { get; set; }
        
        public List<GenreDto> Genres { get; set; }

        public List<PlatformDto> Platforms { get; set; }
        
        public List<PublisherDto> Publishers { get; set; }
    }
}