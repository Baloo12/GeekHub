﻿using System.Threading.Tasks;
using GeekHub.SteamProvider.Domain.Provider;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{steamId}")]
        public async Task<IActionResult> Get(string steamId)
        {
            var game = await _provider.Get(steamId);

            return Ok(game);
        }
    }
}