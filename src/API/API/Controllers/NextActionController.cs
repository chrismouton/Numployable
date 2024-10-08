namespace Numployable.API.Controllers;

using Microsoft.AspNetCore.Mvc;

using MediatR;

using Application.DTOs.NextActions;
using Application.Features.NextActions.Requests.Queries;
using Application.Features.NextActions.Requests.Commands;
using Application.Responses;

[Route("api/[controller]")]
[ApiController]
public class NextActionController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<List<NextActionDto>>> Get()
    {
        var nextActions = await _mediator.Send(new GetNextActionListRequest());

        return Ok(nextActions);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<NextActionDto>> Get(int id)
    {
        var nextAction = await _mediator.Send(new GetNextActionDetailRequest { Id = id });

        return Ok(nextAction);
    }

    [HttpPost]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateNextActionDto application)
    {
        var command = new CreateNextActionCommand { CreateNextActionDto = application };
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<BaseCommandResponse>> Put(int id, [FromBody] UpdateNextActionDto NextAction)
    {
        var command = new UpdateNextActionCommand { Id = id, UpdateNextActionDto = NextAction };
        BaseCommandResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}
