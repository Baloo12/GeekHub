using System.Threading;
using System.Threading.Tasks;
using GeekHub.VideoGames.Domain.ExternalProviders;
using MediatR;

namespace GeekHub.VideoGames.Domain.Commands.Handlers
{
    public class SynchronizeExternalVideoGamesCommandHandler : IRequestHandler<SynchronizeExternalVideoGamesCommand>
    {
        private readonly IExternalVideoGamesProvidersFactory _externalVideoGamesProvidersFactory;

        public SynchronizeExternalVideoGamesCommandHandler(
            IExternalVideoGamesProvidersFactory externalVideoGamesProvidersFactory)
        {
            _externalVideoGamesProvidersFactory = externalVideoGamesProvidersFactory;
        }
        
        public async Task<Unit> Handle(
            SynchronizeExternalVideoGamesCommand request,
            CancellationToken cancellationToken = default)
        {
            
            var provider = _externalVideoGamesProvidersFactory.ResolveProvider(request.Provider);
            await provider.SynchronizeAsync(request.VideoGameToSynchronize);

            return Unit.Value;
        }
    }
}