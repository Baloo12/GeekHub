using System.Threading;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.HttpClients;
using GeekHub.SteamProvider.Domain.Models.Internal;
using GeekHub.SteamProvider.Domain.Queries.SteamApi;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.Handlers.SteamApi
{
    public class QueryVideoGameDetailsFromSteamApiHandler : IRequestHandler<QueryVideoGameDetailsFromSteamApi, SteamGameDetails>
    {
        private readonly ISteamStoreClient _steamStoreClient;

        public QueryVideoGameDetailsFromSteamApiHandler(
            ISteamStoreClient steamStoreClient)
        {
            _steamStoreClient = steamStoreClient;
        }
        
        public async Task<SteamGameDetails> Handle(
            QueryVideoGameDetailsFromSteamApi request,
            CancellationToken cancellationToken = default)
        {
            var details = await _steamStoreClient.GetGameDetails(request.SteamId);
            if (!details.Success)
            {
                return null;
            }
            
            return details;
        }
    }
}