using MediatR;
using Numployable.Application.Features.JobApplications.Requests.Commands;
using Numployable.Application.Persistence.Contracts;
using Numployable.Application.Responses;
using Numployable.Domain;

namespace Numployable.Application.Features.JobApplications.Handlers.Commands;

public class RejectJobApplicationCommandHandler(IJobApplicationRepository jobApplicationRepository, IStatusRepository statusRepository, IProcessStatusRepository processStatusRepository)
    : IRequestHandler<RejectJobApplicationCommand, BaseCommandResponse>
{
    private readonly IJobApplicationRepository _jobApplicationRepository = jobApplicationRepository;

    private readonly IStatusRepository _statusRepository = statusRepository;

    private readonly IProcessStatusRepository _processStatusRepository = processStatusRepository;

    public async Task<BaseCommandResponse> Handle(RejectJobApplicationCommand request, CancellationToken cancellationToken)
    {
        BaseCommandResponse response = new();

        Status status = _statusRepository.GetByDescription("Closed");
        if (status == null)
        {
            response.Success = false;
            response.Message = "'Status' with value 'Closed' could not be found in the repository.";
            response.Id = request.Id;
            return response;
        }
        ProcessStatus processStatus = _processStatusRepository.GetByDescription("Rejected");
        if (processStatus == null)
        {
            response.Success = false;
            response.Message = "'ProcessStatus' with value 'Rejected' could not be found in the repository.";
            response.Id = request.Id;
            return response;
        }

        JobApplication jobApplication = new()
        {
            Id = request.Id,
            StatusId = status.Id,
            Status = status,
            ProcessStatusId = processStatus.Id,
            ProcessStatus = processStatus
        };

        await _jobApplicationRepository.Update(jobApplication);

        response.Success = true;
        response.Message = "Successfully update process status for application.";
        response.Id = request.Id;

        return response;
    }
}