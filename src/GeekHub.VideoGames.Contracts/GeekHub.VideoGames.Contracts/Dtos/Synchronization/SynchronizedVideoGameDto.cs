using System;

namespace GeekHub.VideoGames.Contracts.Dtos.Synchronization
{
    public class SynchronizedVideoGameDto
    {
        public Guid Id { get; set; }
        
        public Guid GeekHubId { get; set; }
    }
}