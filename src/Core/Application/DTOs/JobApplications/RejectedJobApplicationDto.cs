namespace Numploy.Application.DTOs.JobApplications;

using Numploy.Application.DTOs.Common;

public class RejectedJobApplicationDto : BaseDto
{
    public ApplicationStatus ApplicationStatus { get; set; } = Numploy.ApplicationStatus.Closed;

    public ApplicationProcessStatus ApplicationProcessStatus { get; set; } = Numploy.ApplicationProcessStatus.Rejected;
}