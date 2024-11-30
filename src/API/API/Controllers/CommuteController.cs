namespace Numployable.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using MediatR;

using Application.DTOs.InfrastructureData;
using Application.Features.InfrastructureData.Requests.Queries;

[Route("api/[controller]")]
[ApiController]
public class CommuteController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<CommuteDto>>> GetCommuteList()
    {
        List<CommuteDto> commuteList = await mediator.Send(new GetCommuteListRequest());

        return Ok(commuteList);
    }

    [HttpGet("{description}")]
    public async Task<ActionResult<CommuteDto>> GetCommuteByDescription(string description)
    {
        CommuteDto commute = await mediator.Send(new GetCommuteByDescriptionRequest
        {
            Description = description
        });

        return Ok(commute);
    }
}
