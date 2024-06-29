namespace Numployable.Domain;

using System.Collections.Generic;

public class JobApplication : BaseDomainEntity
{
    public string RoleName { get; set; }

    public string CompanyName { get; set; }

    public RoleType RoleType { get; set; }

    public ApplicationStatus ApplicationStatus { get; set; } = ApplicationStatus.Active;

    public ApplicationProcessStatus ApplicationProcessStatus { get; set; }

    public ApplicationSource ApplicationSource { get; set; } = ApplicationSource.JobBoard;

    public string? AdvertisedSalary { get; set; }

    public string? Location { get; set; }

    public DateTime ApplicationDate { get; set; } = DateTime.Now;

    public Commute? Commute { get; set; }

    public string? Notes { get; set; }

    public List<NextAction> NextActions { get; set; } = [];
};