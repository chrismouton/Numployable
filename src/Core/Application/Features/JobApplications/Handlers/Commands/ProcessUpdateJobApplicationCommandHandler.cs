namespace Numployable.Application.Features.JobApplications.Handlers.Commands;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Numployable.Application.Features.JobApplications.Requests.Commands;
using Persistence.Contracts;
using Responses;

public class ProcessUpdateJobApplicationCommandHandler(IJobApplicationRepository jobApplicationRepository, IProcessStatusRepository processStatusRepository)
    : IRequestHandler<ProcessUpdateJobApplicationCommand, BaseCommandResponse>
{
    private readonly IJobApplicationRepository _jobApplicationRepository = jobApplicationRepository;

    private readonly IProcessStatusRepository _processStatusRepository = processStatusRepository;

    public async Task<BaseCommandResponse> Handle(ProcessUpdateJobApplicationCommand request, CancellationToken cancellationToken)
    {
        BaseCommandResponse response = new();

        Domain.ProcessStatus processStatus = await _processStatusRepository.Get(request.ProcessStatusId);
        if (processStatus == null)
        {
            response.Success = false;
            response.Message = string.Format($"'ProcessStatus' with id {request.ProcessStatusId} could not be found in the repository.");
            response.Id = request.Id;
            return response;
        }

        Domain.JobApplication jobApplication = new () {
            Id = request.Id,
            ProcessStatusId = request.ProcessStatusId,
            ProcessStatus = processStatus
        };

        await _jobApplicationRepository.Update(jobApplication);

        response.Success = true;
        response.Message = "Successfully update process status for application.";
        response.Id = request.Id;

        return response;
    }
}