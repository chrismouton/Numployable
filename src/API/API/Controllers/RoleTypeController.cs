using MediatR;
using Microsoft.AspNetCore.Mvc;
using Numployable.Application.DTOs.InfrastructureData;
using Numployable.Application.Features.InfrastructureData.Requests.Queries;

namespace Numployable.API.Controllers;

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
