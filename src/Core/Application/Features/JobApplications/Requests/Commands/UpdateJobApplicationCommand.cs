namespace Numployable.Application.Features.JobApplications.Requests.Commands;

using MediatR;

using Numployable.Application.DTOs.JobApplications;
using Responses;

public class UpdateJobApplicationCommand : IRequest<BaseCommandResponse>
{
    public int Id { get; set; }

    public UpdateJobApplicationDto? UpdateJobApplicationDto { get; set; }
}