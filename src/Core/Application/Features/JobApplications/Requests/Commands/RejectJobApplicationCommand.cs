using Mediator;
using Numployable.Application.Responses;

namespace Numployable.Application.Features.JobApplications.Requests.Commands;

public class RejectJobApplicationCommand(int id)
    : ICommand<BaseCommandResponse>
{
    public int Id { get; init; } = id;
}