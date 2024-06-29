namespace Numploy.Application.Features.JobApplications.Handlers.Queries;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Numploy.Application.DTOs.JobApplications;
using Numploy.Application.Features.JobApplications.Requests.Queries;
using Numploy.Application.Persistence.Contracts;
using Numploy.Domain;

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