using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Specifications;
using GeekHub.SteamProvider.Domain.Specifications.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        
        [HttpPost("ids")]
        public async Task<IActionResult> CollectIds()
        {
            await _collectIdsSpecification.ExecuteAsync();

            return Ok();
        }

        [HttpPost("games")]
        public async Task<IActionResult> CollectGames()
        {
            await _collectAllVideoGames.ExecuteAsync();

            return Ok();
        }
    }
}