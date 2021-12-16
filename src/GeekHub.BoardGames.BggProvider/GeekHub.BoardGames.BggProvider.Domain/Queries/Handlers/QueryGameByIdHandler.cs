namespace GeekHub.BoardGames.BggProvider.Domain.Queries.Handlers
{
    using System.Threading;
    using System.Threading.Tasks;

    using AutoMapper;

    using GeekHub.BoardGames.BggProvider.Domain.Api;
    using GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters;
    using GeekHub.BoardGames.BggProvider.Domain.Dtos;

    using MediatR;

    public class QueryGameByIdHandler : IRequestHandler<QueryGameByIdRequest, BoardGameModel>
    {
        private readonly IBggApiClient _bggApiClient;

        private readonly IMapper _mapper;

        public QueryGameByIdHandler(IBggApiClient bggApiClient, IMapper mapper)
        {
            _bggApiClient = bggApiClient;
            _mapper = mapper;
        }

        public async Task<BoardGameModel> Handle(QueryGameByIdRequest request, CancellationToken cancellationToken = default)
        {
            var parameters = new RequestGameParameters
                {
                    BggIds = new[]
                        {
                            request.GameId
                        },
                    IncludeStats = true
                };

            var game = await _bggApiClient.GetGameAsync(parameters);
            var model = _mapper.Map<BoardGameModel>(game);

            return model;
        }
    }
}
