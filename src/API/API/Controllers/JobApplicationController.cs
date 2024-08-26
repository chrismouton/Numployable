namespace Numployable.API.Controllers;

using Microsoft.AspNetCore.Mvc;

using MediatR;

using Application.DTOs.JobApplications;
using Application.Features.JobApplications.Requests.Queries;
using Application.Features.JobApplications.Requests.Commands;
using Application.Responses;

[Route("api/[controller]")]
[ApiController]
public class JobApplicationController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<List<JobApplicationDto>>> Get()
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
    public async Task<ActionResult> ExpireJobApplication(int id)
    {
        var command = new ExpireJobApplicationCommand { Id = id };
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPut("processupdate/{id}/{processStatus}")]
    public async Task<ActionResult> ProcessUpdateJobApplication(int id, ProcessStatus processStatus)
    {
        var command = new ProcessUpdateJobApplicationCommand { 
            Id = id, 
            ProcessStatus = processStatus
        };
        
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPut("reject/{id}")]
    public async Task<ActionResult> RejectJobApplication(int id)
    {
        var command = new RejectJobApplicationCommand { Id = id };
        await _mediator.Send(command);

        return NoContent();
    }
}
