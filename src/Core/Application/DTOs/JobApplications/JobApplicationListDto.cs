using Numployable.Domain;

namespace Numployable.Application.DTOs.JobApplications;

public class JobApplicationListDto : BaseDto
{
    public required string RoleName { get; init; }

    public string? CompanyName { get; init; }

    public required RoleType RoleType { get; init; }

    public required DateTime ApplicationDate { get; init; }

    public required Status Status { get; init; }

    public required ProcessStatus ProcessStatus { get; init; }
}