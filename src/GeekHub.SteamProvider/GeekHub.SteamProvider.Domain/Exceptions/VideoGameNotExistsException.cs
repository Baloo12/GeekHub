using System;

namespace GeekHub.SteamProvider.Domain.Exceptions
{
    public class VideoGameNotExistsException : Exception
    {
        public VideoGameNotExistsException(Guid id) : base($"Video game with Id: {id} not exists.")
        {
            
        }
        
        public VideoGameNotExistsException(string steamId) : base($"Video game with Steam Id: {steamId} not exists.")
        {
            
        }
    }
}