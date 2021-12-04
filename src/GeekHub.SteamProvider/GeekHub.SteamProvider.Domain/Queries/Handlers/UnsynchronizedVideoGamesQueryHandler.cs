using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GeekHub.SteamProvider.Domain.DataAccess;
using GeekHub.VideoGames.Contracts.Dtos.Synchronization;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.Handlers
{
    public class UnsynchronizedVideoGamesQueryHandler : IRequestHandler<UnsynchronizedVideoGamesQuery, IEnumerable<UnsynchronizedVideoGameDto>>
    {
        private readonly IVideoGamesRepository _videoGamesRepository;
        private readonly IMapper _mapper;

        public UnsynchronizedVideoGamesQueryHandler(
            IVideoGamesRepository videoGamesRepository,
            IMapper mapper)
        {
            _videoGamesRepository = videoGamesRepository;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<UnsynchronizedVideoGameDto>> Handle(
            UnsynchronizedVideoGamesQuery request,
            CancellationToken cancellationToken = default)
        {
            var games = await _videoGamesRepository.GetManyAsync(g => g.GeekHubId == Guid.Empty, request.Count);
            var response = _mapper.Map<IEnumerable<UnsynchronizedVideoGameDto>>(games);

            return response;
        }
    }
}