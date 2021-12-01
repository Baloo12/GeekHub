using System.Linq;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Commands;
using GeekHub.SteamProvider.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GeekHub.SteamProvider.Web.Controllers
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

        [HttpPost("{count}")]
        [SwaggerOperation(OperationId = "Synchronization_SynchronizeGames")]
        [SwaggerResponse(200)]
        public async Task<IActionResult> SynchronizeGames(int count)
        {
            var query = new GetAllVideoGamesQuery();
            var videoGameToSynchronizeRequestDtos = await _mediator.Send(query);

            var toSynchronize = videoGameToSynchronizeRequestDtos.Take(count);

            var synchronizeCommand = new SynchronizeVideoGamesBatchCommand(toSynchronize);
            var synchronizedGames = await _mediator.Send(synchronizeCommand);

            var updateCommand = new UpdateVideoGamesBatchAfterSynchronizationCommand(synchronizedGames);
            var updatedGames = await _mediator.Send(updateCommand);

            return Ok(updatedGames);
        }
    }
}