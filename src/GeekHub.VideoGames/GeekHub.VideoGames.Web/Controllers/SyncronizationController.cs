using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeekHub.VideoGames.Contracts.Dtos.Synchronization;
using GeekHub.VideoGames.Domain.Commands;
using GeekHub.VideoGames.Domain.Dtos;
using GeekHub.VideoGames.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GeekHub.VideoGames.Web.Controllers
{
    [ApiController]
    [Route("api/synchronization")]
    public class SynchronizationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SynchronizationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [SwaggerOperation(OperationId = "Synchronization_SynchronizeVideoGames")]
        [SwaggerResponse(200, Type = typeof(IEnumerable<VideoGameToSynchronizeResponseDto>))]
        public async Task<IActionResult> SynchronizeVideoGames(IEnumerable<VideoGameToSynchronizeRequestDto> requestDtos)
        {
            var synchronizedGames = new List<VideoGameToSynchronizeResponseDto>();
            foreach (var requestDto in requestDtos)
            {
                var query = new GetVideoGameToSynchronizeQuery(requestDto);
                var game = await _mediator.Send(query);

                if (game == null)
                {
                    //Create
                    var createVideoGameDto = new CreateVideoGameRequestDto(requestDto.Name);
                    var command = new CreateVideoGameCommand(createVideoGameDto);
                    var createdResponse = await _mediator.Send(command);
                    
                    var synchronizedGame = new VideoGameToSynchronizeResponseDto()
                    {
                        Id = requestDto.Id,
                        Name = requestDto.Name,
                        GeekHubId = createdResponse.Id
                    };
                    synchronizedGames.Add(synchronizedGame);
                }
                else
                {
                    var synchronizedGame = new VideoGameToSynchronizeResponseDto()
                    {
                        Id = requestDto.Id,
                        Name = requestDto.Name,
                        GeekHubId = game.Id
                    };
                    synchronizedGames.Add(synchronizedGame);
                }
            }
            
            return Ok(synchronizedGames);
        }
    }
}