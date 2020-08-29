namespace GamesHub.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoMapper;

    using GamesHub.Business.Contracts.Services;
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
        public async Task<GameModel> Get(Guid id)
        {
            var game = await _gameService.Get(id);
            var gameModel = _mapper.Map<GameModel>(game);
            return gameModel;
        }

        [HttpGet]
        public async Task<IEnumerable<GameModel>> GetAll()
        {
            var games = await _gameService.GetAll();
            var gameModels = _mapper.Map<IEnumerable<GameModel>>(games);
            return gameModels;
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