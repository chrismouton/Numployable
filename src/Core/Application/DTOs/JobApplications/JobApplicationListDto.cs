namespace Numployable.Application.DTOs.JobApplications;

using Common;

public class JobApplicationListDto : BaseDto
{
    public string? RoleName { get; set; }

    public string? CompanyName { get; set; }

    public RoleType? RoleType { get; set; }

    public DateTime? ApplicationDate { get; set; }

    public Status? ApplicationStatus { get; set; }

    public ProcessStatus? ApplicationProcessStatus { get; set; }

    public string? Url { get; set; }
}
