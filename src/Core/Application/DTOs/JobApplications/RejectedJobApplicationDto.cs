namespace Numployable.Application.DTOs.JobApplications;

using Numployable.Application.DTOs.Common;

public class RejectedJobApplicationDto : BaseDto
{
    public Status ApplicationStatus { get; set; } = Numployable.Status.Closed;

    public ProcessStatus ApplicationProcessStatus { get; set; } = Numployable.ProcessStatus.Rejected;
}