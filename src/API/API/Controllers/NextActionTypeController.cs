namespace Numployable.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using MediatR;

using Application.DTOs.InfrastructureData;
using Application.Features.InfrastructureData.Requests.Queries;

[Route("api/[controller]")]
[ApiController]
public class NextActionTypeController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<NextActionTypeDto>>> GetNextActionTypeList()
    {
        List<NextActionTypeDto> nextActionTypeList = await mediator.Send(new GetNextActionTypeListRequest());

        return Ok(nextActionTypeList);
    }

    [HttpGet("{description}")]
    public async Task<ActionResult<NextActionTypeDto>> GetNextActionTypeByDescription(string description)
    {
        NextActionTypeDto nextActionType = await mediator.Send(new GetNextActionTypeByDescriptionRequest
        {
            Description = description
        });

        return Ok(nextActionType);
    }
}
