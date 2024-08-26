namespace Numployable.Application.Features.JobApplications.Requests.Commands;

using MediatR;

using Responses;

public class ProcessUpdateJobApplicationCommand : IRequest<BaseCommandResponse>
{
    public int Id { get; set; }

    public ProcessStatus ProcessStatus { get; set; }
}