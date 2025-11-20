using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Numployable.UI.Web.Models;

public class JobApplicationViewModel : CreateJobApplicationViewModel

{
  public int Id { get; init; }

  public ReferenceDataViewModel RoleType { get; init; }

  public ReferenceDataViewModel Status { get; init; }

  public ReferenceDataViewModel ProcessStatus { get; init; }

  public ReferenceDataViewModel Source { get; init; }

  public ReferenceDataViewModel Commute { get; init; }
}

public class CreateJobApplicationViewModel
{
  [Display(Name = "Role Name")]
  [Required]
  public string RoleName { get; init; }

  [Display(Name = "Company Name")]
  [Required]
  public string CompanyName { get; init; }

  [Display(Name = "Role Type")] public int RoleTypeId { get; init; }

  public SelectList RoleTypeList { get; init; }

  [Display(Name = "Application Date")]
  [DataType(DataType.Date)]
  public DateTime ApplicationDate { get; init; }

  public SelectList StatusList { get; init; }

  [Display(Name = "Application Status")]
  public int StatusId { get; init; }

  public SelectList ProcessStatusList { get; init; }

  [Display(Name = "Application Process Status")]
  public int ProcessStatusId { get; init; }

  public string? Url { get; init; }

  public SelectList SourceList { get; init; }

  [Display(Name = "Source")]
  public int SourceId { get; init; }

  [Display(Name = "Advertised Salary")]
  public string? AdvertisedSalary { get; init; }

  public string? Location { get; init; }

  public SelectList CommuteList { get; init; }

  [Display(Name = "Commute")] public int CommuteId { get; init; }

  public string? Notes { get; init; }
}
