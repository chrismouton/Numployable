namespace Numployable.Application.Features.JobApplications.Requests.Queries;

using MediatR;
using Numployable.Application.DTOs.JobApplications;

public class GetJobApplicationDetailRequest : IRequest<JobApplicationDto>
{
    public int Id { get; set; }
}