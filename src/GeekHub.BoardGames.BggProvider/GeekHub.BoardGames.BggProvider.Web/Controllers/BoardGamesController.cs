namespace GeekHub.BoardGames.BggProvider.Web.Controllers
{
    using System.Threading.Tasks;

    using AutoMapper;

    using GeekHub.BoardGames.BggProvider.Domain.Api;
    using GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters;
    using GeekHub.BoardGames.BggProvider.Web.Models;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/provider")]
    public class BoardGamesController : ControllerBase
    {
        private readonly IBggApiClient _bggApiClient;

        private readonly IContentParser _contentParser;

        private readonly IMapper _mapper;

        public BoardGamesController(IBggApiClient bggApiClient, IContentParser contentParser, IMapper mapper)
        {
            _bggApiClient = bggApiClient;
            _contentParser = contentParser;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BoardGameModel>> Get(int id)
        {
            var parameters = new RequestGameParameters();
            parameters.BggIds = new[]
                {
                    id
                };

            var gameContent = await _bggApiClient.GetGameContentAsync(parameters);
            var game = _contentParser.ParseGame(gameContent);
            var model = _mapper.Map<BoardGameModel>(game);
            return Ok(model);
        }
    }
}
