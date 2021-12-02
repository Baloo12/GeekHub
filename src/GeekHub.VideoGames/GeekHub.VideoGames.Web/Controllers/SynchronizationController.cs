using System;
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

        [HttpPost("{provider}/{count}")]
        [SwaggerOperation(OperationId = "Synchronization_SynchronizeVideoGames")]
        [SwaggerResponse(200, Type = typeof(IEnumerable<SynchronizedVideoGameDto>))]
        public async Task<IActionResult> SynchronizeVideoGames(string provider, int count)
        {
            var query = new ExternalVideoGamesToSynchronizeQuery(provider, count);
            var unsynchronizedGames = await _mediator.Send(query);

            var synchronizedGames = new List<SynchronizedVideoGameDto>();
            
            foreach (var unsynchronizedGame in unsynchronizedGames)
            {
                var synchronizedGame = await SynchronizeVideoGame(unsynchronizedGame);
                synchronizedGames.Add(synchronizedGame);
            }
            
            var synchronizeExternalVideoGames = new SynchronizeExternalVideoGamesCommand(provider, synchronizedGames);
            await _mediator.Send(synchronizeExternalVideoGames);
            
            return Ok();
        }

        private async Task<SynchronizedVideoGameDto> SynchronizeVideoGame(UnsynchronizedVideoGameDto unsynchronizedVideoGame)
        {
            var query = new VideoGameToSynchronizeQuery(unsynchronizedVideoGame);
            var game = await _mediator.Send(query);

            if (game == null)
            {
                //Create
                var createVideoGameDto = new CreateVideoGameRequestDto(unsynchronizedVideoGame.Name);
                var command = new CreateVideoGameCommand(createVideoGameDto);
                var createdResponse = await _mediator.Send(command);

                var synchronizedGame = new SynchronizedVideoGameDto()
                {
                    Id = unsynchronizedVideoGame.Id,
                    GeekHubId = createdResponse.Id
                };

                return synchronizedGame;
            }
            else
            {
                var synchronizedGame = new SynchronizedVideoGameDto()
                {
                    Id = unsynchronizedVideoGame.Id,
                    GeekHubId = game.Id
                };

                return synchronizedGame;
            }
        }
    }
}