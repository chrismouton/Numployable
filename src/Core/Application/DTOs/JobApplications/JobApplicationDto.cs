using Numployable.Application.DTOs.NextActions;

namespace Numployable.Application.DTOs.JobApplications;

public class JobApplicationDto : CreateJobApplicationDto
{
    public List<NextActionDto> NextActions {get; set;} = [];
}