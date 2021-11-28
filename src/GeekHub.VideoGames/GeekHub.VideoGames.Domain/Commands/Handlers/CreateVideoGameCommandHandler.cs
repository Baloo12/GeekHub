using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GeekHub.VideoGames.Domain.Dtos;
using GeekHub.VideoGames.Domain.Entities;
using GeekHub.VideoGames.Domain.Interfaces;
using MediatR;

namespace GeekHub.VideoGames.Domain.Commands.Handlers
{
    public class CreateVideoGameCommandHandler : IRequestHandler<CreateVideoGameCommand, VideoGameResponseDto>
    {
        private readonly IVideoGamesRepository _videoGamesRepository;
        private readonly IMapper _mapper;

        public CreateVideoGameCommandHandler(
            IVideoGamesRepository videoGamesRepository,
            IMapper mapper)
        {
            _videoGamesRepository = videoGamesRepository;
            _mapper = mapper;
        }
        
        public async Task<VideoGameResponseDto> Handle(
            CreateVideoGameCommand request,
            CancellationToken cancellationToken = default)
        {
            var game = _mapper.Map<VideoGame>(request.RequestDto);
            
            var createdGame = await _videoGamesRepository.CreateAsync(game);
            await _videoGamesRepository.SaveChangesAsync();

            var responseDto = _mapper.Map<VideoGameResponseDto>(createdGame);

            return responseDto;
        }
    }
}