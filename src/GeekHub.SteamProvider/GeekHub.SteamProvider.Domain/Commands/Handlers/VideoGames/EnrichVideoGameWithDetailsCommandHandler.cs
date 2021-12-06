using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Commands.VideoGames;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Exceptions;
using GeekHub.SteamProvider.Domain.Models.Internal;
using GeekHub.SteamProvider.Domain.Queries.Developers;
using GeekHub.SteamProvider.Domain.Queries.Genres;
using GeekHub.SteamProvider.Domain.Queries.Platforms;
using GeekHub.SteamProvider.Domain.Queries.SteamApi;
using GeekHub.SteamProvider.Domain.Queries.VideoGames;
using GeekHub.SteamProvider.Domain.Utils;
using MediatR;
using Genre = GeekHub.SteamProvider.Domain.Entities.Genre;

namespace GeekHub.SteamProvider.Domain.Commands.Handlers.VideoGames
{
    public class EnrichVideoGameWithDetailsCommandHandler : IRequestHandler<EnrichVideoGameWithDetailsCommand, VideoGame>
    {
        private readonly IMediator _mediator;
        private readonly IVideoGameEntityBuilderFactory _videoGameEntityBuilderFactory;

        public EnrichVideoGameWithDetailsCommandHandler(
            IMediator mediator,
            IVideoGameEntityBuilderFactory videoGameEntityBuilderFactory)
        {
            _mediator = mediator;
            _videoGameEntityBuilderFactory = videoGameEntityBuilderFactory;
        }
        
        // TODO: To many responsibilities?
        public async Task<VideoGame> Handle(
            EnrichVideoGameWithDetailsCommand request,
            CancellationToken cancellationToken = default)
        {
            var game = await GetVideoGameBySteamIdFromRepository(request, cancellationToken);
            var details = await GetVideoGameDetailsFromSteam(request, cancellationToken);

            var updatedGame = await EnrichVideoGameWithDetails(game, details, cancellationToken);

            var updated = await UpdateVideoGame(updatedGame, cancellationToken);

            return updated;
        }

        private async Task<VideoGame> GetVideoGameBySteamIdFromRepository(EnrichVideoGameWithDetailsCommand request,
            CancellationToken cancellationToken)
        {
            var queryGame = new QueryVideoGameBySteamId(request.SteamId);
            var game = await _mediator.Send(queryGame, cancellationToken);

            if (game == null)
            {
                throw new VideoGameNotExistsException(request.SteamId);
            }

            return game;
        }
        
        private async Task<SteamGameDetails> GetVideoGameDetailsFromSteam(EnrichVideoGameWithDetailsCommand request,
            CancellationToken cancellationToken)
        {
            var queryDetails = new QueryVideoGameDetailsFromSteamApi(request.SteamId);
            var gameDetails = await _mediator.Send(queryDetails, cancellationToken);

            if (gameDetails == null)
            {
                throw new VideoGameNotExistsInSteamException(request.SteamId);
            }

            return gameDetails;
        }
        
        private async Task<VideoGame> EnrichVideoGameWithDetails(
            VideoGame game,
            SteamGameDetails details,
            CancellationToken cancellationToken = default)
        {
            var developers = await GetDevelopersFromDetails(details, cancellationToken);
            var genres = await GetGenresFromDetails(details, cancellationToken);
            var platforms = await GetPlatformsFromDetails(details, cancellationToken);

            var builder = _videoGameEntityBuilderFactory.GetVideoGameEntityBuilder(game);
            var updatedGame = builder
                .WithDetails(details.Data)
                .WithDevelopers(developers.ToList())
                .WithGenres(genres.ToList())
                .WithPlatforms(platforms.ToList())
                .Build();
            
            return updatedGame;
        }
        
        private async Task<IEnumerable<Developer>> GetDevelopersFromDetails(
            SteamGameDetails gameDetails,
            CancellationToken cancellationToken = default)
        {
            var developersNames = gameDetails.Data?.Developers;
            
            var queryDevelopers = new QueryOrCreateDevelopersByNames(developersNames);
            var developers = await _mediator.Send(queryDevelopers, cancellationToken);
            
            return developers;
        }
        
        private async Task<IEnumerable<Genre>> GetGenresFromDetails(
            SteamGameDetails gameDetails,
            CancellationToken cancellationToken = default)
        {
            var genresNames = gameDetails.Data?.Genres?
                .Select(g => g.Description)
                .ToList();
            
            var queryGenres = new QueryOrCreateGenresByNames(genresNames);
            var genres = await _mediator.Send(queryGenres, cancellationToken);
            
            return genres;
        }

        private async Task<IEnumerable<Platform>> GetPlatformsFromDetails(
            SteamGameDetails gameDetails,
            CancellationToken cancellationToken = default)
        {
            var platformsNames = gameDetails.Data?.Platforms?
                .Where(p => p.Value)
                .Select(p => p.Key)
                .ToList();
            
            var queryPlatforms = new QueryOrCreatePlatformsByNames(platformsNames);
            var platforms = await _mediator.Send(queryPlatforms, cancellationToken);
            
            return platforms;
        }
        
        private async Task<VideoGame> UpdateVideoGame(VideoGame updatedGame, CancellationToken cancellationToken)
        {
            var updateCommand = new UpdateVideoGameCommand(updatedGame);
            var updated = await _mediator.Send(updateCommand, cancellationToken);
            
            return updated;
        }
    }
}