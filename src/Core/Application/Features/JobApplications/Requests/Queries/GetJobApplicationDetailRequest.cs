using Mediator;
using Numployable.Application.DTOs.JobApplications;

namespace Numployable.Application.Features.JobApplications.Requests.Queries;

public class GetJobApplicationDetailRequest : IRequest<JobApplicationDto>
{
    public int Id { get; set; }
}