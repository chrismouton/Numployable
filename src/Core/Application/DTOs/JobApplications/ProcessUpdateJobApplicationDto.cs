namespace Numployable.Application.DTOs.JobApplications;

using Common;

public class ProcessUpdateJobApplicationDto : BaseDto
{
    public ProcessStatus? ApplicationProcessStatus { get; set; }
}