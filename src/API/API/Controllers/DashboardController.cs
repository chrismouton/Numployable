namespace Numployable.API.Controllers;

using Microsoft.AspNetCore.Mvc;

using MediatR;

using Application.DTOs.Dashboard;
using Application.Features.Dashboard.Requests.Queries;
using Application.Responses;

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
