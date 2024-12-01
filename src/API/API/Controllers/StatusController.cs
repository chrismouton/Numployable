using MediatR;
using Microsoft.AspNetCore.Mvc;
using Numployable.Application.DTOs.InfrastructureData;
using Numployable.Application.Features.InfrastructureData.Requests.Queries;

namespace Numployable.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatusController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<StatusDto>>> GetStatusList()
    {
        List<StatusDto> statusList = await mediator.Send(
            new GetStatusListRequest()
        );

        return Ok(statusList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StatusDto>> GetStatus1(int id)
    {
        StatusDto status = await mediator.Send(new GetStatusDetailRequest {  Id = id });
    
        return Ok(status);
    }
}
