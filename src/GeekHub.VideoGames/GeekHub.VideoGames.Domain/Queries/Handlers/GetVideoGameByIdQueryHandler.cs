using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GeekHub.VideoGames.Domain.Dtos;
using GeekHub.VideoGames.Domain.Interfaces;
using MediatR;

namespace GeekHub.VideoGames.Domain.Queries.Handlers
{
    public class GetVideoGameByIdQueryHandler : IRequestHandler<GetVideoGameByIdQuery, VideoGameResponseDto>
    {
        private readonly IVideoGamesRepository _videoGamesRepository;
        private readonly IMapper _mapper;

        public GetVideoGameByIdQueryHandler(
            IVideoGamesRepository videoGamesRepository,
            IMapper mapper)
        {
            _videoGamesRepository = videoGamesRepository;
            _mapper = mapper;
        }
        
        public async Task<VideoGameResponseDto> Handle(
            GetVideoGameByIdQuery request,
            CancellationToken cancellationToken = default)
        {
            var game = await _videoGamesRepository.GetAsync(request.Id);
            var response = _mapper.Map<VideoGameResponseDto>(game);

            return response;
        }
    }
}