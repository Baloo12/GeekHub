using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeekHub.VideoGames.Domain.Commands;
using GeekHub.VideoGames.Domain.Dtos;
using GeekHub.VideoGames.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GeekHub.VideoGames.Web.Controllers
{
    [ApiController]
    [Route("api/video-games")]
    public class VideoGamesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VideoGamesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [SwaggerOperation(OperationId = "VideoGames_Get")]
        [SwaggerResponse(200, Type = typeof(VideoGameResponseDto))]
        [SwaggerResponse(404)]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetVideoGameByIdQuery(id);
            var response = await _mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }
            
            return Ok(response);
        }
        
        [HttpGet("{id}/{externalSource}")]
        [SwaggerOperation(OperationId = "VideoGames_GetExternalDetails")]
        [SwaggerResponse(200, Type = typeof(VideoGameResponseDto))]
        [SwaggerResponse(404)]
        public async Task<IActionResult> GetExternalDetails(Guid id, string externalSource)
        {
            var query = new GetVideoGameExternalDetailsQuery(id, externalSource);
            var response = await _mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }
            
            return Ok(response);
        }

        [HttpGet]
        [SwaggerOperation(OperationId = "VideoGames_GetAll")]
        [SwaggerResponse(200, Type = typeof(IEnumerable<VideoGameResponseDto>))]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllVideoGamesQuery();
            var response = await _mediator.Send(query);
            
            return Ok(response);
        }

        [HttpPost]
        [SwaggerOperation(OperationId = "VideoGames_Create")]
        [SwaggerResponse(201, Type = typeof(VideoGameResponseDto))]
        public async Task<IActionResult> Create([FromBody]CreateVideoGameRequestDto requestDto)
        {
            var command = new CreateVideoGameCommand(requestDto);
            var response = await _mediator.Send(command);
            
            return CreatedAtAction("Get", new { id = response.Id }, response);
        }
    }
}