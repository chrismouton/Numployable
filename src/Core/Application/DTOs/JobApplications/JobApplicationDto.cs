namespace Numployable.Application.DTOs.JobApplications;

using Numployable.Application.DTOs.NextActions;

public class JobApplicationDto : CreateJobApplicationDto
{
    public List<NextActionDto> NextActions {get; set;} = [];
}