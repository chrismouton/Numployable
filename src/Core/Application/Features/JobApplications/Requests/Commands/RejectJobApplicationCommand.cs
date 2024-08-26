namespace Numployable.Application.Features.JobApplications.Requests.Commands;

using MediatR;

using Responses;

public class RejectJobApplicationCommand : IRequest<BaseCommandResponse>
{
    public int Id { get; set; }
}