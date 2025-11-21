using Mediator;
using Numployable.Application.Responses;

namespace Numployable.Application.Features.JobApplications.Requests.Commands;

public class ExpireJobApplicationCommand(int id)
    : ICommand<BaseCommandResponse>
{
    public int Id { get; init; } = id;
}