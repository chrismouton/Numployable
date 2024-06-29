namespace Numployable.Application.Features.JobApplications.Requests.Commands;

using MediatR;

using Numployable.Application.DTOs.JobApplications;
using Numployable.Application.Responses;

public class UpdateJobApplicationCommand : IRequest<BaseCommandResponse>
{
    public int Id { get; set; }

    public UpdateJobApplicationDto? UpdateJobApplicationDto { get; set; }

    public ExpiredJobApplicationDto? ExpiredJobApplicationDto { get; set; }

    public ProcessUpdateJobApplicationDto? ProcessUpdateJobApplicationDto { get; set; }

    public RejectedJobApplicationDto? RejectedJobApplicationDto { get; set; }
}