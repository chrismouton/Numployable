namespace Numployable.Application.Features.JobApplications.Handlers.Commands;

using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Numployable.Application.Features.JobApplications.Requests.Commands;
using Persistence.Contracts;
using Responses;

public class RejectJobApplicationCommandHandler(IJobApplicationRepository jobApplicationRepository)
    : IRequestHandler<RejectJobApplicationCommand, BaseCommandResponse>
{
    private readonly IJobApplicationRepository _jobApplicationRepository = jobApplicationRepository;

    public async Task<BaseCommandResponse> Handle(RejectJobApplicationCommand request, CancellationToken cancellationToken)
    {
        BaseCommandResponse response = new();

        Domain.JobApplication jobApplication = new()
        {
            Id = request.Id,
            Status = Status.Closed,
            ProcessStatus = ProcessStatus.Rejected
        };

        await _jobApplicationRepository.Update(jobApplication);

        response.Success = true;
        response.Message = "Successfully update process status for application.";
        response.Id = request.Id;

        return response;
    }
}