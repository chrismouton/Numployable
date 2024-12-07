using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Numployable.APIClient.Client;

namespace Numployable.UI.Web.Models;

public class JobApplicationViewModel : CreateJobApplicationViewModel

{
    public int Id { get; set; }

    public RoleTypeViewModel RoleType { get; set; }

    public InfrastructureDataViewModel Status { get; set; }

    public InfrastructureDataViewModel ProcessStatus { get; set; }

    public InfrastructureDataViewModel Source { get; set; }

    public InfrastructureDataViewModel Commute { get; set; }
}

public class CreateJobApplicationViewModel
{
    [Display(Name = "Role Name")]
    [Required]
    public required string RoleName { get; set; }

    [Display(Name = "Company Name")]
    [Required]
    public required string CompanyName { get; set; }

    [Display(Name = "Role Type")]
    public int RoleTypeId { get; set; }

    public SelectList RoleTypeList { get; set; }

    [Display(Name = "Application Date")]
    [DataType(DataType.Date)]
    public required DateTime ApplicationDate { get; set; }

    public SelectList StatusList { get; set; }

    [Display(Name = "Application Status")]
    public int StatusId { get; set; }

    public SelectList ProcessStatusList { get; set; }

    [Display(Name = "Application Process Status")]
    public int ProcessStatusId { get; set; }

    public string? Url { get; set; }

    public SelectList SourceList { get; set; }

    [Display(Name = "Source")]
    public int SourceId { get; set; }

    [Display(Name = "Advertised Salary")]
    public string? AdvertisedSalary { get; set; }

    public string? Location { get; set; }

    public SelectList CommuteList { get; set; }

    [Display(Name = "Commute")]
    public int CommuteId { get; set; }

    public string? Notes { get; set; }
}
