namespace GeekHub.BoardGames.BggProvider.Web.Controllers
{
    using System.Threading.Tasks;

    using AutoMapper;

    using GeekHub.BoardGames.BggProvider.Domain.Api;
    using GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/plays")]
    public class PlaysController : ControllerBase
    {
        private readonly IBggApiClient _bggApiClient;

        private readonly IContentParser _contentParser;

        private readonly IMapper _mapper;

        public PlaysController(IBggApiClient bggApiClient, IContentParser contentParser, IMapper mapper)
        {
            _bggApiClient = bggApiClient;
            _contentParser = contentParser;
            _mapper = mapper;
        }

        // [HttpGet("{userName}")]
        // public async Task<IActionResult> GetAllByUserName(string userName)
        // {
        //     var parameters = new RequestPlaysParameters
        //         {
        //             UserName = "Baloo12"
        //         };
        //
        //     var gameContent = await _bggApiClient.GetPlaysContentAsync(parameters);
        //     var game = _contentParser.ParseGame(gameContent);
        //     var model = _mapper.Map<BoardGameModel>(game);
        //     return Ok(model);
        // }
    }
}
