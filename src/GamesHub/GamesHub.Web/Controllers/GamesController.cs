using AutoMapper;
using GamesHub.Business.Contracts.Services;
using GamesHub.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GamesHub.Web.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IMapper _mapper;

        public GamesController(IGameService gameService, IMapper mapper)
        {
            _gameService = gameService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<GameModel> Get(Guid id)
        {
            var game = await _gameService.Get(id);
            var gameModel = _mapper.Map<GameModel>(game);
            return gameModel;
        }
    }
}
