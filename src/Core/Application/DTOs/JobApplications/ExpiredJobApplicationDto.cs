namespace Numployable.Application.DTOs.JobApplications;

using Numployable.Application.DTOs.Common;

public class ExpiredJobApplicationDto : BaseDto
{
    public Status ApplicationStatus { get; set; } = Status.Expired;
}