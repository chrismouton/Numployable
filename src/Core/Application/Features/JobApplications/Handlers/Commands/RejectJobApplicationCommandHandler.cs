using MediatR;
using Numployable.Application.Features.JobApplications.Requests.Commands;
using Numployable.Application.Persistence.Contracts;
using Numployable.Application.Responses;
using Numployable.Domain;

namespace Numployable.Application.Features.JobApplications.Handlers.Commands;

public class RejectJobApplicationCommandHandler(IJobApplicationRepository jobApplicationRepository, IStatusRepository _statusRepository, IProcessStatusRepository _processStatusRepository)
    : IRequestHandler<RejectJobApplicationCommand, BaseCommandResponse>
{
    public async Task<BaseCommandResponse> Handle(RejectJobApplicationCommand request, CancellationToken cancellationToken)
    {
        BaseCommandResponse response = new();

        Status status = await _statusRepository.GetByDescription("Closed");
        if (status == null)
        {
            response.Success = false;
            response.Message = "'Status' with value 'Closed' could not be found in the repository.";
            response.Id = request.Id;
            return response;
        }
        ProcessStatus processStatus = await _processStatusRepository.GetByDescription("Rejected");
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

        await jobApplicationRepository.Update(jobApplication);

        response.Success = true;
        response.Message = "Successfully update process status for application.";
        response.Id = request.Id;

        return response;
    }
}