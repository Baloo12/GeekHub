using System;

namespace GeekHub.VideoGames.Contracts.Dtos.Synchronization
{
    public class VideoGameToSynchronizeRequestDto
    {
        public Guid Id { get; set; }//
        
        public string Name { get; set; }
    }
}