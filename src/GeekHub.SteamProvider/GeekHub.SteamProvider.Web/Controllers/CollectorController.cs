using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Commands.VideoGames;
using GeekHub.SteamProvider.Domain.Queries.SteamApi;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GeekHub.SteamProvider.Web.Controllers
{
    [ApiController]
    [Route("api/collector")]
    public class CollectorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CollectorController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create new games(baseinfo: steamid and name) from steam that are not present in db yet 
        /// </summary>
        /// <returns></returns>
        [HttpPost("all-base-info")]
        [SwaggerOperation(OperationId = "Collector_CollectAllVideoGamesBaseInfo")]
        [SwaggerResponse(200)]
        public async Task<IActionResult> CollectAllVideoGamesBaseInfo()
        {
            var query = new QueryAllVideoGamesBaseInfoFromSteamApi();
            var games = await _mediator.Send(query);

            var createCommand = new CreateVideoGamesCommand(games);
            await _mediator.Send(createCommand);

            return Ok();
        }

        /// <summary>
        /// Enrich game with full possible info from steam
        /// </summary>
        /// <param name="steamId"></param>
        /// <returns></returns>
        [HttpPost("details/{steamId}")]
        [SwaggerOperation(OperationId = "Collector_CollectVideoGameDetails")]
        [SwaggerResponse(200)]
        public async Task<IActionResult> CollectVideoGameDetails(string steamId)
        {
            var command = new EnrichVideoGameWithDetailsCommand(steamId);
            var updated = await _mediator.Send(command);

            return Ok(updated);
        }
    }
}