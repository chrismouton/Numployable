using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Numployable.APIClient.Client;

namespace Numployable.UI.Web.Models;

public class JobApplicationViewModel : CreateJobApplicationViewModel

{
    public int Id { get; set; }

    public ReferenceDataViewModel RoleType { get; set; }

    public ReferenceDataViewModel Status { get; set; }

    public ReferenceDataViewModel ProcessStatus { get; set; }

    public ReferenceDataViewModel Source { get; set; }

    public ReferenceDataViewModel Commute { get; set; }
}

public class CreateJobApplicationViewModel
{
    [Display(Name = "Role Name")]
    [Required]
    public string RoleName { get; set; }

    [Display(Name = "Company Name")]
    [Required]
    public string CompanyName { get; set; }

    [Display(Name = "Role Type")]
    public int RoleTypeId { get; set; }

    public SelectList RoleTypeList { get; set; }

    [Display(Name = "Application Date")]
    [DataType(DataType.Date)]
    public DateTime ApplicationDate { get; set; }

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
