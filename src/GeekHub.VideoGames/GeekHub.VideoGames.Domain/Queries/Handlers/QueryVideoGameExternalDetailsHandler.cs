using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GeekHub.VideoGames.Domain.Dtos;
using GeekHub.VideoGames.Domain.ExternalProviders;
using GeekHub.VideoGames.Domain.Interfaces;
using MediatR;

namespace GeekHub.VideoGames.Domain.Queries.Handlers
{
    public class QueryVideoGameExternalDetailsHandler : IRequestHandler<QueryVideoGameExternalDetails, VideoGameResponseDto>
    {
        private readonly IExternalVideoGamesProvidersFactory _externalVideoGamesProvidersFactory;
        private readonly IMapper _mapper;

        public QueryVideoGameExternalDetailsHandler(
            IExternalVideoGamesProvidersFactory externalVideoGamesProvidersFactory,
            IMapper mapper)
        {
            _externalVideoGamesProvidersFactory = externalVideoGamesProvidersFactory;
            _mapper = mapper;
        }
        
        public async Task<VideoGameResponseDto> Handle(
            QueryVideoGameExternalDetails request,
            CancellationToken cancellationToken = default)
        {
            var provider = _externalVideoGamesProvidersFactory.ResolveProvider(request.ExternalSource);
            var game = await provider.GetDetailsAsync(request.Id);
            
            var response = _mapper.Map<VideoGameResponseDto>(game);

            return response;
        }
    }
}