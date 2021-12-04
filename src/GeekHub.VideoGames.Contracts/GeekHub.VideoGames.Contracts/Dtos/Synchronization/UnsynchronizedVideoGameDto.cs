using System;

namespace GeekHub.VideoGames.Contracts.Dtos.Synchronization
{
    public class UnsynchronizedVideoGameDto
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
    }
}