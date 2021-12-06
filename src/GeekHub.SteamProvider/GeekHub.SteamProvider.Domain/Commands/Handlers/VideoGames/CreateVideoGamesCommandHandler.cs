using System.Threading;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Commands.VideoGames;
using GeekHub.SteamProvider.Domain.DataAccess;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Commands.Handlers.VideoGames
{
    public class CreateVideoGamesCommandHandler : IRequestHandler<CreateVideoGamesCommand>
    {
        private readonly IVideoGamesRepository _repository;

        public CreateVideoGamesCommandHandler(
            IVideoGamesRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Unit> Handle(
            CreateVideoGamesCommand request,
            CancellationToken cancellationToken = default)
        {
            await _repository.CreateAsync(request.VideoGamesToCreate);
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}