using Mediator;
using Numployable.Application.Features.JobApplications.Requests.Commands;
using Numployable.Application.Persistence.Contracts;
using Numployable.Application.Responses;
using Numployable.Domain;

namespace Numployable.Application.Features.JobApplications.Handlers.Commands;

public class ProcessUpdateJobApplicationCommandHandler(
    IJobApplicationRepository jobApplicationRepository,
    IProcessStatusRepository processStatusRepository)
    : IRequestHandler<ProcessUpdateJobApplicationCommand, BaseCommandResponse>
{
    private readonly IJobApplicationRepository _jobApplicationRepository = jobApplicationRepository;

    private readonly IProcessStatusRepository _processStatusRepository = processStatusRepository;

    public async ValueTask<BaseCommandResponse> Handle(ProcessUpdateJobApplicationCommand request,
        CancellationToken cancellationToken)
    {
        BaseCommandResponse response = new();

        ProcessStatus? processStatus = await _processStatusRepository.Get(request.ProcessStatusId);
        if (processStatus == null)
        {
            response.Success = false;
            response.Message =
                string.Format(
                    $"'ProcessStatus' with id {request.ProcessStatusId} could not be found in the repository.");
            response.Id = request.Id;
            return response;
        }

        JobApplication jobApplication = new()
        {
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