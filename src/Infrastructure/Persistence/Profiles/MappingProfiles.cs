namespace Numployable.Persistence.Profiles;

using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Helpers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateEnumMaps();
        CreateNextActionMaps();
        CreateJobApplicationMaps();

    }

    private void CreateNextActionMaps()
    {
        CreateMap<Model.NextAction, Domain.NextAction>().ConvertUsing((value, destination) =>
        {
            destination.Id = value.Id;
            destination.NextActionType = value.NextActionTypeId;
            destination.ActionNote = value.ActionNote;
            destination.ActionDate = value.ActionDate;

            return destination;
        });
        CreateMap<Domain.NextAction, Model.NextAction>().ConvertUsing((value, destination) =>
        {
            destination.Id = value.Id;
            if (value.NextActionType != null)
                destination.NextActionTypeId = value.NextActionType.Value;
            if(value.NextActionType != null)
                destination.NextActionType = new Model.NextActionType() {
                    Id = value.NextActionType.Value,
                    Description = Helpers.GetDescription(value.NextActionType.Value)
                };
            if (value.ActionNote != null)
                destination.ActionNote = value.ActionNote;
            if (value.ActionDate != null)
                destination.ActionDate = value.ActionDate.Value;

            return destination;
        });
    }

        private void CreateJobApplicationMaps()
    {
        CreateMap<Model.JobApplication, Domain.JobApplication>().ConvertUsing((value, destination) =>
        {
            destination.Id = value.Id;
            destination.RoleName = value.RoleName;
            destination.CompanyName = value.CompanyName;
            destination.RoleType = value.RoleTypeId;
            destination.Status = value.StatusId;
            destination.ProcessStatus = value.ProcessStatusId;
            destination.Source = value.SourceId;
            destination.Url = value.Url;
            destination.AdvertisedSalary = value.AdvertisedSalary;
            destination.Location = value.Location;
            destination.ApplicationDate = value.ApplicationDate;
            destination.Commute = value.CommuteId;
            destination.Notes = value.Note;

            return destination;
        });
        CreateMap<Domain.JobApplication, Model.JobApplication>().ConvertUsing((value, destination) =>
        {
            destination.Id = value.Id;
            destination.RoleName = value.RoleName;
            destination.CompanyName = value.CompanyName;
            destination.RoleTypeId = value.RoleType;
            destination.RoleType = new Model.RoleType(){
                    Id = value.RoleType,
                    Description = Helpers.GetDescription(value.RoleType)
                };
            destination.StatusId = value.Status;
            destination.Status = new Model.Status() {
                    Id = value.Status,
                    Description = Helpers.GetDescription(value.Status)
                };
            destination.ProcessStatusId = value.ProcessStatus;
            destination.ProcessStatus = new Model.ProcessStatus() {
                Id = value.ProcessStatus,
                Description = Helpers.GetDescription(value.ProcessStatus)
            };
            destination.SourceId = value.Source;
            destination.Source = new Model.Source() {
                Id = value.Source,
                Description = Helpers.GetDescription(value.Source)
            };
            destination.Url = value.Url;
            destination.AdvertisedSalary = value.AdvertisedSalary;
            destination.Location = value.Location;
            destination.ApplicationDate = value.ApplicationDate;
            destination.CommuteId = value.Commute;
            if (value.Commute != null)
                destination.Commute = new Model.Commute() {
                    Id = value.Commute.Value,
                    Description = Helpers.GetDescription(value.Commute.Value)
                };
            destination.Note = value.Notes;

            return destination;
        });
    }


    private void CreateEnumMaps()
    {
        CreateMap<Commute, Model.Commute>().ConvertUsing((value, destination) =>
        {
            destination.Id = value;
            destination.Description = Helpers.GetDescription(value);

            return destination;
        });
        CreateMap<NextActionType, Model.NextActionType>().ConvertUsing((value, destination) =>
        {
            destination.Id = value;
            destination.Description = Helpers.GetDescription(value);

            return destination;
        });
        CreateMap<ProcessStatus, Model.ProcessStatus>().ConvertUsing((value, destination) =>
        {
            destination.Id = value;
            destination.Description = Helpers.GetDescription(value);

            return destination;
        });
        CreateMap<RoleType, Model.RoleType>().ConvertUsing((value, destination) =>
        {
            destination.Id = value;
            destination.Description = Helpers.GetDescription(value);

            return destination;
        });
        CreateMap<Source, Model.Source>().ConvertUsing((value, destination) =>
        {
            destination.Id = value;
            destination.Description = Helpers.GetDescription(value);

            return destination;
        });
        CreateMap<Status, Model.Status>().ConvertUsing((value, destination) =>
        {
            destination.Id = value;
            destination.Description = Helpers.GetDescription(value);

            return destination;
        });
        CreateMap<Model.Commute, Commute>().ConvertUsing((value, destination) =>
        {
            return value.Id;
        });
        CreateMap<Model.NextActionType, NextActionType>().ConvertUsing((value, destination) =>
        {
            return value.Id;
        });
        CreateMap<Model.ProcessStatus, ProcessStatus>().ConvertUsing((value, destination) =>
        {
            return value.Id;
        });
        CreateMap<Model.RoleType, RoleType>().ConvertUsing((value, destination) =>
        {
            return value.Id;
        });
        CreateMap<Model.Source, Source>().ConvertUsing((value, destination) =>
        {
            return value.Id;
        });
        CreateMap<Model.Status, Status>().ConvertUsing((value, destination) =>
        {
            return value.Id;
        });
    }
}