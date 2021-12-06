using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GeekHub.VideoGames.Contracts.Dtos.Synchronization;
using GeekHub.VideoGames.Domain.ExternalProviders;
using MediatR;

namespace GeekHub.VideoGames.Domain.Queries.Handlers
{
    public class QueryExternalVideoGamesToSynchronizeHandler : IRequestHandler<QueryExternalVideoGamesToSynchronize, IEnumerable<UnsynchronizedVideoGameDto>>
    {
        private readonly IExternalVideoGamesProvidersFactory _externalVideoGamesProvidersFactory;

        public QueryExternalVideoGamesToSynchronizeHandler(
            IExternalVideoGamesProvidersFactory externalVideoGamesProvidersFactory)
        {
            _externalVideoGamesProvidersFactory = externalVideoGamesProvidersFactory;
        }
        
        public async Task<IEnumerable<UnsynchronizedVideoGameDto>> Handle(
            QueryExternalVideoGamesToSynchronize request,
            CancellationToken cancellationToken = default)
        {
            var provider = _externalVideoGamesProvidersFactory.ResolveProvider(request.Provider);
            var unsynchronizedVideoGames = await provider.GetUnsynchronizedAsync(request.Count);

            return unsynchronizedVideoGames;
        }
    }
}