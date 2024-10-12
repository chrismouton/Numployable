namespace Numployable.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using MediatR;

using Application.DTOs.InfrastructureData;
using Application.Features.InfrastructureData.Requests.Queries;

[Route("api/[controller]")]
[ApiController]
public class RoleTypeController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<List<RoleTypeDto>>> GetRoleTypeList()
    {
        List<RoleTypeDto> roleTypeList = await _mediator.Send(
            new GetRoleTypeListRequest()
        );

        return Ok(roleTypeList);
    }
}
