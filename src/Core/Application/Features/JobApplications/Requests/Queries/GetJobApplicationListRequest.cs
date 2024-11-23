using MediatR;
using Numployable.Application.DTOs.JobApplications;

namespace Numployable.Application.Features.JobApplications.Requests.Queries;

public class GetJobApplicationListRequest : IRequest<List<JobApplicationListDto>>
{

}