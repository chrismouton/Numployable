namespace Numployable.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using MediatR;

using Application.DTOs.InfrastructureData;
using Application.Features.InfrastructureData.Requests.Queries;

[Route("api/[controller]")]
[ApiController]
public class InfrastructureDataController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<List<CommuteDto>>> GetCommuteList()
    {
        List<CommuteDto> commuteList = await _mediator.Send(new GetCommuteListRequest());

        return Ok(commuteList);
    }

    [HttpGet]
    public async Task<ActionResult<List<ProcessStatusDto>>> GetProcessStatusList()
    {
        List<ProcessStatusDto> processStatusList = await _mediator.Send(
            new GetProcessStatusListRequest()
        );

        return Ok(processStatusList);
    }

    [HttpGet]
    public async Task<ActionResult<List<RoleTypeDto>>> GetRoleTypeList()
    {
        List<RoleTypeDto> roleTypeList = await _mediator.Send(
            new GetRoleTypeListRequest()
        );

        return Ok(roleTypeList);
    }

    [HttpGet]
    public async Task<ActionResult<List<SourceDto>>> GetSourceList()
    {
        List<SourceDto> sourceList = await _mediator.Send(
            new GetSourceListRequest()
        );

        return Ok(sourceList);
    }

    [HttpGet]
    public async Task<ActionResult<List<StatusDto>>> GetStatusList()
    {
        List<StatusDto> statusList = await _mediator.Send(
            new GetStatusListRequest()
        );

        return Ok(statusList);
    }
}
