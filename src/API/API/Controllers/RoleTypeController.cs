namespace Numployable.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using MediatR;

using Application.DTOs.InfrastructureData;
using Application.Features.InfrastructureData.Requests.Queries;

[Route("api/[controller]")]
[ApiController]
public class RoleTypeController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<RoleTypeDto>>> GetRoleTypeList()
    {
        List<RoleTypeDto> roleTypeList = await mediator.Send(
            new GetRoleTypeListRequest()
        );

        return Ok(roleTypeList);
    }

    [HttpGet("{description}")]
    public async Task<ActionResult<RoleTypeDto>> GetRoleTypeByDescription(string description)
    {
        RoleTypeDto roleType = await mediator.Send(new GetRoleTypeByDescriptionRequest
        {
            Description = description
        });

        return Ok(roleType);
    }
}
