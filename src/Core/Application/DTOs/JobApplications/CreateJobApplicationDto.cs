namespace Numployable.Application.DTOs.JobApplications;

public class CreateJobApplicationDto : JobApplicationListDto
{
    public ApplicationSource? ApplicationSource { get; set; }

    public string? AdvertisedSalary { get; set; }

    public string? Location { get; set; }

    public Commute? Commute { get; set; }

    public string? Notes { get; set; }
}