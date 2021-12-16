namespace GeekHub.BoardGames.BggProvider.Web.Controllers
{
    using System.Threading.Tasks;

    using GeekHub.BoardGames.BggProvider.Domain.Queries;

    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/plays")]
    public class PlaysController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlaysController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userName}")]
        public async Task<IActionResult> GetAllByUserName(string userName)
        {
            var request = new QueryPlaysByUserNameRequest(userName);
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
