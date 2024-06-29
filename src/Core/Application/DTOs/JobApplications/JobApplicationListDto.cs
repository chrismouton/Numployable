namespace Numploy.Application.DTOs.JobApplications;

using Numploy.Application.DTOs.Common;

public class JobApplicationListDto : BaseDto
{
    public string? RoleName { get; set; }

    public string? CompanyName { get; set; }

    public RoleType? RoleType { get; set; }

    public DateTime? ApplicationDate { get; set; }

    public ApplicationStatus? ApplicationStatus { get; set; }

    public ApplicationProcessStatus? ApplicationProcessStatus { get; set; }
}