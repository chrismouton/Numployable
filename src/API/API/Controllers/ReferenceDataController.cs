namespace Numployable.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using MediatR;

using Application.DTOs.ReferenceData;
using Application.Features.ReferenceData.Requests.Queries;

[Route("api/[controller]")]
[ApiController]
public class ReferenceDataController(IMediator _mediator) : ControllerBase
{
    [HttpGet("processstatus")]
    public async Task<ActionResult<List<ProcessStatusDto>>> GetProcessStatusList()
    {
        List<ProcessStatusDto> processStatusList = await _mediator.Send(
            new GetProcessStatusListRequest()
        );

        return Ok(processStatusList);
    }

    [HttpGet("processstatus/{description}")]
    public async Task<ActionResult<ProcessStatusDto>> GetProcessStatusByDescription(string description)
    {
        ProcessStatusDto processStatus = await _mediator.Send(
            new GetProcessStatusByDescriptionRequest {
                Description = description
            }
        );

        return Ok(processStatus);
    }

    [HttpGet("commute")]
    public async Task<ActionResult<List<CommuteDto>>> GetCommuteList()
    {
        List<CommuteDto> commuteList = await _mediator.Send(new GetCommuteListRequest());

        return Ok(commuteList);
    }

    [HttpGet("commute/{description}")]
    public async Task<ActionResult<CommuteDto>> GetCommuteByDescription(string description)
    {
        CommuteDto commute = await _mediator.Send(new GetCommuteByDescriptionRequest
        {
            Description = description
        });

        return Ok(commute);
    }

    [HttpGet("nextactiontype")]
    public async Task<ActionResult<List<NextActionTypeDto>>> GetNextActionTypeList()
    {
        List<NextActionTypeDto> nextActionTypeList = await _mediator.Send(new GetNextActionTypeListRequest());

        return Ok(nextActionTypeList);
    }

    [HttpGet("nextactiontype/{description}")]
    public async Task<ActionResult<NextActionTypeDto>> GetNextActionTypeByDescription(string description)
    {
        NextActionTypeDto nextActionType = await _mediator.Send(new GetNextActionTypeByDescriptionRequest
        {
            Description = description
        });

        return Ok(nextActionType);
    }

    [HttpGet("roletype")]
    public async Task<ActionResult<List<RoleTypeDto>>> GetRoleTypeList()
    {
        List<RoleTypeDto> roleTypeList = await _mediator.Send(
            new GetRoleTypeListRequest()
        );

        return Ok(roleTypeList);
    }

    [HttpGet("roletype/{description}")]
    public async Task<ActionResult<RoleTypeDto>> GetRoleTypeByDescription(string description)
    {
        RoleTypeDto roleType = await _mediator.Send(new GetRoleTypeByDescriptionRequest
        {
            Description = description
        });

        return Ok(roleType);
    }

    [HttpGet("source")]
    public async Task<ActionResult<List<SourceDto>>> GetSourceList()
    {
        List<SourceDto> sourceList = await _mediator.Send(
            new GetSourceListRequest()
        );

        return Ok(sourceList);
    }

    [HttpGet("source/{description}")]
    public async Task<ActionResult<SourceDto>> GetSourceByDescription(string description)
    {
        SourceDto source = await _mediator.Send(
            new GetSourceByDescriptionRequest {
                Description = description
            }
        );

        return Ok(source);
    }

    [HttpGet("status")]
    public async Task<ActionResult<List<StatusDto>>> GetStatusList()
    {
        List<StatusDto> statusList = await _mediator.Send(
            new GetStatusListRequest()
        );

        return Ok(statusList);
    }

    [HttpGet("status/{description}")]
    public async Task<ActionResult<StatusDto>> GetStatusByDescription(string description)
    {
        StatusDto status = await _mediator.Send(new GetStatusByDescriptionRequest
        {
            Description = description
        });

        return Ok(status);
    }
}