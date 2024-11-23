using MediatR;
using Microsoft.AspNetCore.Mvc;
using Numployable.Application.DTOs.InfrastructureData;
using Numployable.Application.Features.InfrastructureData.Requests.Queries;

namespace Numployable.API.Controllers;

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
