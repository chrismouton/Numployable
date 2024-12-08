using AutoMapper;
using Numployable.APIClient.Client;
using Numployable.UI.Web.Models;

namespace Numployable.UI.Web.Mappings;

public static class JobApplicationMappings
{
  public static JobApplicationViewModel ToJobApplication(this JobApplicationDto from, IMapper mapper)
  {
    JobApplicationViewModel to =
      new()
      {
        AdvertisedSalary = from.AdvertisedSalary,
        ApplicationDate = DateTimeOffsetToDateTime(from.ApplicationDate.Value),
        Commute = mapper.Map<ReferenceDataViewModel>(from.Commute),
        CommuteId = from.Commute.Id,
        CompanyName = from.CompanyName,
        Id = from.Id,
        Location = from.Location,
        Notes = from.Notes,
        ProcessStatus = mapper.Map<ReferenceDataViewModel>(from.ProcessStatus),
        ProcessStatusId = from.ProcessStatus.Id,
        RoleName = from.RoleName,
        RoleType = mapper.Map<ReferenceDataViewModel>(from.RoleType),
        RoleTypeId = from.RoleType == null ? 0 : from.RoleType.Id,
        Source = mapper.Map<ReferenceDataViewModel>(from.Source),
        SourceId = from.Source.Id,
        Status = mapper.Map<ReferenceDataViewModel>(from.Status),
        StatusId = from.Status.Id
      };

    return to;
  }

  public static CreateJobApplicationDto ToJobApplication(this CreateJobApplicationViewModel from)
  {
    CreateJobApplicationDto to = new()
    {
      AdvertisedSalary = from.AdvertisedSalary,
      ApplicationDate = from.ApplicationDate,
      //Commute = from.CommuteId,
      CompanyName = from.CompanyName,
      Location = from.Location,
      Notes = from.Notes,
      //ProcessStatus = from.ProcessStatusId,
      RoleName = from.RoleName
      //RoleType = from.RoleTypeId,
      //Source = from.SourceId,
      //Status = from.StatusId
    };

    return to;
  }

  public static UpdateJobApplicationDto ToJobApplication(this JobApplicationViewModel from, IMapper mapper)
  {
    UpdateJobApplicationDto to = new()
    {
      Id = from.Id,
      AdvertisedSalary = from.AdvertisedSalary,
      ApplicationDate = from.ApplicationDate,
      Commute = mapper.Map<Commute>(from.Commute),
      CompanyName = from.CompanyName,
      Location = from.Location,
      Notes = from.Notes,
      ProcessStatus = mapper.Map<ProcessStatus>(from.ProcessStatus),
      RoleName = from.RoleName,
      RoleType = mapper.Map<RoleType>(from.RoleType),
      Source = mapper.Map<Source>(from.Source),
      Status = mapper.Map<Status>(from.Status)
    };

    return to;
  }

  public static JobApplicationViewModel ToJobApplication(this JobApplicationListDto from, IMapper mapper)
  {
    JobApplicationViewModel to = new()
    {
      ApplicationDate = DateTimeOffsetToDateTime(from.ApplicationDate.Value),
      CompanyName = from.CompanyName,
      Id = from.Id,
      ProcessStatus = mapper.Map<ReferenceDataViewModel>(from.ProcessStatus),
      ProcessStatusId = from.ProcessStatus.Id,
      RoleName = from.RoleName,
      RoleType = mapper.Map<ReferenceDataViewModel>(from.RoleType),
      RoleTypeId = from.RoleType == null ? 0 : from.RoleType.Id,
      Status = mapper.Map<ReferenceDataViewModel>(from.Status),
      StatusId = from.Status.Id
    };

    return to;
  }

  private static DateTime DateTimeOffsetToDateTime(DateTimeOffset source)
  {
    string? dateTimeString = source.ToString();
    return DateTimeOffset.Parse(dateTimeString).UtcDateTime;
  }
}
