using System;

namespace GeekHub.SteamProvider.Domain.Exceptions
{
    public class VideoGameNotExistsInSteamException : Exception
    {
        public VideoGameNotExistsInSteamException(string steamId) : base($"Video game with Steam Id: {steamId} not exists in steam.")
        {
            
        }
    }
}