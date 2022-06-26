namespace GeekHub.BoardGames.BggProvider.Domain.Queries.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using AutoMapper;

    using GeekHub.BoardGames.BggProvider.Domain.Api;
    using GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters;
    using GeekHub.BoardGames.BggProvider.Domain.Dtos;
    using GeekHub.BoardGames.BggProvider.Domain.Entities;

    using MediatR;

    public class QueryPlaysByUserNameHandler : IRequestHandler<QueryPlaysByUserNameRequest, IEnumerable<PlayRecordModel>>
    {
        // IDEA: Move to constants or config
        private const double PlaysPageSize = 100.0;

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
                    UserName = request.Username
                };

            var plays = await RequestPlays(parameters);

            var models = _mapper.Map<IEnumerable<PlayRecordModel>>(plays);

            return models;
        }

        private async Task<List<PlayRecord>> RequestPlays(RequestPlaysParameters request)
        {
            var playRecords = new List<PlayRecord>();

            var initialResponse = await _bggApiClient.GetPlayRecordsAsync(request);
            playRecords.AddRange(initialResponse.Plays);

            var pageCount = CalculatePageCount(initialResponse.TotalPlays);
            playRecords.AddRange(await RequestRemainingPages(request, pageCount));

            return playRecords;
        }

        private async Task<IEnumerable<PlayRecord>> RequestRemainingPages(RequestPlaysParameters request, double pageCount)
        {
            var result = new List<PlayRecord>();
            while (request.Page < pageCount)
            {
                request.Page++;

                var response = await _bggApiClient.GetPlayRecordsAsync(request);
                
                result.AddRange(response.Plays);
            }

            return result;
        }

        private static double CalculatePageCount(int totalPlays)
        {
            return Math.Ceiling(totalPlays / PlaysPageSize);
        }
    }
}
