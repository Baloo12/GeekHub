using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GeekHub.SteamProvider.Domain.ExternalConsumers;
using GeekHub.VideoGames.Web.Client;
using VideoGameToSynchronizeRequestDto = GeekHub.VideoGames.Contracts.Dtos.Synchronization.VideoGameToSynchronizeRequestDto;
using ClientVideoGameToSynchronizeRequestDto = GeekHub.VideoGames.Web.Client.VideoGameToSynchronizeRequestDto;
using VideoGameToSynchronizeResponseDto = GeekHub.VideoGames.Contracts.Dtos.Synchronization.VideoGameToSynchronizeResponseDto;

namespace GeekHub.SteamProvider.VideoGamesAdapter
{
    public class VideoGamesConsumer : IExternalVideoGamesConsumer
    {
        private readonly IMapper _mapper;
        private readonly SynchronizationClient _client;
        
        public VideoGamesConsumer(VideoGamesConsumerClient videoGamesConsumerClient, IMapper mapper)
        {
            _mapper = mapper;
            _client = new SynchronizationClient(videoGamesConsumerClient.HttpClient);
        }
        
        public async Task<IEnumerable<VideoGameToSynchronizeResponseDto>> SynchronizeVideoGames(IEnumerable<VideoGameToSynchronizeRequestDto> requestDtos)
        {
            var clientDtos = _mapper.Map<IEnumerable<ClientVideoGameToSynchronizeRequestDto>>(requestDtos);
            var clientResponse = await _client.SynchronizeVideoGamesAsync(clientDtos);
            
            var response = _mapper.Map<IEnumerable<VideoGameToSynchronizeResponseDto>>(clientResponse);
            return response;
        }
    }
}