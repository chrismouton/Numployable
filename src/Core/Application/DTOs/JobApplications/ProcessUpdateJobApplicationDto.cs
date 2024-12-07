using Numployable.Domain;

namespace Numployable.Application.DTOs.JobApplications;

public class ProcessUpdateJobApplicationDto : BaseDto
{
    public ProcessStatus? ProcessStatus { get; set; }
}