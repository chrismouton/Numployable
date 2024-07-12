namespace Numployable.UI.Web;

using AutoMapper;

using Numployable.UI.Web.Models;
using Numployable.UI.Web.Services.Base;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateNextActionViewModel, CreateNextActionDto>().ReverseMap();
        CreateMap<NextActionViewModel, NextActionDto>().ReverseMap();
    }
}