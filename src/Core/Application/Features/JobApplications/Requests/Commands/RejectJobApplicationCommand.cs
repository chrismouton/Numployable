namespace Numployable.Application.Features.JobApplications.Requests.Commands;

using MediatR;

using Numployable.Application.Responses;

public class RejectJobApplicationCommand : IRequest<BaseCommandResponse>
{
    public int Id { get; set; }
}