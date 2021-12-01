using System;
using System.Threading.Tasks;
using AutoMapper;
using GeekHub.SteamProvider.Client;
using GeekHub.VideoGames.Domain.Interfaces;
using VideoGameDto = GeekHub.VideoGames.Contracts.Dtos.Steam.VideoGameDto;

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
    }
}

