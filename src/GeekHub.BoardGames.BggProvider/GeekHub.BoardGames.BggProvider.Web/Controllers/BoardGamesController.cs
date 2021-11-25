namespace GeekHub.BoardGames.BggProvider.Web.Controllers
{
    using System.Threading.Tasks;

    using AutoMapper;

    using GeekHub.BoardGames.BggProvider.Domain;
    using GeekHub.BoardGames.BggProvider.Web.Models;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/provider")]
    public class BoardGamesController : ControllerBase
    {
        private readonly IBggApiClient _bggApiClient;

        private readonly IMapper _mapper;

        public BoardGamesController(IBggApiClient bggApiClient, IMapper mapper)
        {
            _bggApiClient = bggApiClient;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BoardGameModel>> Get(int id)
        {
            var game = await _bggApiClient.GetGameAsync(id);
            var model = _mapper.Map<BoardGameModel>(game);
            return Ok(model);
        }
    }
}
