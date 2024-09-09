namespace Numployable.Application.Profiles;

using AutoMapper;

using DTOs.JobApplications;
using DTOs.NextActions;
using DTOs.Dashboard;
using Domain;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Dashboard, DashboardDto>().ReverseMap();

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