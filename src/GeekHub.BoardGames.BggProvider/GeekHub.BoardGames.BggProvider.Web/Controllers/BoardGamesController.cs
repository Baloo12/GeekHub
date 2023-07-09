namespace GeekHub.BoardGames.BggProvider.Web.Controllers
{
    using System.Threading.Tasks;

    using GeekHub.BoardGames.BggProvider.Domain.Queries;

    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/games")]
    public class BoardGamesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BoardGamesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var request = new QueryGameByIdRequest(id);
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
