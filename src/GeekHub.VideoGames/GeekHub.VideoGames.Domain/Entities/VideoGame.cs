using System;
using System.ComponentModel.DataAnnotations;

namespace GeekHub.VideoGames.Domain.Entities
{
    public class VideoGame
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Name { get; set; }
    }
}