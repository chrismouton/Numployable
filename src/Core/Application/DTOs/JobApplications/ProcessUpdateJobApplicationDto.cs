using Numployable.Application.DTOs.Common;
using Numployable.Domain;

namespace Numployable.Application.DTOs.JobApplications;

public class ProcessUpdateJobApplicationDto : BaseDto
{
    public ProcessStatus? ApplicationProcessStatus { get; set; }
}