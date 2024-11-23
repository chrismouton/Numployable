using MediatR;
using Numployable.Application.DTOs.JobApplications;
using Numployable.Application.Responses;

namespace Numployable.Application.Features.JobApplications.Requests.Commands;

public class CreateJobApplicationCommand : IRequest<BaseCommandResponse>
{
    public CreateJobApplicationDto? CreateJobApplicationDto { get; set; }
}