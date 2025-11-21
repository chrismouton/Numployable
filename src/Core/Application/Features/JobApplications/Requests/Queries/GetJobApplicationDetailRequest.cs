using Mediator;
using Numployable.Application.DTOs.JobApplications;

namespace Numployable.Application.Features.JobApplications.Requests.Queries;

public class GetJobApplicationDetailRequest(int id)
    : IQuery<JobApplicationDto>
{
    public int Id { get; init; } = id;
}