using MediatR;
using Microsoft.AspNetCore.Mvc;
using Numployable.Application.DTOs.Dashboard;
using Numployable.Application.Features.Dashboard.Requests.Queries;

namespace Numployable.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DashboardController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<DashboardDto>> Get()
    {
        var dashboard = await _mediator.Send(new GetDashboardRequest());

        return Ok(dashboard);
    }
}
