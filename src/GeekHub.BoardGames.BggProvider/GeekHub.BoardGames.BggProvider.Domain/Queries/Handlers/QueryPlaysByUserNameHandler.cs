namespace GeekHub.BoardGames.BggProvider.Domain.Queries.Handlers
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using AutoMapper;

    using GeekHub.BoardGames.BggProvider.Domain.Api;
    using GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters;
    using GeekHub.BoardGames.BggProvider.Domain.Dtos;

    using MediatR;

    public class QueryPlaysByUserNameHandler : IRequestHandler<QueryPlaysByUserNameRequest, IEnumerable<PlayRecordModel>>
    {
        private readonly IBggApiClient _bggApiClient;

        private readonly IMapper _mapper;

        public QueryPlaysByUserNameHandler(IBggApiClient bggApiClient, IMapper mapper)
        {
            _bggApiClient = bggApiClient;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlayRecordModel>> Handle(QueryPlaysByUserNameRequest request, CancellationToken cancellationToken = default)
        {
            var parameters = new RequestPlaysParameters()
                {
                    UserName = "Baloo12"
                };

            var records = await _bggApiClient.GetPlayRecordsAsync(parameters);
            var models = _mapper.Map<IEnumerable<PlayRecordModel>>(records);

            return models;
        }
    }
}
