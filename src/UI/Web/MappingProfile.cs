using AutoMapper;
using Numployable.APIClient.Client;
using Numployable.UI.Web.Models;

namespace Numployable.UI.Web;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<DashboardViewModel, DashboardDto>().ReverseMap();

    CreateMap<ReferenceDataViewModel, ProcessStatusDto>().ReverseMap();
    CreateMap<ReferenceDataViewModel, ProcessStatus>().ReverseMap();
    CreateMap<ReferenceDataViewModel, StatusDto>().ReverseMap();
    CreateMap<ReferenceDataViewModel, Status>().ReverseMap();
    CreateMap<ReferenceDataViewModel, CommuteDto>().ReverseMap();
    CreateMap<ReferenceDataViewModel, Commute>().ReverseMap();
    CreateMap<ReferenceDataViewModel, RoleTypeDto>().ReverseMap();
    CreateMap<ReferenceDataViewModel, RoleType>().ReverseMap();
    CreateMap<ReferenceDataViewModel, NextActionType>().ReverseMap();
  }
}
