namespace Numploy.Application.Features.JobApplications.Requests.Queries;

using MediatR;
using Numploy.Application.DTOs.JobApplications;

public class GetJobApplicationDetailRequest : IRequest<JobApplicationDto>
{
    public int Id { get; set; }
}