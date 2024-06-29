namespace Numploy.Application.Features.JobApplications.Requests.Queries;

using MediatR;
using Numploy.Application.DTOs.JobApplications;

public class GetJobApplicationListRequest : IRequest<List<JobApplicationListDto>>
{

}