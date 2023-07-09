using System;
using System.ComponentModel.DataAnnotations;

namespace GeekHub.VideoGames.Domain.Entities
{
    public class VideoGame
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }

        public string Image { get; set; }

        public bool IsFree { get; set; }

        public string ReleaseDate { get; set; }

        public int RequiredAge { get; set; }

        public string Type { get; set; }

        public string Website { get; set; }
        
        public DateTime ModifiedAt { get; set; }
    }
}