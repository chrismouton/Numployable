using Mediator;
using Numployable.Application.Responses;

namespace Numployable.Application.Features.JobApplications.Requests.Commands;

public class ProcessUpdateJobApplicationCommand(int id, int processStatusId)
    : ICommand<BaseCommandResponse>
{
    public int Id { get; init; } = id;

    public int ProcessStatusId { get; init; } = processStatusId;
}