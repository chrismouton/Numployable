using MediatR;
using Microsoft.AspNetCore.Mvc;
using Numployable.Application.DTOs.NextActions;
using Numployable.Application.Features.NextActions.Requests.Commands;
using Numployable.Application.Features.NextActions.Requests.Queries;
using Numployable.Application.Responses;

namespace Numployable.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NextActionController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<List<NextActionDto>>> Get()
    {
        List<NextActionDto>? nextActions = await _mediator.Send(new GetNextActionListRequest());

        return Ok(nextActions);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<NextActionDto>> Get(int id)
    {
        NextActionDto? nextAction = await _mediator.Send(new GetNextActionDetailRequest { Id = id });

        return Ok(nextAction);
    }

    [HttpPost]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateNextActionDto application)
    {
        CreateNextActionCommand? command = new() { CreateNextActionDto = application };
        BaseCommandResponse? response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<BaseCommandResponse>> Put(int id, [FromBody] UpdateNextActionDto NextAction)
    {
        UpdateNextActionCommand? command = new() { Id = id, UpdateNextActionDto = NextAction };
        BaseCommandResponse? response = await _mediator.Send(command);

        return Ok(response);
    }
}