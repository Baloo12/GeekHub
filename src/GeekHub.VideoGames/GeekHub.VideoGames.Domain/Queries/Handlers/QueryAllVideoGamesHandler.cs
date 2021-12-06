using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GeekHub.VideoGames.Domain.Dtos;
using GeekHub.VideoGames.Domain.Interfaces;
using MediatR;

namespace GeekHub.VideoGames.Domain.Queries.Handlers
{
    public class QueryAllVideoGamesHandler : IRequestHandler<QueryAllVideoGames, IEnumerable<VideoGameResponseDto>>
    {
        private readonly IVideoGamesRepository _videoGamesRepository;
        private readonly IMapper _mapper;

        public QueryAllVideoGamesHandler(
            IVideoGamesRepository videoGamesRepository,
            IMapper mapper)
        {
            _videoGamesRepository = videoGamesRepository;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<VideoGameResponseDto>> Handle(
            QueryAllVideoGames request,
            CancellationToken cancellationToken = default)
        {
            var games = await _videoGamesRepository.GetAllAsync();
            var response = _mapper.Map<IEnumerable<VideoGameResponseDto>>(games);

            return response;
        }
    }
}