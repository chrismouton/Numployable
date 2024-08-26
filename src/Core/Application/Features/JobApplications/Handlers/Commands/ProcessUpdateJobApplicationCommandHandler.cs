namespace Numployable.Application.Features.JobApplications.Handlers.Commands;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Numployable.Application.Features.JobApplications.Requests.Commands;
using Persistence.Contracts;
using Responses;

public class ProcessUpdateJobApplicationCommandHandler(IJobApplicationRepository jobApplicationRepository)
    : IRequestHandler<ProcessUpdateJobApplicationCommand, BaseCommandResponse>
{
    private readonly IJobApplicationRepository _jobApplicationRepository = jobApplicationRepository;

    public async Task<BaseCommandResponse> Handle(ProcessUpdateJobApplicationCommand request, CancellationToken cancellationToken)
    {
        BaseCommandResponse response = new();

        Domain.JobApplication jobApplication = new () {
            Id = request.Id,
            ProcessStatus = request.ProcessStatus
        };

        await _jobApplicationRepository.Update(jobApplication);

        response.Success = true;
        response.Message = "Successfully update process status for application.";
        response.Id = request.Id;

        return response;
    }
}