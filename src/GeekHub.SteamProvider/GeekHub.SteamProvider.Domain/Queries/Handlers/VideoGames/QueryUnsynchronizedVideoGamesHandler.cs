using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.SteamProvider.Domain.Queries.VideoGames;
using GeekHub.VideoGames.Contracts.Dtos.Synchronization;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.Handlers.VideoGames
{
    public class QueryUnsynchronizedVideoGamesHandler : IRequestHandler<QueryUnsynchronizedVideoGames, IEnumerable<UnsynchronizedVideoGameDto>>
    {
        private readonly IVideoGamesRepository _videoGamesRepository;
        private readonly IMapper _mapper;

        public QueryUnsynchronizedVideoGamesHandler(
            IVideoGamesRepository videoGamesRepository,
            IMapper mapper)
        {
            _videoGamesRepository = videoGamesRepository;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<UnsynchronizedVideoGameDto>> Handle(
            QueryUnsynchronizedVideoGames request,
            CancellationToken cancellationToken = default)
        {
            var games = await _videoGamesRepository.GetManyAsync(g => g.SteamId == "1091500", request.Count);
            var response = _mapper.Map<IEnumerable<UnsynchronizedVideoGameDto>>(games);

            return response;
        }
    }
}