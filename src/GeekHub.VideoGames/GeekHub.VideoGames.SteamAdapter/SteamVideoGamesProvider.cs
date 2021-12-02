using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GeekHub.SteamProvider.Client;
using GeekHub.VideoGames.Domain.Interfaces;
using VideoGameDto = GeekHub.VideoGames.Contracts.Dtos.Steam.VideoGameDto;
using UnsynchronizedVideoGameDto = GeekHub.VideoGames.Contracts.Dtos.Synchronization.UnsynchronizedVideoGameDto;
using ClientSynchronizedVideoGameDto = GeekHub.SteamProvider.Client.SynchronizedVideoGameDto;
using SynchronizedVideoGameDto = GeekHub.VideoGames.Contracts.Dtos.Synchronization.SynchronizedVideoGameDto;

namespace GeekHub.VideoGames.SteamAdapter
{
    public class SteamVideoGamesProvider : IExternalVideoGamesProvider
    {
        private readonly IMapper _mapper;
        private readonly VideoGamesClient _videoGamesClient;
        
        public SteamVideoGamesProvider(VideoGamesClient videoGamesVideoGamesClient, IMapper mapper)
        {
            _mapper = mapper;
            _videoGamesClient = videoGamesVideoGamesClient;
        }
        
        public async Task<VideoGameDto> GetDetailsAsync(Guid id)
        {
            var detailsClientDto = await _videoGamesClient.GetDetailsAsync(id);

            var details = _mapper.Map<VideoGameDto>(detailsClientDto);

            return details;
        }
        
        public async Task<IEnumerable<UnsynchronizedVideoGameDto>> GetUnsynchronizedAsync(int count)
        {
            var clientUnsynchronizedVideoGames = await _videoGamesClient.GetUnsynchronizedAsync(count);

            var unsynchronizedVideoGames = _mapper.Map<IEnumerable<UnsynchronizedVideoGameDto>>(clientUnsynchronizedVideoGames);

            return unsynchronizedVideoGames;
        }

        public async Task SynchronizeAsync(IEnumerable<SynchronizedVideoGameDto> videoGamesToSynchronize)
        {
            var clientVideoGamesToSynchronize = _mapper.Map<IEnumerable<ClientSynchronizedVideoGameDto>>(videoGamesToSynchronize);
            
            await _videoGamesClient.SynchronizeAsync(clientVideoGamesToSynchronize);
        }
    }
}

