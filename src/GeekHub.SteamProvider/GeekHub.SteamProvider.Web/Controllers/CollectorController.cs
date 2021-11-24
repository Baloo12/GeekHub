using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Collector;
using Microsoft.AspNetCore.Mvc;

namespace GeekHub.SteamProvider.Web.Controllers
{
    [ApiController]
    [Route("api/collector")]
    public class CollectorController : ControllerBase
    {
        private readonly IVideoGamesCollector _collector;

        public CollectorController(IVideoGamesCollector collector)
        {
            _collector = collector;
        }

        [HttpPost]
        public async Task<IActionResult> BeginCollect()
        {
            await _collector.BeginCollect();

            return Ok();
        }
    }
}