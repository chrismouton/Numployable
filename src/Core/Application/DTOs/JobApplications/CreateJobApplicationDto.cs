using Numployable.Domain;

namespace Numployable.Application.DTOs.JobApplications;

public class CreateJobApplicationDto : JobApplicationListDto
{
    public Source? Source { get; init; }

    public string? AdvertisedSalary { get; init; }

    public string? Location { get; init; }

    public Commute? Commute { get; init; }

    public string? Notes { get; init; }
}