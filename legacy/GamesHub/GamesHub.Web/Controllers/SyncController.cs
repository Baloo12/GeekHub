namespace GamesHub.Web.Controllers
{
    using GamesHub.Business.Contracts.Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/sync")]
    [ApiController]
    public class SyncController : ControllerBase
    {
        private readonly ISyncService _syncService;

        public SyncController(ISyncService syncService)
        {
            _syncService = syncService;
        }

        [HttpPost("games")]
        public async Task SynchronizeGames()
        {
            await _syncService.SyncGames();
        }
    }
}
