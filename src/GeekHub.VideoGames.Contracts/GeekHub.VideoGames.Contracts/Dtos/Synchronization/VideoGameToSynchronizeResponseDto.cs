using System;

namespace GeekHub.VideoGames.Contracts.Dtos.Synchronization
{
    public class VideoGameToSynchronizeResponseDto
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public Guid GeekHubId { get; set; }
    }
}