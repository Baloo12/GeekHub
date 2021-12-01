using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.VideoGames.Contracts.Dtos.Synchronization;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.Handlers
{
    public class GetAllVideoGamesQueryHandler : IRequestHandler<GetAllVideoGamesQuery, IEnumerable<VideoGameToSynchronizeRequestDto>>
    {
        private readonly IVideoGamesRepository _videoGamesRepository;
        private readonly IMapper _mapper;

        public GetAllVideoGamesQueryHandler(
            IVideoGamesRepository videoGamesRepository,
            IMapper mapper)
        {
            _videoGamesRepository = videoGamesRepository;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<VideoGameToSynchronizeRequestDto>> Handle(
            GetAllVideoGamesQuery request,
            CancellationToken cancellationToken = default)
        {
            var games = await _videoGamesRepository.GetAllAsync();
            var response = _mapper.Map<IEnumerable<VideoGameToSynchronizeRequestDto>>(games);

            return response;
        }
    }
}