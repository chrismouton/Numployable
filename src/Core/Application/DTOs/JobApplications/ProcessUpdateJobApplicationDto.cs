namespace Numploy.Application.DTOs.JobApplications;

using Numploy.Application.DTOs.Common;

public class ProcessUpdateJobApplicationDto : BaseDto
{
    public ApplicationProcessStatus? ApplicationProcessStatus { get; set; }
}