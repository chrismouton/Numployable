using Numployable.Domain;

namespace Numployable.Application.DTOs.JobApplications;

public class JobApplicationListDto : BaseDto
{
    public required string RoleName { get; set; }

    public string? CompanyName { get; set; }

    public required RoleType RoleType { get; set; }

    public required DateTime ApplicationDate { get; set; }

    public required Status Status { get; set; }

    public required ProcessStatus ProcessStatus { get; set; }
}