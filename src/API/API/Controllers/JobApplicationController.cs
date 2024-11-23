using MediatR;
using Microsoft.AspNetCore.Mvc;
using Numployable.Application.DTOs.JobApplications;
using Numployable.Application.Features.JobApplications.Requests.Commands;
using Numployable.Application.Features.JobApplications.Requests.Queries;
using Numployable.Application.Responses;

namespace Numployable.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobApplicationController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<List<JobApplicationListDto>>> Get()
    {
        var jobApplications = await _mediator.Send(new GetJobApplicationListRequest());

        return Ok(jobApplications);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<JobApplicationDto>> Get(int id)
    {
        var jobApplication = await _mediator.Send(new GetJobApplicationDetailRequest {Id = id});

        return Ok(jobApplication);
    }

    [HttpPost]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateJobApplicationDto jobApplicationDto)
    {
        var command = new CreateJobApplicationCommand { CreateJobApplicationDto = jobApplicationDto };
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateJobApplicationDto jobApplicationDto)
    {
        var command = new UpdateJobApplicationCommand { Id = id, UpdateJobApplicationDto = jobApplicationDto};
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPut("expire/{id}")]
    public async Task<ActionResult<BaseCommandResponse>> ExpireJobApplication(int id)
    {
        var command = new ExpireJobApplicationCommand { Id = id };
        BaseCommandResponse response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpPut("processupdate/{jobApplicationId}/{processStatusId}")]
    public async Task<ActionResult<BaseCommandResponse>> ProcessUpdateJobApplication(int jobApplicationId, int processStatusId)
    {
        var command = new ProcessUpdateJobApplicationCommand { 
            Id = jobApplicationId, 
            ProcessStatusId = processStatusId
        };

        BaseCommandResponse response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpPut("reject/{id}")]
    public async Task<ActionResult<BaseCommandResponse>> RejectJobApplication(int id)
    {
        var command = new RejectJobApplicationCommand { Id = id };
        BaseCommandResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}
