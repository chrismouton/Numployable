using MediatR;
using Numployable.Application.Features.JobApplications.Requests.Commands;
using Numployable.Application.Persistence.Contracts;
using Numployable.Application.Responses;
using Numployable.Domain;

namespace Numployable.Application.Features.JobApplications.Handlers.Commands;

public class ExpireJobApplicationCommandHandler(
    IJobApplicationRepository jobApplicationRepository,
    IStatusRepository statusRepository)
    : IRequestHandler<ExpireJobApplicationCommand, BaseCommandResponse>
{
    private readonly IJobApplicationRepository _jobApplicationRepository = jobApplicationRepository;

    public async Task<BaseCommandResponse> Handle(ExpireJobApplicationCommand request,
        CancellationToken cancellationToken)
    {
        BaseCommandResponse response = new();

        Status? status = await statusRepository.GetByDescription("Expired");
        if (status == null)
        {
            response.Success = false;
            response.Message = "'Status' with value 'Closed' could not be found in the repository.";
            response.Id = request.Id;
            return response;
        }

        JobApplication jobApplication = new()
        {
            Id = request.Id,
            StatusId = status.Id,
            Status = status
        };

        await _jobApplicationRepository.Update(jobApplication);

        response.Success = true;
        response.Message = "Successfully update status for application.";
        response.Id = request.Id;

        return response;
    }
}