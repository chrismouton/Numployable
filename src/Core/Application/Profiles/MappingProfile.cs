namespace Numployable.Application.Profiles;

using AutoMapper;

using Domain;
using DTOs.InfrastructureData;
using DTOs.JobApplications;
using DTOs.NextActions;
using DTOs.Dashboard;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Dashboard, DashboardDto>().ReverseMap();

        #region Infrastructure Data

        CreateMap<Commute, CommuteDto>().ReverseMap();
        CreateMap<NextActionType, NextActionTypeDto>().ReverseMap();
        CreateMap<ProcessStatus, ProcessStatusDto>().ReverseMap();
        CreateMap<RoleType, RoleTypeDto>().ReverseMap();
        CreateMap<Source, SourceDto>().ReverseMap();
        CreateMap<Status, StatusDto>().ReverseMap();

        #endregion

        #region JobApplication

        CreateMap<JobApplication, JobApplicationDto>().ReverseMap();
        CreateMap<JobApplication, JobApplicationListDto>().ReverseMap();
        CreateMap<JobApplication, CreateJobApplicationDto>().ReverseMap();
        CreateMap<JobApplication, UpdateJobApplicationDto>().ReverseMap();
        
        #endregion

        #region NextAction

        CreateMap<NextAction, NextActionDto>().ReverseMap();
        CreateMap<NextAction, CreateNextActionDto>().ReverseMap();
        CreateMap<NextAction, UpdateNextActionDto>().ReverseMap();

        #endregion
    }
}