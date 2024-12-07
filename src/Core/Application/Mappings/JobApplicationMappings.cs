using Numployable.Application.DTOs.JobApplications;
using Numployable.Domain;

namespace Numployable.Application.Mappings;

public static class JobApplicationMappings
{
    public static JobApplication ToJobApplication(this CreateJobApplicationDto from)
    {
        JobApplication to = new ()
        {
            Id = from.Id,
            AdvertisedSalary = from.AdvertisedSalary,
            ApplicationDate = from.ApplicationDate,
            Commute = from.Commute,
            CompanyName = from.CompanyName,
            Location = from.Location,
            Note = from.Notes,
            ProcessStatus = from.ProcessStatus,
            RoleName = from.RoleName
        };

        return to;
    }

    public static JobApplication ToJobApplication(this UpdateJobApplicationDto from)
    {
        JobApplication to = new()
        {
            AdvertisedSalary = from.AdvertisedSalary,
            ApplicationDate = from.ApplicationDate,
            Commute = from.Commute,
            CommuteId = from.Commute == null ? 0 : from.Commute.Id,
            CompanyName = from.CompanyName,
            Location = from.Location,
            Note = from.Notes,
            ProcessStatus = from.ProcessStatus,
            ProcessStatusId = from.ProcessStatus.Id,
            RoleName = from.RoleName,
            RoleType = from.RoleType,
            RoleTypeId = from.RoleType.Id,
            Source = from.Source,
            SourceId = from.Source == null ? 0 : from.Source.Id,
            Status = from.Status,
            StatusId = from.Status.Id
        };

        return to;
    }

    public static JobApplicationDto ToJobApplication(this JobApplication from)
    {
        JobApplicationDto to = new()
        {
            AdvertisedSalary = from.AdvertisedSalary,
            ApplicationDate = from.ApplicationDate,
            Commute = from.Commute,
            CompanyName = from.CompanyName,
            Id = from.Id,
            Location = from.Location,
            Notes = from.Note,
            ProcessStatus = from.ProcessStatus,
            RoleName = from.RoleName,
            RoleType = from.RoleType,
            Source = from.Source,
            Status = from.Status,            
        };

        return to;
    }

    public static JobApplicationListDto ToJobApplicationListItem(this JobApplication from)
    {
        JobApplicationListDto to = new()
        {
            Id = from.Id,
            ApplicationDate = from.ApplicationDate,
            CompanyName = from.CompanyName,
            ProcessStatus = from.ProcessStatus,
            RoleName = from.RoleName,
            RoleType = from.RoleType,
            Status = from.Status
        };        

        return to;
    }
}