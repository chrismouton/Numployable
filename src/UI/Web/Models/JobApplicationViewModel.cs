namespace Numployable.UI.Web.Models;

using System.ComponentModel.DataAnnotations;

public class JobApplicationViewModel : CreateJobApplicationViewModel

{
    public int Id { get; set; }
}

public class CreateJobApplicationViewModel
{
    [Required]
    public required string RoleName { get; set; }

    [Required]
    public required string CompanyName { get; set; }

    public RoleType? RoleType { get; set; }


    [DataType(DataType.Date)]
    public required DateTime ApplicationDate { get; set; }

    public Status? ApplicationStatus { get; set; }

    public ProcessStatus? ApplicationProcessStatus { get; set; }

    public Source? ApplicationSource { get; set; }

    public string? AdvertisedSalary { get; set; }

    public string? Location { get; set; }

    public Commute? Commute { get; set; }

    public string? Notes { get; set; }
}
