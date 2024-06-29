namespace Numployable.Application.DTOs.JobApplications;

using Numployable.Application.DTOs.Common;

public class RejectedJobApplicationDto : BaseDto
{
    public ApplicationStatus ApplicationStatus { get; set; } = Numployable.ApplicationStatus.Closed;

    public ApplicationProcessStatus ApplicationProcessStatus { get; set; } = Numployable.ApplicationProcessStatus.Rejected;
}