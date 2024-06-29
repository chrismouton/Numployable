namespace Numploy.Application.DTOs.JobApplications;

using Numploy.Application.DTOs.Common;

public class ExpiredJobApplicationDto : BaseDto
{
    public ApplicationStatus ApplicationStatus { get; set; } = ApplicationStatus.Expired;
}