using MediatR;
using Numployable.Application.Responses;

namespace Numployable.Application.Features.JobApplications.Requests.Commands;

public class RejectJobApplicationCommand : IRequest<BaseCommandResponse>
{
    public int Id { get; set; }
}