namespace Numployable.Application.Features.JobApplications.Handlers.Queries;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Numployable.Application.DTOs.JobApplications;
using Numployable.Application.Features.JobApplications.Requests.Queries;
using Persistence.Contracts;
using Domain;

public class GetJobApplicationListRequestHandler(IJobApplicationRepository jobApplicationRepository, IMapper mapper) 
    : IRequestHandler<GetJobApplicationListRequest, List<JobApplicationListDto>>
{
    private readonly IJobApplicationRepository _jobApplicationRepository = jobApplicationRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<JobApplicationListDto>> Handle(GetJobApplicationListRequest request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<JobApplication> jobApplications = await _jobApplicationRepository.GetJobApplicationsWithDetails();

        return _mapper.Map<List<JobApplicationListDto>>(jobApplications);
    }
}