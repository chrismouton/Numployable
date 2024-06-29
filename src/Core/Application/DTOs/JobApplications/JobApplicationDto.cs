namespace Numploy.Application.DTOs.JobApplications;

using Numploy.Application.DTOs.NextActions;

public class JobApplicationDto : CreateJobApplicationDto
{
    public List<NextActionDto> NextActions {get; set;} = [];
}