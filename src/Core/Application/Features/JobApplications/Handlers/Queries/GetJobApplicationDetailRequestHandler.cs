using MediatR;
using Numployable.Application.DTOs.JobApplications;
using Numployable.Application.Features.JobApplications.Requests.Queries;
using Numployable.Application.Mappings;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

namespace Numployable.Application.Features.JobApplications.Handlers.Queries;

public class GetJobApplicationDetailRequestHandler(IJobApplicationRepository jobApplicationRepository)
    : IRequestHandler<GetJobApplicationDetailRequest, JobApplicationDto>
{
    public async Task<JobApplicationDto> Handle(GetJobApplicationDetailRequest request,
        CancellationToken cancellationToken)
    {
        JobApplication? jobApplication = await jobApplicationRepository.GetJobApplicationWithDetails(request.Id);

        return jobApplication.ToJobApplication();
    }
}