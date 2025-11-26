using Mediator;
using Microsoft.AspNetCore.Mvc;
using Numployable.Application.DTOs.Dashboard;
using Numployable.Application.Features.Dashboard.Requests.Queries;

namespace Numployable.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DashboardController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<DashboardDto>> Get()
    {
        DashboardDto? dashboard = await mediator.Send(new GetDashboardRequest());

        return Ok(dashboard);
    }
}