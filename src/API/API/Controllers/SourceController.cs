namespace Numployable.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using MediatR;

using Application.DTOs.InfrastructureData;
using Application.Features.InfrastructureData.Requests.Queries;

[Route("api/[controller]")]
[ApiController]
public class SourceController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<SourceDto>>> GetSourceList()
    {
        List<SourceDto> sourceList = await mediator.Send(
            new GetSourceListRequest()
        );

        return Ok(sourceList);
    }

    [HttpGet("{description}")]
    public async Task<ActionResult<SourceDto>> GetSourceByDescription(string description)
    {
        SourceDto source = await mediator.Send(
            new GetSourceByDescription {
                Description = description
            }
        );

        return Ok(source);
    }
}
