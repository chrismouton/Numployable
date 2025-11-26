using Mediator;
using Microsoft.AspNetCore.Mvc;
using Numployable.Application.DTOs.ReferenceData;
using Numployable.Application.Features.ReferenceData.Requests.Queries;

namespace Numployable.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReferenceDataController(IMediator mediator) : ControllerBase
{
    [HttpGet("processstatus")]
    public async Task<ActionResult<IEnumerable<ProcessStatusDto>>> GetProcessStatusList()
    {
        IEnumerable<ProcessStatusDto>? processStatusList = await mediator.Send(
            new GetProcessStatusListRequest()
        );

        return Ok(processStatusList);
    }

    [HttpGet("processstatus/{description}")]
    public async Task<ActionResult<ProcessStatusDto>> GetProcessStatusByDescription(string description)
    {
        ProcessStatusDto? processStatus = await mediator.Send(
            new GetProcessStatusByDescriptionRequest(description));

        return Ok(processStatus);
    }

    [HttpGet("commute")]
    public async Task<ActionResult<IEnumerable<CommuteDto>>> GetCommuteList()
    {
        IEnumerable<CommuteDto>? commuteList = await mediator.Send(new GetCommuteListRequest());

        return Ok(commuteList);
    }

    [HttpGet("commute/{description}")]
    public async Task<ActionResult<CommuteDto>> GetCommuteByDescription(string description)
    {
        CommuteDto? commute = await mediator.Send(new GetCommuteByDescriptionRequest(description));

        return Ok(commute);
    }

    [HttpGet("nextactiontype")]
    public async Task<ActionResult<IEnumerable<NextActionTypeDto>>> GetNextActionTypeList()
    {
        IEnumerable<NextActionTypeDto>? nextActionTypeList = await mediator.Send(new GetNextActionTypeListRequest());

        return Ok(nextActionTypeList);
    }

    [HttpGet("nextactiontype/{description}")]
    public async Task<ActionResult<NextActionTypeDto>> GetNextActionTypeByDescription(string description)
    {
        NextActionTypeDto? nextActionType = await mediator.Send(new GetNextActionTypeByDescriptionRequest(description));

        return Ok(nextActionType);
    }

    [HttpGet("roletype")]
    public async Task<ActionResult<IEnumerable<RoleTypeDto>>> GetRoleTypeList()
    {
        IEnumerable<RoleTypeDto>? roleTypeList = await mediator.Send(
            new GetRoleTypeListRequest()
        );

        return Ok(roleTypeList);
    }

    [HttpGet("roletype/{description}")]
    public async Task<ActionResult<RoleTypeDto>> GetRoleTypeByDescription(string description)
    {
        RoleTypeDto? roleType = await mediator.Send(new GetRoleTypeByDescriptionRequest(description));

        return Ok(roleType);
    }

    [HttpGet("source")]
    public async Task<ActionResult<IEnumerable<SourceDto>>> GetSourceList()
    {
        IEnumerable<SourceDto>? sourceList = await mediator.Send(
            new GetSourceListRequest()
        );

        return Ok(sourceList);
    }

    [HttpGet("source/{description}")]
    public async Task<ActionResult<SourceDto>> GetSourceByDescription(string description)
    {
        SourceDto? source = await mediator.Send(
            new GetSourceByDescriptionRequest(description)
        );

        return Ok(source);
    }

    [HttpGet("status")]
    public async Task<ActionResult<IEnumerable<StatusDto>>> GetStatusList()
    {
        IEnumerable<StatusDto>? statusList = await mediator.Send(
            new GetStatusListRequest()
        );

        return Ok(statusList);
    }

    [HttpGet("status/{description}")]
    public async Task<ActionResult<StatusDto>> GetStatusByDescription(string description)
    {
        StatusDto? status = await mediator.Send(new GetStatusByDescriptionRequest(description));

        return Ok(status);
    }
}