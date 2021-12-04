using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GeekHub.VideoGames.Contracts.Dtos.Synchronization;
using GeekHub.VideoGames.Domain.ExternalProviders;
using MediatR;

namespace GeekHub.VideoGames.Domain.Queries.Handlers
{
    public class ExternalVideoGamesToSynchronizeQueryHandler : IRequestHandler<ExternalVideoGamesToSynchronizeQuery, IEnumerable<UnsynchronizedVideoGameDto>>
    {
        private readonly IExternalVideoGamesProvidersFactory _externalVideoGamesProvidersFactory;

        public ExternalVideoGamesToSynchronizeQueryHandler(
            IExternalVideoGamesProvidersFactory externalVideoGamesProvidersFactory)
        {
            _externalVideoGamesProvidersFactory = externalVideoGamesProvidersFactory;
        }
        
        public async Task<IEnumerable<UnsynchronizedVideoGameDto>> Handle(
            ExternalVideoGamesToSynchronizeQuery request,
            CancellationToken cancellationToken = default)
        {
            var provider = _externalVideoGamesProvidersFactory.ResolveProvider(request.Provider);
            var unsynchronizedVideoGames = await provider.GetUnsynchronizedAsync(request.Count);

            return unsynchronizedVideoGames;
        }
    }
}