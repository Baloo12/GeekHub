using System.Net.Http;
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
        
        public async Task<VideoGameDto> GetDetails(string steamId) // Idea: use common Guid Id, get rid of external ids at all
        {
            var detailsClientDto = await _client.GetDetailsAsync(steamId);

            var details = _mapper.Map<VideoGameDto>(detailsClientDto);

            return details;
        }
    }
}

