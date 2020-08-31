namespace GamesHub.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoMapper;

    using GamesHub.Business.Contracts.Services;
    using GamesHub.DataAccess.Contracts.Models;
    using GamesHub.Web.Models;

    using Microsoft.AspNetCore.Mvc;

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
        public async Task<GameOverviewModel> Get(Guid id)
        {
            var game = await _gameService.Get(id);
            var gameModel = _mapper.Map<GameOverviewModel>(game);
            return gameModel;
        }

        [HttpGet]
        public async Task<IEnumerable<GameModel>> GetAll()
        {
            var games = await _gameService.GetAll();
            var gameModels = _mapper.Map<IEnumerable<GameModel>>(games);
            return gameModels;
        }

        [HttpPost]
        public async Task CreateGame()
        {
            var newGame = new GameModel("test game");
            var entity = _mapper.Map<Game>(newGame);
            await _gameService.Create(entity);
        }

        [HttpGet("top")]
        public async Task<IEnumerable<TopGamesEntry>> GetTopGames()
        {
            var games = await _gameService.GetAll();
            var gameModels = _mapper.Map<IEnumerable<TopGamesEntry>>(games);
            return gameModels;
        }
    }
}