namespace Numploy.Application.Profiles;

using AutoMapper;
using Numploy.Application.DTOs.JobApplications;
using Numploy.Application.DTOs.NextActions;
using Numploy.Domain;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region JobApplication

        CreateMap<JobApplication, JobApplicationDto>().ReverseMap();
        CreateMap<JobApplication, JobApplicationListDto>().ReverseMap();
        CreateMap<JobApplication, CreateJobApplicationDto>().ReverseMap();
        CreateMap<JobApplication, ExpiredJobApplicationDto>().ReverseMap();
        CreateMap<JobApplication, ProcessUpdateJobApplicationDto>().ReverseMap();
        CreateMap<JobApplication, RejectedJobApplicationDto>().ReverseMap();
        CreateMap<JobApplication, UpdateJobApplicationDto>().ReverseMap();
        
        #endregion

        #region NextAction

        CreateMap<NextAction, NextActionDto>().ReverseMap();
        CreateMap<NextAction, CreateNextActionDto>().ReverseMap();
        CreateMap<NextAction, UpdateNextActionDto>().ReverseMap();

        #endregion
    }
}