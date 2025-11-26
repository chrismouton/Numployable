using Numployable.Domain;

namespace Numployable.Application.DTOs.JobApplications;

public abstract class ProcessUpdateJobApplicationDto : BaseDto
{
    public ProcessStatus? ProcessStatus { get; set; }
}