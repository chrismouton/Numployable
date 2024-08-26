namespace Numployable.Application.DTOs.JobApplications;

using NextActions;

public class JobApplicationDto : CreateJobApplicationDto
{
    public List<NextActionDto> NextActions {get; set;} = [];
}