using System.Collections.Generic;
using System.Threading.Tasks;
using GeekHub.VideoGames.Contracts.Dtos.Synchronization;
using GeekHub.VideoGames.Domain.Commands;
using GeekHub.VideoGames.Domain.Dtos;
using GeekHub.VideoGames.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GeekHub.VideoGames.Web.Controllers
{
    [ApiController]
    [Route("api/synchronization")]
    public class SynchronizationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SynchronizationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Creates a video games from selected provider that are not syncronized yet (don't have geekhubId)
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpPost("{provider}/{count}")]
        [SwaggerOperation(OperationId = "Synchronization_SynchronizeVideoGames")]
        [SwaggerResponse(200, Type = typeof(IEnumerable<SynchronizedVideoGameDto>))]
        public async Task<IActionResult> SynchronizeVideoGames(string provider, int count)
        {
            var query = new QueryExternalVideoGamesToSynchronize(provider, count);
            var unsynchronizedGames = await _mediator.Send(query);

            var synchronizedGames = await SynchronizeVideoGames(unsynchronizedGames);

            var synchronizeExternalVideoGames = new SynchronizeExternalVideoGamesCommand(provider, synchronizedGames);
            await _mediator.Send(synchronizeExternalVideoGames);
            
            return Ok();
        }

        private async Task<List<SynchronizedVideoGameDto>> SynchronizeVideoGames(
            IEnumerable<UnsynchronizedVideoGameDto> unsynchronizedGames)
        {
            var synchronizedGames = new List<SynchronizedVideoGameDto>();

            foreach (var unsynchronizedGame in unsynchronizedGames)
            {
                var synchronizedGame = await SynchronizeVideoGame(unsynchronizedGame);
                synchronizedGames.Add(synchronizedGame);
            }

            return synchronizedGames;
        }

        private async Task<SynchronizedVideoGameDto> SynchronizeVideoGame(UnsynchronizedVideoGameDto unsynchronizedVideoGame)
        {
            var query = new QueryVideoGameToSynchronize(unsynchronizedVideoGame);
            var game = await _mediator.Send(query);

            // TODO: Commands pipeline
            if (game == null)
            {
                var createdGame = await CreateVideoGame(unsynchronizedVideoGame);

                var createdSynchronizedGame = new SynchronizedVideoGameDto()
                {
                    Id = unsynchronizedVideoGame.Id,
                    GeekHubId = createdGame.Id
                };

                return createdSynchronizedGame;
            }
            
            var synchronizedGame = new SynchronizedVideoGameDto()
            {
                Id = unsynchronizedVideoGame.Id,
                GeekHubId = game.Id
            };

            return synchronizedGame;
        }

        private async Task<VideoGameResponseDto> CreateVideoGame(UnsynchronizedVideoGameDto unsynchronizedVideoGame)
        {
            var createVideoGameDto = new CreateVideoGameRequestDto(unsynchronizedVideoGame.Name);
            
            var command = new CreateVideoGameCommand(createVideoGameDto);
            var createdVideoGame = await _mediator.Send(command);

            return createdVideoGame;
        }
    }
}