using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Commands.VideoGames;
using GeekHub.SteamProvider.Domain.Queries.VideoGames;
using GeekHub.VideoGames.Contracts.Dtos.Steam;
using GeekHub.VideoGames.Contracts.Dtos.Synchronization;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GeekHub.SteamProvider.Web.Controllers
{
    [ApiController]
    [Route("api/video-games")]
    public class VideoGamesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VideoGamesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{geekHubId}")]
        [SwaggerOperation(OperationId = "VideoGames_GetDetails")]
        [SwaggerResponse(200, Type = typeof(VideoGameDto))]
        [SwaggerResponse(404)]
        public async Task<IActionResult> Get(Guid geekHubId)
        {
            var query = new QueryVideoGameByGeekHubId(geekHubId);
            var game = await _mediator.Send(query);

            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        /// <summary>
        /// External(used by video games microservice) /api/synchronization/Steam/{count}
        /// Get steam video games from db that don't have geekhubId
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpGet("unsynchronized/{count}")]
        [SwaggerOperation(OperationId = "VideoGames_GetUnsynchronized")]
        [SwaggerResponse(200, Type = typeof(IEnumerable<UnsynchronizedVideoGameDto>))]
        [SwaggerResponse(404)]
        public async Task<IActionResult> GetUnsynchronized(int count)
        {
            var query = new QueryUnsynchronizedVideoGames(count);
            var videoGamesToSynchronize = await _mediator.Send(query);

            return Ok(videoGamesToSynchronize);
        }

        /// <summary>
        /// External(used by video games microservice) /api/synchronization/Steam/{count}
        /// Set geekhubId for unsyncronized steam video games got with [HttpGet("unsynchronized/{count}")] endpint
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpPut("synchronize")]
        [SwaggerOperation(OperationId = "VideoGames_Synchronize")]
        [SwaggerResponse(200)]
        public async Task<IActionResult> SynchronizeGames(
            [FromBody] IEnumerable<SynchronizedVideoGameDto> videoGamesToSynchronize)
        {
            var updateCommand = new SynchronizeVideoGamesCommand(videoGamesToSynchronize);
            var updatedGames = await _mediator.Send(updateCommand);

            return Ok(updatedGames);
        }
    }
}