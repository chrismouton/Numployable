namespace Numployable.Application.DTOs.JobApplications;

using Numployable.Domain;

public class CreateJobApplicationDto : JobApplicationListDto
{
    public Source? ApplicationSource { get; set; }

    public string? AdvertisedSalary { get; set; }

    public string? Location { get; set; }

    public Commute? Commute { get; set; }

    public string? Notes { get; set; }
}