using Mediator;
using Numployable.Application.DTOs.JobApplications;
using Numployable.Application.Responses;

namespace Numployable.Application.Features.JobApplications.Requests.Commands;

public class CreateJobApplicationCommand(CreateJobApplicationDto jobApplication)
    : ICommand<BaseCommandResponse>
{
    public CreateJobApplicationDto? CreateJobApplication { get; init; } = jobApplication;
}