namespace Numployable.UI.Web;

using AutoMapper;

using Numployable.APIClient.Client;
using Numployable.UI.Web.Models;


public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateNextActionViewModel, CreateNextActionDto>().ReverseMap();
        CreateMap<NextActionViewModel, NextActionDto>().ReverseMap();
    }
}
