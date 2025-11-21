using Mediator;
using Numployable.Application.DTOs.JobApplications;
using Numployable.Application.Responses;

namespace Numployable.Application.Features.JobApplications.Requests.Commands;

public class UpdateJobApplicationCommand(int id, UpdateJobApplicationDto jobApplication) 
    : ICommand<BaseCommandResponse>
{
    public int Id { get; init; } = id;

    public UpdateJobApplicationDto? UpdateJobApplication { get; init; } = jobApplication;
}