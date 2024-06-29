namespace Numploy.Application.Features.JobApplications.Requests.Commands;

using MediatR;

using Numploy.Application.DTOs.JobApplications;
using Numploy.Application.Responses;

public class CreateJobApplicationCommand : IRequest<BaseCommandResponse>
{
    public JobApplicationDto? JobApplicationDto { get; set; }
}