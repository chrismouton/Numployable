namespace Numployable.Application.Features.JobApplications.Requests.Commands;

using MediatR;

using Numployable.Application.DTOs.JobApplications;
using Numployable.Application.Responses;

public class CreateJobApplicationCommand : IRequest<BaseCommandResponse>
{
    public JobApplicationDto? JobApplicationDto { get; set; }
}