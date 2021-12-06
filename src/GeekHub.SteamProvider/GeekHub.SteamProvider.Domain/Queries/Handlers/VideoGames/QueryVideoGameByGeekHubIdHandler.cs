using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Queries.VideoGames;
using GeekHub.VideoGames.Contracts.Dtos.Steam;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.Handlers.VideoGames
{
    public class QueryVideoGameByGeekHubIdHandler : IRequestHandler<QueryVideoGameByGeekHubId, VideoGameDto>
    {
        private readonly IVideoGamesRepository _repository;
        private readonly IMapper _mapper;

        public QueryVideoGameByGeekHubIdHandler(
            IVideoGamesRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<VideoGameDto> Handle(
            QueryVideoGameByGeekHubId request,
            CancellationToken cancellationToken = default)
        {
            var game = await _repository.GetByGeekHubIdAsync(request.GeekHubId);

            if (game == null)
            {
                return null;
            }

            var response = _mapper.Map<VideoGameDto>(game);

            return response;
        }
    }
}