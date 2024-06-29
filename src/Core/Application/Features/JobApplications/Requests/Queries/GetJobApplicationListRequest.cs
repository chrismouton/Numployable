namespace Numployable.Application.Features.JobApplications.Requests.Queries;

using MediatR;
using Numployable.Application.DTOs.JobApplications;

public class GetJobApplicationListRequest : IRequest<List<JobApplicationListDto>>
{

}