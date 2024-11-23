using MediatR;
using Microsoft.AspNetCore.Mvc;
using Numployable.Application.DTOs.InfrastructureData;
using Numployable.Application.Features.InfrastructureData.Requests.Queries;

namespace Numployable.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatusController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<List<StatusDto>>> GetStatusList()
    {
        List<StatusDto> statusList = await _mediator.Send(
            new GetStatusListRequest()
        );

        return Ok(statusList);
    }
}
