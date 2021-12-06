using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.HttpClients;
using GeekHub.SteamProvider.Domain.Queries.SteamApi;
using MediatR;

namespace GeekHub.SteamProvider.Domain.Queries.Handlers.SteamApi
{
    public class QueryAllVideoGamesBaseInfoFromSteamApiHandler : IRequestHandler<QueryAllVideoGamesBaseInfoFromSteamApi, IEnumerable<VideoGame>>
    {
        private readonly ISteamApiClient _steamApiClient;

        public QueryAllVideoGamesBaseInfoFromSteamApiHandler(
            ISteamApiClient steamApiClient)
        {
            _steamApiClient = steamApiClient;
        }
        
        public async Task<IEnumerable<VideoGame>> Handle(
            QueryAllVideoGamesBaseInfoFromSteamApi request,
            CancellationToken cancellationToken = default)
        {
            var games = await _steamApiClient.GetAllGames();
            
            // TODO: Separate mapper?
            var gamesPersisted =  games.AppList.Apps.Select(a => new VideoGame
            {
                SteamId = a.AppId.ToString(),
                Name = a.Name,
                // ModifiedAt = DateTime.Now TODO: Useless for now
            });
            
            return gamesPersisted;
        }
    }
}