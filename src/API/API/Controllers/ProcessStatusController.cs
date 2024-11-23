using MediatR;
using Microsoft.AspNetCore.Mvc;
using Numployable.Application.DTOs.InfrastructureData;
using Numployable.Application.Features.InfrastructureData.Requests.Queries;

namespace Numployable.API.Controllers;

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
}
