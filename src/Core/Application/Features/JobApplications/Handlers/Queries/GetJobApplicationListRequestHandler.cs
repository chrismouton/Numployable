using AutoMapper;
using MediatR;
using Numployable.Application.DTOs.JobApplications;
using Numployable.Application.Features.JobApplications.Requests.Queries;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

namespace Numployable.Application.Features.JobApplications.Handlers.Queries;

public class GetJobApplicationListRequestHandler(IJobApplicationRepository jobApplicationRepository, IMapper mapper) 
    : IRequestHandler<GetJobApplicationListRequest, List<JobApplicationListDto>>
{
    public async Task<List<JobApplicationListDto>> Handle(GetJobApplicationListRequest request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<JobApplication> jobApplications = await jobApplicationRepository.GetAll();

        return mapper.Map<List<JobApplicationListDto>>(jobApplications);
    }
}