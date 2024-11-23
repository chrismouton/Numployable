using MediatR;
using Microsoft.AspNetCore.Mvc;
using Numployable.Application.DTOs.InfrastructureData;
using Numployable.Application.Features.InfrastructureData.Requests.Queries;

namespace Numployable.API.Controllers;

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
