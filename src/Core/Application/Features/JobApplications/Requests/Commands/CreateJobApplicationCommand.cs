namespace Numployable.Application.Features.JobApplications.Requests.Commands;

using MediatR;

using Numployable.Application.DTOs.JobApplications;
using Responses;

public class CreateJobApplicationCommand : IRequest<BaseCommandResponse>
{
    public CreateJobApplicationDto? CreateJobApplicationDto { get; set; }
}