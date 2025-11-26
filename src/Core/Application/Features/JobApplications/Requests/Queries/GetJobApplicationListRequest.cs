using Mediator;
using Numployable.Application.DTOs.JobApplications;

namespace Numployable.Application.Features.JobApplications.Requests.Queries;

public class GetJobApplicationListRequest : IQuery<IEnumerable<JobApplicationListDto>>
{
}