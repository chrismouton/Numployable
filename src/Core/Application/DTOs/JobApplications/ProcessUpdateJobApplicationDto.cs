namespace Numployable.Application.DTOs.JobApplications;

using Common;
using Numployable.Domain;

public class ProcessUpdateJobApplicationDto : BaseDto
{
    public ProcessStatus? ApplicationProcessStatus { get; set; }
}