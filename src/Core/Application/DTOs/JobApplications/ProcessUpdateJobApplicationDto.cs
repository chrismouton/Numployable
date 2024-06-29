namespace Numployable.Application.DTOs.JobApplications;

using Numployable.Application.DTOs.Common;

public class ProcessUpdateJobApplicationDto : BaseDto
{
    public ApplicationProcessStatus? ApplicationProcessStatus { get; set; }
}