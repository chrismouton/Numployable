namespace Numployable.Application.Features.JobApplications.Requests.Commands;

using MediatR;

using Responses;

public class ExpireJobApplicationCommand : IRequest<BaseCommandResponse>
{
    public int Id { get; set; }
}