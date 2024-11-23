using MediatR;
using Numployable.Application.Responses;

namespace Numployable.Application.Features.JobApplications.Requests.Commands;

public class ProcessUpdateJobApplicationCommand : IRequest<BaseCommandResponse>
{
    public int Id { get; set; }

    public int ProcessStatusId { get; set; }
}