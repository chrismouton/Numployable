namespace Numployable.UI.Web;

using AutoMapper;

using Models;
using Services.Base;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateNextActionViewModel, CreateNextActionDto>().ReverseMap();
        CreateMap<NextActionViewModel, NextActionDto>().ReverseMap();
    }
}