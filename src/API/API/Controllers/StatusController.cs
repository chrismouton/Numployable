namespace Numployable.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using MediatR;

using Application.DTOs.InfrastructureData;
using Application.Features.InfrastructureData.Requests.Queries;

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

    [HttpGet("{description}")]
    public async Task<ActionResult<StatusDto>> GetStatusByDescription(string description)
    {
        StatusDto status = await mediator.Send(new GetStatusByDescriptionRequest
        {
            Description = description
        });

        return Ok(status);
    }
}
