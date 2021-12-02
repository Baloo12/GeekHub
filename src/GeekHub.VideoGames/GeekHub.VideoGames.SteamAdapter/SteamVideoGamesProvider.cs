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
        private readonly VideoGamesClient _client;
        
        public SteamVideoGamesProvider(SteamProviderClient steamProviderClient, IMapper mapper)
        {
            _mapper = mapper;
            _client = new VideoGamesClient(steamProviderClient.HttpClient);
        }
        
        public async Task<VideoGameDto> GetDetails(Guid id)
        {
            var detailsClientDto = await _client.GetDetailsAsync(id);

            var details = _mapper.Map<VideoGameDto>(detailsClientDto);

            return details;
        }
        
        public async Task<IEnumerable<UnsynchronizedVideoGameDto>> GetUnsynchronizedAsync(int count)
        {
            var clientUnsynchronizedVideoGames = await _client.GetUnsynchronizedAsync(count);

            var unsynchronizedVideoGames = _mapper.Map<IEnumerable<UnsynchronizedVideoGameDto>>(clientUnsynchronizedVideoGames);

            return unsynchronizedVideoGames;
        }

        public async Task SynchronizeAsync(IEnumerable<SynchronizedVideoGameDto> videoGamesToSynchronize)
        {
            var clientVideoGamesToSynchronize = _mapper.Map<IEnumerable<ClientSynchronizedVideoGameDto>>(videoGamesToSynchronize);
            
            await _client.SynchronizeAsync(clientVideoGamesToSynchronize);
        }
    }
}

