namespace Numployable.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using MediatR;

using Application.DTOs.InfrastructureData;
using Application.Features.InfrastructureData.Requests.Queries;

[Route("api/[controller]")]
[ApiController]
public class SourceController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<List<SourceDto>>> GetSourceList()
    {
        List<SourceDto> sourceList = await _mediator.Send(
            new GetSourceListRequest()
        );

        return Ok(sourceList);
    }
}
