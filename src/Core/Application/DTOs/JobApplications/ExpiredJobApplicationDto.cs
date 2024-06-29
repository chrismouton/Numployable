namespace Numployable.Application.DTOs.JobApplications;

using Numployable.Application.DTOs.Common;

public class ExpiredJobApplicationDto : BaseDto
{
    public ApplicationStatus ApplicationStatus { get; set; } = ApplicationStatus.Expired;
}