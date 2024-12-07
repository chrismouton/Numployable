using AutoMapper;
using Numployable.APIClient.Client;
using Numployable.UI.Web.Models;

namespace Numployable.UI.Web;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DashboardViewModel, DashboardDto>().ReverseMap();

        CreateMap<InfrastructureDataViewModel, ProcessStatusDto>().ReverseMap();
        CreateMap<InfrastructureDataViewModel, StatusDto>().ReverseMap();
        CreateMap<InfrastructureDataViewModel, CommuteDto>().ReverseMap();
        CreateMap<RoleTypeViewModel, RoleTypeDto>().ReverseMap();
        CreateMap<RoleTypeViewModel, RoleType>().ReverseMap();

        CreateMap<CreateJobApplicationViewModel, CreateJobApplicationDto>().ReverseMap();
        CreateMap<JobApplicationViewModel, JobApplicationDto>().ReverseMap();
        CreateMap<JobApplicationViewModel, JobApplicationListDto>().ReverseMap();
        CreateMap<JobApplicationViewModel, JobApplicationDto>().ForPath(d => d.ApplicationDate,
          opt => opt.MapFrom(s => DateTimeOffsetToDateTime(s.ApplicationDate))).ReverseMap();

        CreateMap<CreateNextActionViewModel, CreateNextActionDto>().ReverseMap();
        CreateMap<NextActionViewModel, NextActionDto>().ReverseMap();
    }

    private static DateTime DateTimeOffsetToDateTime(DateTimeOffset source)
    {
      string dateTimeString = source.ToString();
      return DateTimeOffset.Parse(dateTimeString).UtcDateTime;
    }
}
