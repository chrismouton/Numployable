namespace Numployable.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using MediatR;

using Application.DTOs.InfrastructureData;
using Application.Features.InfrastructureData.Requests.Queries;

[Route("api/[controller]")]
[ApiController]
public class ProcessStatusController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<List<ProcessStatusDto>>> GetProcessStatusList()
    {
        List<ProcessStatusDto> processStatusList = await _mediator.Send(
            new GetProcessStatusListRequest()
        );

        return Ok(processStatusList);
    }

    [HttpGet("{description}")]
    public async Task<ActionResult<ProcessStatusDto>> GetProcessStatusByDescription(string description)
    {
        ProcessStatusDto processStatus = await _mediator.Send(
            new GetProcessStatusByDescriptionRequest {
                Description = description
            }
        );

        return Ok(processStatus);
    }
}
