namespace Numployable.Application.Features.JobApplications.Handlers.Queries;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Numployable.Application.DTOs.JobApplications;
using Numployable.Application.Features.JobApplications.Requests.Queries;
using Persistence.Contracts;

public class GetJobApplicationDetailRequestHandler(IJobApplicationRepository jobApplicationRepository, IMapper mapper) 
    : IRequestHandler<GetJobApplicationDetailRequest, JobApplicationDto>
{
    private readonly IJobApplicationRepository _jobApplicationRepository = jobApplicationRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<JobApplicationDto> Handle(GetJobApplicationDetailRequest request, CancellationToken cancellationToken)
    {
        var jobApplication = await _jobApplicationRepository.GetJobApplicationWithDetails(request.Id);

        return _mapper.Map<JobApplicationDto>(jobApplication);
    }
}