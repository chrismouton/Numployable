namespace Numployable.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using MediatR;

using Application.DTOs.InfrastructureData;
using Application.Features.InfrastructureData.Requests.Queries;

[Route("api/[controller]")]
[ApiController]
public class CommuteController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<List<CommuteDto>>> GetCommuteList()
    {
        List<CommuteDto> commuteList = await _mediator.Send(new GetCommuteListRequest());

        return Ok(commuteList);
    }
}
