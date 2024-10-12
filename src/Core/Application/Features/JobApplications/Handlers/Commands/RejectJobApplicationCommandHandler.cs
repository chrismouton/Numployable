namespace Numployable.Application.Features.JobApplications.Handlers.Commands;

using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Numployable.Application.Features.JobApplications.Requests.Commands;
using Persistence.Contracts;
using Responses;

public class RejectJobApplicationCommandHandler(IJobApplicationRepository jobApplicationRepository, IStatusRepository statusRepository, IProcessStatusRepository processStatusRepository)
    : IRequestHandler<RejectJobApplicationCommand, BaseCommandResponse>
{
    private readonly IJobApplicationRepository _jobApplicationRepository = jobApplicationRepository;

    private readonly IStatusRepository _statusRepository = statusRepository;

    private readonly IProcessStatusRepository _processStatusRepository = processStatusRepository;

    public async Task<BaseCommandResponse> Handle(RejectJobApplicationCommand request, CancellationToken cancellationToken)
    {
        BaseCommandResponse response = new();

        Domain.Status status = _statusRepository.GetByDescription("Closed");
        if (status == null)
        {
            response.Success = false;
            response.Message = "'Status' with value 'Closed' could not be found in the repository.";
            response.Id = request.Id;
            return response;
        }
        Domain.ProcessStatus processStatus = _processStatusRepository.GetByDescription("Rejected");
        if (processStatus == null)
        {
            response.Success = false;
            response.Message = "'ProcessStatus' with value 'Rejected' could not be found in the repository.";
            response.Id = request.Id;
            return response;
        }

        Domain.JobApplication jobApplication = new()
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