using Mediator;
using Numployable.Application.DTOs.JobApplications;
using Numployable.Application.Features.JobApplications.Requests.Queries;
using Numployable.Application.Mappings;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

namespace Numployable.Application.Features.JobApplications.Handlers.Queries;

public class GetJobApplicationListRequestHandler(IJobApplicationRepository jobApplicationRepository)
    : IRequestHandler<GetJobApplicationListRequest, IEnumerable<JobApplicationListDto>>
{
    public async ValueTask<IEnumerable<JobApplicationListDto>> Handle(GetJobApplicationListRequest request,
        CancellationToken cancellationToken)
    {
        IReadOnlyList<JobApplication> jobApplications = await jobApplicationRepository.GetAll();

        return from item in jobApplications
            select item.ToJobApplicationListItem();
    }
}