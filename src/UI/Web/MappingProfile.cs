using AutoMapper;
using Numployable.APIClient.Client;
using Numployable.UI.Web.Models;

namespace Numployable.UI.Web;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DashboardViewModel, DashboardDto>().ReverseMap();

        CreateMap<CreateJobApplicationViewModel, CreateJobApplicationDto>().ReverseMap();
        CreateMap<JobApplicationViewModel, JobApplicationDto>().ReverseMap();

        CreateMap<CreateNextActionViewModel, CreateNextActionDto>().ReverseMap();
        CreateMap<NextActionViewModel, NextActionDto>().ReverseMap();
    }
}
