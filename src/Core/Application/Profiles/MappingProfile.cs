using AutoMapper;
using Numployable.Application.DTOs.Dashboard;
using Numployable.Application.DTOs.ReferenceData;
using Numployable.Domain;

namespace Numployable.Application.Profiles;

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
    }
}