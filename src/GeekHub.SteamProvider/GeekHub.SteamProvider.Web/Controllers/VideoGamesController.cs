using System;
using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Provider;
using GeekHub.VideoGames.Contracts.Dtos.Steam;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GeekHub.SteamProvider.Web.Controllers
{
    [ApiController]
    [Route("api/video-games")]
    public class VideoGamesController : ControllerBase
    {
        private readonly IVideoGamesProvider _provider;

        public VideoGamesController(IVideoGamesProvider provider)
        {
            _provider = provider;
        }

        [HttpGet("{geekHubId}")]
        [SwaggerOperation(OperationId = "VideoGames_GetDetails")]
        [SwaggerResponse(200, Type = typeof(VideoGameDto))]
        [SwaggerResponse(404)]
        public async Task<IActionResult> Get(Guid geekHubId)
        {
            var game = await _provider.Get(geekHubId);

            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }
    }
}