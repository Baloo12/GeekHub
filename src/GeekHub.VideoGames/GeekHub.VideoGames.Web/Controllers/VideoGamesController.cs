using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GeekHub.VideoGames.Domain.Entities;
using GeekHub.VideoGames.Domain.Interfaces;
using GeekHub.VideoGames.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeekHub.VideoGames.Web.Controllers
{
    [ApiController]
    [Route("api/video-games")]
    public class VideoGamesController : ControllerBase
    {
        private readonly IVideoGamesRepository _videoGamesRepository;
        private readonly IMapper _mapper;

        public VideoGamesController(IVideoGamesRepository videoGamesRepository, IMapper mapper)
        {
            _videoGamesRepository = videoGamesRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<VideoGameModel> Get(Guid id)
        {
            var game = await _videoGamesRepository.GetAsync(id);
            var gameModel = _mapper.Map<VideoGameModel>(game);
            
            return gameModel;
        }

        [HttpGet]
        public async Task<IEnumerable<VideoGameModel>> GetAll()
        {
            var games = await _videoGamesRepository.GetAllAsync();
            var gameModels = _mapper.Map<IEnumerable<VideoGameModel>>(games);
            
            return gameModels;
        }

        [HttpPost]
        public async Task Create()
        {
            var newGame = new VideoGameModel("test game");
            
            var entity = _mapper.Map<VideoGame>(newGame);
            
            await _videoGamesRepository.CreateAsync(entity);
            await _videoGamesRepository.SaveChangesAsync();
        }
    }
}