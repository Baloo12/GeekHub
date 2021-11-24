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
    }
}