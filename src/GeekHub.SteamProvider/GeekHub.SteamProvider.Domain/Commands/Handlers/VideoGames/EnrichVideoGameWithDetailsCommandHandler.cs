using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Commands.VideoGames;
using GeekHub.SteamProvider.Domain.Entities;
using GeekHub.SteamProvider.Domain.Exceptions;
using GeekHub.SteamProvider.Domain.Queries.Developers;
using GeekHub.SteamProvider.Domain.Queries.Genres;
using GeekHub.SteamProvider.Domain.Queries.Platforms;
using GeekHub.SteamProvider.Domain.Queries.SteamApi;
using GeekHub.SteamProvider.Domain.Queries.VideoGames;
using GeekHub.SteamProvider.Domain.Utils;
using MediatR;

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
        
        public async Task<VideoGame> Handle(
            EnrichVideoGameWithDetailsCommand request,
            CancellationToken cancellationToken = default)
        {
            var queryGame = new QueryVideoGameBySteamId(request.SteamId);
            var game = await _mediator.Send(queryGame, cancellationToken);

            if (game == null)
            {
                throw new VideoGameNotExistsException(request.SteamId);
            }

            var queryDetails = new QueryVideoGameDetailsFromSteamApi(request.SteamId);
            var gameDetails = await _mediator.Send(queryDetails, cancellationToken);

            if (gameDetails == null)
            {
                throw new VideoGameNotExistsInSteamException(request.SteamId);
            }

            var queryDevelopers = new QueryOrCreateDevelopersByNames(gameDetails.Data?.Developers);
            var developers = await _mediator.Send(queryDevelopers, cancellationToken);
            
            var queryGenres = new QueryOrCreateGenresByNames(gameDetails.Data?.Genres?.Select(g => g.Description).ToList());
            var genres = await _mediator.Send(queryGenres, cancellationToken);
            
            var queryPlatforms = new QueryOrCreatePlatformsByNames(gameDetails.Data?.Platforms?.Where(p => p.Value).Select(p => p.Key).ToList());
            var platforms = await _mediator.Send(queryPlatforms, cancellationToken);

            var builder = _videoGameEntityBuilderFactory.GetVideoGameEntityBuilder(game);
            var updatedGame = builder
                .WithDetails(gameDetails.Data)
                .WithSourceId(request.SteamId)
                .WithDevelopers(developers.ToList())
                .WithGenres(genres.ToList())
                .WithPlatforms(platforms.ToList())
                .Build();

            var updateCommand = new UpdateVideoGameCommand(updatedGame);
            var updated = await _mediator.Send(updateCommand, cancellationToken);

            return updated;
        }
    }
}