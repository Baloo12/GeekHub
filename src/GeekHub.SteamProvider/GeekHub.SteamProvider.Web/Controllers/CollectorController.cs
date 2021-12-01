using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Specifications.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GeekHub.SteamProvider.Web.Controllers
{
    [ApiController]
    [Route("api/collector")]
    public class CollectorController : ControllerBase
    {
        private readonly ICollectAllVideoGamesFromSteamApiSpecification _collectAllVideoGames;
        private readonly ICollectIdsFromSteamApiSpecification _collectIdsSpecification;

        public CollectorController(
            ICollectAllVideoGamesFromSteamApiSpecification collectAllVideoGames,
            ICollectIdsFromSteamApiSpecification collectIdsSpecification)
        {
            _collectAllVideoGames = collectAllVideoGames;
            _collectIdsSpecification = collectIdsSpecification;
        }
        
        [HttpPost("base-info")]
        [SwaggerOperation(OperationId = "Collector_CollectAllVideoGamesBaseInfo")]
        [SwaggerResponse(200)]
        public async Task<IActionResult> CollectAllVideoGamesBaseInfo()
        {
            await _collectIdsSpecification.ExecuteAsync();

            return Ok();
        }

        [HttpPost("details")]
        [SwaggerOperation(OperationId = "Collector_CollectAllVideoGamesDetails")]
        [SwaggerResponse(200)]
        public async Task<IActionResult> CollectAllVideoGamesDetails()
        {
            await _collectAllVideoGames.ExecuteAsync();

            return Ok();
        }
    }
}